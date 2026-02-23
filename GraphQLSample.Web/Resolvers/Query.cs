using GraphQLSample.Web.Models;

namespace GraphQLSample.Web.Resolvers
{
    [QueryType]
    public static class Query
    {
        public static async Task<Book?> GetBookByIdAsync(
            int id,
            ApplicationDbContext dbContext)
        {
            return await dbContext.Books.FindAsync(id);
        }
    }
}
