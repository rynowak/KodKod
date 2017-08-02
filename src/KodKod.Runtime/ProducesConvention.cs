
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace KodKod
{
    public class ProducesConvention : IActionModelConvention
    {
        public void Apply(ActionModel action)
        {
            var returnType = action.ActionMethod.ReturnType;
            if (returnType != null &&
                returnType.IsGenericType &&
                returnType.GetGenericTypeDefinition() == typeof(ActionResult<>))
            {
                action.Filters.Add(new ProducesAttribute("application/json")
                {
                    Type = returnType.GenericTypeArguments[0],
                });
            }
        }
    }
}
