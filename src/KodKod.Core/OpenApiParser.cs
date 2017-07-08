using System;
using System.IO;
using System.Linq;
using YamlDotNet.Core;
using YamlDotNet.RepresentationModel;
using YamlDotNet.Serialization;

namespace KodKod
{
    public static class OpenApiParser
    {
        public static OpenApiDocument Parse(string filePath)
        {
            using (var reader = File.OpenText(filePath))
            {
                var builder = new DeserializerBuilder();

                var deserializer = builder.Build();

                var document = deserializer.Deserialize<OpenApiDocument>(reader);

                return document;
            }
        }
    }
}
