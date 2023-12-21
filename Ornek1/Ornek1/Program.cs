using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "Oturum";
        options.LoginPath = "/Oturum/Giris";
        //options.Cookie.Expiration = new TimeSpan(0, 0, 0);
    });
builder.Services.AddAuthorization();
/// <summary>
/// Session nesnesinde veri saklamak istiyorsak aþaðýdaki servisi ekliyoruaz AddSession()
/// </summary>
builder.Services.AddSession();
builder.Services.ConfigureApplicationCookie(op =>
{
    op.Cookie.Name = "Oturum";

});
//builder.Services.AddScoped<IClaimsTransformation,UserClaimProvider>()
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Urun}/{action=Index}/{id?}");

app.Run();
