using CS_Actions_WebApp.Infrastructures.Context;
using CS_Actions_WebApp.Infrastructures.Repository;
using CS_Actions_WebApp.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 【追加】AppDbContextの登録
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// MVCのコントローラーとビュー、およびCalcServiceをDIコンテナに登録
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CalcService>();
// 【追加】 Repositoryの登録
builder.Services.AddScoped<ProductRepository>();
// 【追加】 Serviceの登録
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

app.UseRouting();

// デフォルトのルーティングをCalcControllerのIndexに設定
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calc}/{action=Index}/{id?}");

app.Run();