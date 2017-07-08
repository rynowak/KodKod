using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KodKod;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace KodKodSample
{
    public class OpenApiConvention : IApplicationModelConvention
    {
        private readonly OpenApiDocument _document;

        public OpenApiConvention(OpenApiDocument document)
        {
            _document = document;
        }

        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                foreach (var action in controller.Actions)
                {
                    var path = AttributeRouteModel.CombineAttributeRouteModel(controller.Selectors.Single().AttributeRouteModel, action.Selectors.Single().AttributeRouteModel).Template;

                    var tokens = new Dictionary<string, string>()
                    {
                        { "controller", controller.ControllerName },
                        { "action", action.ActionName },
                    };

                    foreach (var kvp in controller.RouteValues)
                    {
                        tokens[kvp.Key] = kvp.Value;
                    }

                    foreach (var kvp in action.RouteValues)
                    {
                        tokens[kvp.Key] = kvp.Value;
                    }

                    path = AttributeRouteModel.ReplaceTokens(path, tokens);
                    if (path.Length >= 2 && path[0] == '~' && path[1] == '/')
                    {
                        path = path.Substring(1);
                    }
                    else if (path.Length == 0 || path[0] != '/')
                    {
                        path = "/" + path;
                    }

                    if (_document.Paths.TryGetValue(path, out var pathEntry))
                    {

                    }
                }
            }
        }
    }
}
