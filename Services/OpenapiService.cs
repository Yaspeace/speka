using Speka.Models.Specifications.OpenapiSpec;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Speka.Services
{
    public class OpenapiService
    {
        public OpenapiSchema ReadSchemaFromFile(string path)
        {
            var deser = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .IgnoreUnmatchedProperties()
                .Build();

            var fs = File.OpenRead(path);
            var schema = deser.Deserialize<OpenapiSchema>(new StreamReader(fs));
            fs.Close();

            return schema;
        }
    }
}
