using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MVCVoertuig.ModelValidations
{
    public class CustomBouwjaar : Attribute, IModelValidator
    {
        public IEnumerable<ModelValidationResult> Validate(ModelValidationContext context)
        {
            var dtm = DateTime.Now;
            var list = new List<ModelValidationResult>();
            if(context.Model != null && DateTime.TryParse(context.Model.ToString(), out dtm))
            {
                if (dtm.Year < 1900 || dtm.Year > DateTime.Now.Year)
                {
                    list.Add(new ModelValidationResult("", "Bouwjaar moet tussen 1900 en het huidige jaar liggen."));
                }

            }
            else
            {
                list.Add(new ModelValidationResult("", "Bouwjaar is verplicht."));
            }
            return list;
        }
    }
}
