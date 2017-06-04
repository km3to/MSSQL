namespace PlanetHunters.Export
{
    using Data.Store;
    using Newtonsoft.Json;
    using System.IO;

    public static class JsonExport
    {
        public static void ExportPlanets()
        {
            var planets = PlanetStore.GetPlanets();
            var json = JsonConvert.SerializeObject(planets, Formatting.Indented);

            File.WriteAllText("../../../export/planets.json", json);
        }

        public static void ExportAstronomers()
        {
            var astronomers = AstronomerStore.GetAstronomers();
            var json = JsonConvert.SerializeObject(astronomers, Formatting.Indented);

            File.WriteAllText("../../../export/astronomers.json", json);
        }

        public static void ExportTelescopes()
        {
            var telescopes = TelescopeStore.GetTelescopes();
            var json = JsonConvert.SerializeObject(telescopes, Formatting.Indented);

            File.WriteAllText("../../../export/telescopes.json", json);
        }
    }
}
