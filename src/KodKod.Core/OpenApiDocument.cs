using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;

namespace KodKod
{
    public class OpenApiDocument
    {
        [YamlMember(Alias = "components")]
        public IDictionary<object, object> Components { get; set; }

        [YamlMember(Alias = "info")]
        public object Info { get; set; }

        [YamlMember(Alias = "openapi")]
        public string OpenApi { get; set; }

        [YamlMember(Alias = "paths")]
        public Dictionary<string, OpenApiPath> Paths { get; set; }

        [YamlMember(Alias = "servers")]
        public List<object> Servers { get; set; }
    }

    public class OpenApiPath : Dictionary<string, OpenApiOperation>
    {
    }

    public class OpenApiOperation
    {
        [YamlMember(Alias = "operationId")]
        public string OperationId { get; set; }

        [YamlMember(Alias = "parameters")]
        public List<object> Parameters { get; set; }

        [YamlMember(Alias = "responses")]
        public Dictionary<string, object> Responses { get; set; }

        [YamlMember(Alias = "summary")]
        public string Summary { get; set; }

        [YamlMember(Alias = "tags")]
        public List<object> Tags { get; set; }
    }
}
