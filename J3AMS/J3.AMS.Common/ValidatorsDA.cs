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
        public static bool TryValidateModel<T>(T model, Control parentControl, out List<ValidationResult> results)
        {
            var validationContext = new ValidationContext(model, null, null);
            results = new List<ValidationResult>();

            if (!Validator.TryValidateObject(model, validationContext, results, true))
            {
                foreach (var result in results)
                {
                    var propertyName = result.MemberNames.FirstOrDefault();
                    if (!string.IsNullOrEmpty(propertyName))
                    {
                        var validationControl = parentControl.FindControl(propertyName) as BaseValidator;
                        if (validationControl != null)
                        {
                            validationControl.IsValid = false;
                            validationControl.ErrorMessage = result.ErrorMessage;
                        }
                    }
                }

                return false;
            }

            return true;
        }
    }
}
