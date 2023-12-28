namespace Ornek1.Middleware
{
    public class Kaptan
    {
        public IArac Arac { get; set; }
        
        public void AracCalistir()
        {
            Arac.Calistir();

        }

    }
}
