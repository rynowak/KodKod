using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace Microsoft.AspNetCore.Mvc
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class ProblemErrorPolicyAttribute : Attribute, IErrorPolicy, IExceptionFilter, IActionFilter
    {
        public void ApplyDescription(ErrorPolicyContext context)
        {
            if (context.Description.ActionDescriptor.Parameters.Count > 0)
            {
                context.Description.SupportedResponseTypes.Add(new ApiResponseType()
                {
                    ApiResponseFormats = new List<ApiResponseFormat>()
                    {
                        new ApiResponseFormat()
                        {
                            Formatter = context.Formatters.OfType<JsonOutputFormatter>().Single(),
                            MediaType = "application/problem+json",
                        },
                    },
                    ModelMetadata = context.MetadataProvider.GetMetadataForType(typeof(Problem)),
                    StatusCode = 400,
                    Type = typeof(Problem),
                });

                if (context.Description.ActionDescriptor.Parameters.Any(p => p.Name == "id"))
                {
                    context.Description.SupportedResponseTypes.Add(new ApiResponseType()
                    {
                        ApiResponseFormats = new List<ApiResponseFormat>()
                        {
                            new ApiResponseFormat()
                            {
                                Formatter = context.Formatters.OfType<JsonOutputFormatter>().Single(),
                                MediaType = "application/problem+json",
                            },
                        },
                        ModelMetadata = context.MetadataProvider.GetMetadataForType(typeof(Problem)),
                        StatusCode = 404,
                        Type = typeof(Problem),
                    });
                }
            }

            context.Description.SupportedResponseTypes.Add(new ApiResponseType()
            {
                ApiResponseFormats = new List<ApiResponseFormat>()
                {
                    new ApiResponseFormat()
                    {
                        Formatter = context.Formatters.OfType<JsonOutputFormatter>().Single(),
                        MediaType = "application/problem+json",
                    },
                },
                ModelMetadata = context.MetadataProvider.GetMetadataForType(typeof(Problem)),
                StatusCode = -1,
                Type = typeof(Problem),
            });
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnException(ExceptionContext context)
        {
        }

        private bool IsClosestErrorPolicy(FilterContext context)
        {
            for (var i = context.Filters.Count - 1; i >= 0; i--)
            {
                if (context.Filters[i] is IErrorPolicy other)
                {
                    return object.ReferenceEquals(this, other);
                }
            }

            throw new InvalidOperationException("Unreachable.");
        }

        private enum ActionKind
        {

        }
    }
}
