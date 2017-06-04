namespace ExamPrep.Import
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        static void Main(string[] args)
        {
            //JsonImport.ImportSolarSystems();
            //JsonImport.ImportStars();
            //JsonImport.ImportPlanets();
            //JsonImport.ImportPeople();
            //JsonImport.ImportAnomalies();
            //JsonImport.ImportVictims();
            XmlImport.ImportAnomalies();
        }
    }
}
