using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.Mvc.ApiExplorer
{
    public class ErrorPolicyApiDescriptionProvider : IApiDescriptionProvider
    {
        private readonly IOutputFormatter[] _formatters;
        private readonly IModelMetadataProvider _metadataProvider;

        public ErrorPolicyApiDescriptionProvider(
            IOptions<MvcOptions> optionsAccessor,
            IModelMetadataProvider metadataProvider)
        {
            _metadataProvider = metadataProvider;

            _formatters = optionsAccessor.Value.OutputFormatters.ToArray();
        }

        // Runs after the default provider, before any providers with default order.
        public int Order => -900;

        public void OnProvidersExecuting(ApiDescriptionProviderContext context)
        {
            for (var i = 0; i < context.Results.Count; i++)
            {
                var description = context.Results[i];
                var policy = FindErrorPolicy(description.ActionDescriptor);
                if (policy != null)
                {
                    policy.ApplyDescription(new ErrorPolicyContext(_formatters, _metadataProvider) { Description = description});
                }
            }
        }

        public void OnProvidersExecuted(ApiDescriptionProviderContext context)
        {
        }

        private IErrorPolicy FindErrorPolicy(ActionDescriptor action)
        {
            for (var i = action.FilterDescriptors.Count - 1; i >= 0; i--)
            {
                if (action.FilterDescriptors[i].Filter is IErrorPolicy policy)
                {
                    return policy;
                }
            }

            return null;
        }
    }
}
