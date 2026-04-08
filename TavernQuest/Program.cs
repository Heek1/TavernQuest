using TavernQuest.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<ITavernKeeperService, TavernKeeperService>();
builder.Services.AddScoped<IVisitService, VisitService>();
builder.Services.AddTransient<IDiceService, DiceService>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
    app.UseExceptionHandler("/Home/Error");

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Tavern}/{action=Index}/{id?}");

app.Run();
