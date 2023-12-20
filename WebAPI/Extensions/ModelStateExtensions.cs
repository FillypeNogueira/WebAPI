using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WebAPI.Extensions
{
    public static class ModelStateExtensions
    {
        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(selector: err => err.Value.Errors).Select(value => value.ErrorMessage).ToList();
        }
    }
}
