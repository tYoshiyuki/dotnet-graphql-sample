namespace GraphQLSample.Web.Models
{
    public record Author
    {
        public int Id { get; init; }
        public string Name { get; init; } = default!;
    }
}
