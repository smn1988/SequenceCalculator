using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SequenceCalculator.Models
{
    public class PositiveNumberValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }
            int intValue;
            if (int.TryParse(value.ToString(), out intValue))
            {

                if (intValue == 0)
                    return false;

                if (intValue > 0)
                    return true;
            }
            return false;

        }
    }
}