namespace GraphQLSample.Web.Types
{
    public record Book
    {
        public int Id { get; init; }
        public string Title { get; init; } = default!;

        public int AuthorId { get; init; }

        public Author Author { get; init; } = default!;
    }
}
