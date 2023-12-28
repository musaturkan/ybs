namespace Ornek1.Middleware
{
    public class KontrolMiddleware
    {
        private readonly RequestDelegate _next;

        public KontrolMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            ///Burada response sırasında yapılması istenen işlemler yazılır
            ///
            if (context.User.Identity.IsAuthenticated == true)
            {
                string ad = context.User.Identity.Name;
                string soyad = context.User.Claims.FirstOrDefault(p => p.Type == "Soyad").Value;

            }
            
            _next.Invoke(context);

            ///Burada response sırasında yapılması istenen işlemler yapılır.
        }
    }
}
