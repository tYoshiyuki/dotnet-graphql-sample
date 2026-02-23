using GraphQLSample.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace GraphQLSample.Web
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Author> Authors => Set<Author>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Author のシードデータ
            int authorId = 1;
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = authorId, Name = "芥川龍之介" }
            );

            // Book のシードデータ
            // ※ record のプロパティ形式で定義している場合、このように初期化します
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "羅生門",
                    AuthorId = authorId // 外部キーで紐付け
                },
                new Book
                {
                    Id = 2,
                    Title = "鼻",
                    AuthorId = authorId
                }
            );
        }
    }
}
