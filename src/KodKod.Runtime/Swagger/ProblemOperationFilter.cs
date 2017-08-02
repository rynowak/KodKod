
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace KodKod.Runtime.Swagger
{
    public class ProblemOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
            // Our API doesn't support 'default' responses we only have status codes (int).
            // We're using -1 as a sentinel and this will correct it.
            if (operation.Responses.TryGetValue("-1", out var response))
            {
                operation.Responses.Add("default", response);
                operation.Responses.Remove("-1");
            }
        }
    }
}
