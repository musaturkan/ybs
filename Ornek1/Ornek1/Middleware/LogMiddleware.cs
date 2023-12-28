namespace Ornek1.Middleware
{
    public class LogMiddleware
    {
        private readonly RequestDelegate next;

        public LogMiddleware(RequestDelegate _next)
        {
            next = _next;
        }

        public async Task Invoke(HttpContext context)
        {
            ///Talep geldiğinde buradaki kodlar çalışacaktır
            var hostAdres = context.Request.Host.HasValue;
            var form = context.Request.Form["tckimlikno"];

            var user = context.User;

            //if (user == null)
            //{
            //    return;
            //}
            ///işlem akışını bir sonraki middleware'e yönlendirir
            next.Invoke(context);

            ///Buraya yazılan kodlar istek geri döndürülürken çalışacaktır

        }
    }

   
}
