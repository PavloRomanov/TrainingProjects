using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShop.Model.ViewModel;

namespace WebShop.Model.Validation
{
    public class ValidForProduct
    {
        private static ProductViewModel viewmodel;
        ValidForProduct(ProductViewModel model)
        {
            viewmodel = model;
        }
        List<ValidationResult> results = new List<ValidationResult>();
        ValidationContext context = new ValidationContext(viewmodel);

       /* if (!Validator.TryValidateObject(viewmodel, context, results, true))
            {
                foreach (var error in results)
                {
                    //Console.WriteLine(error.ErrorMessage);
                }
}*/


    }
}

    

