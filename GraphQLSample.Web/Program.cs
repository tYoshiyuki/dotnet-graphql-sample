using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// DbContextFactory を SQLite で登録
builder.Services.AddDbContextFactory<ApplicationDbContext>(
    options => options.UseSqlite("Data Source=app.db"));

// Hot Chocolate の設定
builder.Services
    .AddGraphQLServer()
    .RegisterDbContextFactory<ApplicationDbContext>()
    .AddTypes();

var app = builder.Build();

// 初回起動時にデータベースファイルを作成する場合（開発用）
using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
    using var context = factory.CreateDbContext();

    if (app.Environment.IsDevelopment())
    {
        // 開発環境では、データベースをリセットしてシードデータを再投入する
        context.Database.EnsureDeleted();
    }
    context.Database.EnsureCreated();
}

app.MapGraphQL();

app.RunWithGraphQLCommands(args);
