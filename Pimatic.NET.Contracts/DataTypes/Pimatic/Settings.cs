namespace Pimatic.NET.Contracts.DataTypes.Pimatic
{
    public class Settings
    {
        public HttpServer httpServer { get; set; }
        public Database database { get; set; }
        public Authentication authentication { get; set; }
        public HttpsServer httpsServer { get; set; }
        public Gui gui { get; set; }
    }
}