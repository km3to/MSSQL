namespace ExamPrep.Import
{
    using Data.DTO;
    using Data.Store;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;

    public class XmlImport
    {
        public static void ImportAnomalies()
        {
            XDocument xml = XDocument.Load("../../../datasets/new-anomalies.xml");
            var anomalies = xml.Root.Elements();
            var result = new List<AnomalyWithvictiomsDto>();
            foreach (var anomaly in anomalies)
            {
                var anomalyDto = new AnomalyWithvictiomsDto
                {
                    OriginPlanet = anomaly.Attribute("origin-planet").Value,
                    TeleportPlanet = anomaly.Attribute("teleport-planet").Value,
                    Victims = anomaly.Element("victims").Elements().Select(e => e.Attribute("name").Value).ToList()
                };

                result.Add(anomalyDto);
            }

            AnomalyStore.AddAnomaliesWithVictims(result);
        }
    }
}
