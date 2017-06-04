namespace PlanetHunters.Import
{
    class Startup
    {
        static void Main(string[] args)
        {
            //JsonImport.ImportAstronomers();
            //JsonImport.ImportPlanets();
            //JsonImport.ImportTelescopes();
            XmlImport.ImportStars();
        }
    }
}
