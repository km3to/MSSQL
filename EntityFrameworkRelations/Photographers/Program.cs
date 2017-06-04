namespace Photographers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Data;
    using Models;
    using System.Data.Entity.Validation;

    class Program
    {
        static void Main(string[] args)
        {
            var context = new PhotographerContext();
            Tag tag = new Tag() { Label = "Krushi " };
            context.Tags.Add(tag);

            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                tag.Label = TagTransformer.Transform(tag.Label);
                context.SaveChanges();
            }
        }
    }
}
