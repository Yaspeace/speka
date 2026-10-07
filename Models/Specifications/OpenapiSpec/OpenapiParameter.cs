using System;
using System.Collections.Generic;
using System.Text;

namespace Speka.Models.Specifications.OpenapiSpec
{
    public class OpenapiParameter
    {
        public required string Name { get; set; }

        public required string In { get; set; }

        public bool Required { get; set; }

        public required OpenapiSchemaObject Schema { get; set; }
    }
}
