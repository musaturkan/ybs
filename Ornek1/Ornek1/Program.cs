using Kutuphane;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Ornek1.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "Oturum";
        options.LoginPath = "/Oturum/Index";
        //options.Cookie.Expiration = new TimeSpan(0, 0, 0);
        
    });
builder.Services.AddAuthorization();
/// <summary>
/// Session nesnesinde veri saklamak istiyorsak a�a��daki servisi ekliyoruaz AddSession()
/// </summary>
builder.Services.AddSession();
builder.Services.ConfigureApplicationCookie(op =>
{
    op.Cookie.Name = "Oturum";

});
//builder.Services.AddScoped<HataMiddleware>();

builder.Services.AddScoped<IArac,Otomobil>();
//builder.Services.AddScoped<ILog, TextLog>();

//builder.Services.AddScoped<ILog,TextLog>(); 
//builder.Services.AddTransient<ILog, TextLog>();
//builder.Services.AddSingleton<ILog, TextLog>(); 

builder.Services.AddScoped<ILog,ServisLog>(p => new ServisLog("http://servis.com"));

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

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Urun}/{action=Index}/{id?}");





//app.UseMiddleware<KontrolMiddleware>();


//app.Use(async (context, next) =>
//{
//    ///talep gelirken �al��an kodlar
//    ///

//    next.Invoke(context);
//    ///cevap d�nd�r�l�r�ken �al��an kodlar
//});

//app.Map("/Oturum", builder =>
//{
//    builder.UseMiddleware<LogMiddleware>();
//});

app.UseMiddleware<HataMiddleware>();
app.UseLogMiddleware();
app.UseMiddleware<LogMiddleware>();

/// <summary>
/// Baz� �artalra g�re middleware �al��t�r�ls�n isteniyorsa MapWhen kullan�l�r
/// </summary>
//app.MapWhen(
//    a => a.Request.Path.Value.Contains("Oturum") && a.Request.Method == "POST"
//    && a.Request.Form.Count>0,
//    builder =>
//{
//    builder.UseMiddleware<LogMiddleware>();
//});


/// <summary>
/// Middleware kullan�rken dikkat edilecekler:
/// Middleware s�n�f� a�a��daki �zelliklerde olmal�d�r:
///     RequestDelegate nesnesi cinsinsinde bir member �yesi olmal�d�r
///     RequestDelegate cinsinden memben �yesi constructer metodundan doldurulmal�d�r
///     Invoke isimli, parametresi HttpContext olan ve i�inde 
///     reuqestdelegate member �yesinin Invoke metodunu �a��ran bir metot bar�nd�rmal�d�r. 
/// Middlaware ak��a dahil edilmesi i�in program.cs dosyas�nda app.UseMiddlevare metodu kullar�larak eklenmelidir
/// app.Map metodu belirli bir adrese g�re devreye giren middleware tan�mlamaya yarar
/// app.MapWhen metodu gelen talebin belli �artlar� kontrol edilerek istenen middlaware devreye al�nmas� i�in kullan�l�r
/// �stenirse middlaware i�in extension metot yaz�labilir.
/// </summary>


app.Run();
