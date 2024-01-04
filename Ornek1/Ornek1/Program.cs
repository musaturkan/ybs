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
/// Session nesnesinde veri saklamak istiyorsak aþaðýdaki servisi ekliyoruaz AddSession()
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
//    ///talep gelirken çalýþan kodlar
//    ///

//    next.Invoke(context);
//    ///cevap döndürülürüken çalýþan kodlar
//});

//app.Map("/Oturum", builder =>
//{
//    builder.UseMiddleware<LogMiddleware>();
//});

app.UseMiddleware<HataMiddleware>();
app.UseLogMiddleware();
app.UseMiddleware<LogMiddleware>();

/// <summary>
/// Bazý þartalra göre middleware çalýþtýrýlsýn isteniyorsa MapWhen kullanýlýr
/// </summary>
//app.MapWhen(
//    a => a.Request.Path.Value.Contains("Oturum") && a.Request.Method == "POST"
//    && a.Request.Form.Count>0,
//    builder =>
//{
//    builder.UseMiddleware<LogMiddleware>();
//});


/// <summary>
/// Middleware kullanýrken dikkat edilecekler:
/// Middleware sýnýfý aþaðýdaki özelliklerde olmalýdýr:
///     RequestDelegate nesnesi cinsinsinde bir member üyesi olmalýdýr
///     RequestDelegate cinsinden memben üyesi constructer metodundan doldurulmalýdýr
///     Invoke isimli, parametresi HttpContext olan ve içinde 
///     reuqestdelegate member üyesinin Invoke metodunu çaðýran bir metot barýndýrmalýdýr. 
/// Middlaware akýþa dahil edilmesi için program.cs dosyasýnda app.UseMiddlevare metodu kullarýlarak eklenmelidir
/// app.Map metodu belirli bir adrese göre devreye giren middleware tanýmlamaya yarar
/// app.MapWhen metodu gelen talebin belli þartlarý kontrol edilerek istenen middlaware devreye alýnmasý için kullanýlýr
/// Ýstenirse middlaware için extension metot yazýlabilir.
/// </summary>


app.Run();
