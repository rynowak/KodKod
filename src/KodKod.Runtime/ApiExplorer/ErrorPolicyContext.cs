
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Microsoft.AspNetCore.Mvc.ApiExplorer
{
    public class ErrorPolicyContext
    {
        public ErrorPolicyContext(IReadOnlyList<IOutputFormatter> formatters, IModelMetadataProvider metadataProvider)
        {
            Formatters = formatters;
            MetadataProvider = metadataProvider;
        }

        public ApiDescription Description { get; set; }

        public IReadOnlyList<IOutputFormatter> Formatters { get; }

        public IModelMetadataProvider MetadataProvider { get; }
    }
}
