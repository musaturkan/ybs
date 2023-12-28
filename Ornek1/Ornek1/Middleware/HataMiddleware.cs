namespace Ornek1.Middleware
{
    public class HataMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            string a = context.Connection.ToString();
            ///request için çalışacak kodlarımız
            next.Invoke(context);

        }
    }
}
