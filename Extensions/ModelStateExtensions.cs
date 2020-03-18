using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

namespace FullStack_Project_IE_2.Extensions
{
    public static class ModelStateExtensions
    {

        public static List<string> GetErrorMessages(this ModelStateDictionary dictionary)
        {
            return dictionary.SelectMany(m=>m.Value.Errors).Select(m=>m.ErrorMessage).ToList();
        }
    }
}
