namespace Photographers.Attributes
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CustomMinLengthAttribute : ValidationAttribute
    {
        public int MinLengthValue { get; set; }

        public override bool IsValid(object value)
        {
            string valueAsString = (string)value;
            if (valueAsString.Length < this.MinLengthValue)
            {
                return false;
            }

            return true;
        }
    }
}
