var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

//{controller=Home}/{action=İndex}/id?
//app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name:"defalt",
    pattern:"{Controller=Home}/{action=Index}/{id?}"
);
app.Run();
