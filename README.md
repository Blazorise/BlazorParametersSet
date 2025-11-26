# BlazorParametersSet

This project is a minimal Blazor application created to test how Blazor handles component parameter updates, including:
- Primitive types
- Class (reference) types
- Record (immutable) types

The project demonstrates when `OnParametersSet` is called and how `ShouldRender` can be used to control whether a component actually re-renders — especially when dealing with complex parameter types.

---

## 🔍 What This Project Demonstrates

### 1. Parent re-render behavior  
The parent component (`BlazorParametersSet`) can trigger re-renders without changing any parameters. This lets you observe how often children get `OnParametersSet` calls even when nothing actually changed.

### 2. Primitive parameters  
Blazor treats primitives (`int`, `bool`, `string`, etc.) as *stable values*.  
- If the value stays the same, the child does **not** re-render.
- `OnParametersSet` is only invoked when the primitive value actually changes.

### 3. Class parameters  
Blazor treats any reference type as “potentially changed,” so:
- `OnParametersSet` runs on **every parent re-render**, even if the same instance is passed.
- Without `ShouldRender`, the component always re-renders.

The project includes an updated component that uses a value snapshot + `ShouldRender()` to prevent unnecessary UI work.

### 4. Record parameters  
Records behave like classes in Blazor **regarding parameters** — they always trigger `OnParametersSet` — but support value equality.
Using `ShouldRender()` with record value comparison allows skipping re-renders when the record has not meaningfully changed.

---

## 🧪 Components Included

### **PrimitiveChild**
- Accepts an `int`.
- Shows that primitives only re-render when their value changes.

### **ClassChild**
- Accepts `ItemClass`.
- Uses a snapshot to detect meaningful value changes.
- Uses `ShouldRender()` to avoid UI updates unless values changed.

### **RecordChild**
- Accepts `ItemRecord`.
- Uses record value equality.
- `ShouldRender()` only returns true when the record value changes.

---

## 🚀 How to Run

1. Clone or download the project.
2. Run it with:
   ```
   dotnet run
   ```
3. Navigate to:

```
/blazor-parameters-set
```

4. Use the buttons to:
   - Re-render the parent without changing parameters
   - Mutate class instance properties
   - Replace class/record with the same or different values
   - Observe:
     - `OnParametersSet` calls
     - Actual renders (from `ShouldRender`)
     - Console logs

---

## 📈 Why This Project Exists

There's a common misconception that:
- Blazor only re-renders children when parameters change  
- Or that records behave differently than classes regarding render triggering  

This project proves the actual rules:

### ✔ `OnParametersSet` runs for complex types on *every parent render*  
### ✔ Primitives only trigger updates when the value changes  
### ✔ Records don’t affect Blazor’s parameter pipeline, but help with value comparison  
### ✔ `ShouldRender()` is the only way to control UI-level rendering for complex params  

---

## 📁 Project Structure

```
BlazorParametersSet/
  ├── Pages/
  │     └── BlazorParametersSet.razor
  ├── Components/
  │     ├── PrimitiveChild.razor
  │     ├── ClassChild.razor
  │     └── RecordChild.razor
  ├── Models/
  │     ├── ItemClass.cs
  │     └── ItemRecord.cs
  ├── README.md
  └── Program.cs
```

---

## 📬 Notes

This project is purely educational and meant for testing Blazor parameter behavior in an isolated environment.  
Feel free to expand it with:
- Cascading values
- RenderFragment tests
- Event-driven updates
- Diffing experiments

---

## 📦 Download

The full project archive is included in this release.
