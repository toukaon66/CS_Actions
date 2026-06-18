using CS_Actions_WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

// MVCのコントローラーとビュー、およびCalcServiceをDIコンテナに登録
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CalcService>();

var app = builder.Build();

app.UseRouting();

// デフォルトのルーティングをCalcControllerのIndexに設定
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Calc}/{action=Index}/{id?}");

app.Run();