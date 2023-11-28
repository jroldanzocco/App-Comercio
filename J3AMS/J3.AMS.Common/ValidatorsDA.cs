using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace J3.AMS.Common
{
    public static class ValidatorsDA
    {
        public static bool TryValidateModel<T>(T model)
        {
            ValidationContext vc = new ValidationContext(model);
            ICollection<ValidationResult> results = new List<ValidationResult>(); // Will contain the results of the validation
            bool isValid = Validator.TryValidateObject(model, vc, results, true);

            return isValid;

        }
    }
}
