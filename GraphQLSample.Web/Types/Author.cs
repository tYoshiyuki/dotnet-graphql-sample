namespace GraphQLSample.Web.Types
{
    public record Author
    {
        public int Id { get; init; }
        public string Name { get; init; } = default!;
    }
}
