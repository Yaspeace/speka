using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;

namespace Speka.Models.Specifications.OpenapiSpec
{
    public class OpenapiSchemaObject
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Type { get; set; }

        public string? Format { get; set; }

        [YamlMember(Alias = "$ref")]
        public string? Ref { get; set; }

        public Dictionary<string, OpenapiSchemaObject>? Properties { get; set; }

        public ICollection<OpenapiSchemaObject>? AllOf { get; set; }
    }
}
