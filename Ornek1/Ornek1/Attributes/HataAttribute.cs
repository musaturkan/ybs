using Microsoft.AspNetCore.Mvc.Filters;

namespace Ornek1.Attributes
{
    /// <summary>
    /// İstisna oluştuğunda tetiklenecek filtredir.
    /// Action metot çalışırken bir istisna fırlatılırsa bu metot tetiklenerek
    /// hata mesajı kayıt edilebilir. Hata oluştuğunda bir başka actina 
    /// yönlendirme yapılabilir.
    /// </summary>
    public class HataAttribute:ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            
        }

    }
}
