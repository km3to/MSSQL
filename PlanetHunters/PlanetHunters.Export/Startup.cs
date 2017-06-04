namespace PlanetHunters.Export
{
    public class Startup
    {
        static void Main(string[] args)
        {
            JsonExport.ExportPlanets();
            JsonExport.ExportAstronomers();
            JsonExport.ExportTelescopes();
        }
    }
}
