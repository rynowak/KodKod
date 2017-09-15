// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KodKod
{
    public class ProblemDetailsApiDescriptionProvider : IApiDescriptionProvider
    {
        private readonly IModelMetadataProvider _modelMetadaProvider;

        public ProblemDetailsApiDescriptionProvider(IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadaProvider = modelMetadataProvider;
        }

        /// <remarks>
        /// The order is set to execute after the <see cref="DefaultApiDescriptionProvider"/>.
        /// </remarks>
        public int Order => -1000 + 10;

        public void OnProvidersExecuted(ApiDescriptionProviderContext context)
        {
        }

        public void OnProvidersExecuting(ApiDescriptionProviderContext context)
        {
            foreach (var apiDescription in context.Results)
            {
                var parameters = apiDescription.ActionDescriptor.Parameters.Concat(apiDescription.ActionDescriptor.BoundProperties);
                if (parameters.Any())
                {
                    apiDescription.SupportedResponseTypes.Add(CreateProblemResponse(StatusCodes.Status400BadRequest));

                    if (parameters.Any(p => p.Name.EndsWith("id", StringComparison.OrdinalIgnoreCase)))
                    {
                        apiDescription.SupportedResponseTypes.Add(CreateProblemResponse(StatusCodes.Status404NotFound));
                    }
                }
            }
        }

        private ApiResponseType CreateProblemResponse(int statusCode)
        {
            return new ApiResponseType
            {
                ApiResponseFormats = new List<ApiResponseFormat>
                {
                    new ApiResponseFormat
                    {
                        MediaType = "application/problem+json",
                    },
                    new ApiResponseFormat
                    {
                        MediaType = "application/problem+xml",
                    },
                },
                ModelMetadata = _modelMetadaProvider.GetMetadataForType(typeof(ProblemDetails)),
                StatusCode = statusCode,
                Type = typeof(ProblemDetails),
            };
        }
    }
}