namespace Ornek1.Middleware
{
    /// <summary>
    /// Extension sınıfı static olmalıdır.
    /// Extension metodu da static olarak tanımlanır ve IApplicationBuilder cisinden bir 
    /// geri dönüş değeri bulunur. Parametre olarak da IApplicationBuilder nesnesi alır
    /// Parametredeki IApplicationBuilder nesnesi this anahta sözcügü ile işaretlenmelidir
    /// </summary>
    public static class MiddlewareExtension
    {
        public static IApplicationBuilder UseLogMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<LogMiddleware>();
        }

        public static IApplicationBuilder UseKontrolMiddleware(this IApplicationBuilder builder)
        {
           return builder.UseMiddleware<KontrolMiddleware>();
        }
    }
}
