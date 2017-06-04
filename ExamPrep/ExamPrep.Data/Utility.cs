namespace ExamPrep.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class Utility
    {
        public static void InitDB()
        {
            var context = new MassDefectEntities();
            context.Database.Initialize(true);
        }
    }
}
