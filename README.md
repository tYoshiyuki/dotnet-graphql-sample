# dotnet-graphql-sample

.NET 10 / HotChocolate + EF Core (SQLite) を使った GraphQL サンプル。

## 概要
- GraphQL サーバ: Hot Chocolate
- 永続化: EF Core (`IDbContextFactory<ApplicationDbContext>`) + SQLite (`app.db`)

## 使い方
1. リポジトリをクローン
   - `git clone https://github.com/tYoshiyuki/dotnet-graphql-sample`
2. ビルド
   - `dotnet build`
3. 実行
   - 開発モード（推奨）:
     - Windows: `set __ASPNETCORE_ENVIRONMENT__=Development && dotnet run --project GraphQLSample.Web`
     - macOS/Linux: `__ASPNETCORE_ENVIRONMENT__=Development dotnet run --project GraphQLSample.Web`
   - ブラウザで `http://localhost:5000/graphql` を開くと Banana Cake Pop（UI）が利用できます。

## データベース初期化
- デフォルト: 起動時に `app.db` が存在しなければ作成（`EnsureCreated()`）。
- 毎回リセットしたい（開発専用）場合は、`Program.cs` の初期化コードで `EnsureDeleted()` → `EnsureCreated()` を呼んでください（既存データは消えます）。
- マイグレーションを使う場合:
  - マイグレーションを追加: `dotnet ef migrations add Initial -p GraphQLSample.Web -s GraphQLSample.Web`
  - 適用: `dotnet ef database update -p GraphQLSample.Web -s GraphQLSample.Web`
