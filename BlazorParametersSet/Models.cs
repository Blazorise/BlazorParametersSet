namespace BlazorParametersSet
{
    public class ItemClass
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public override string ToString() => $"Class(Id={Id}, Name={Name})";
    }

    public record ItemRecord( int Id, string Name );
}
