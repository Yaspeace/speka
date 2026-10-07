namespace Speka.Models.Specifications.OpenapiSpec
{
    public class OpenapiSchema
    {
        public required string Openapi { get; set; }

        public required OpenapiInfo Info { get; set; }

        public OpenapiServer[] Servers { get; set; } = [];

        public ICollection<OpenapiTag>? Tags { get; set; }

        public Dictionary<string, OpenapiPath>? Paths { get; set; }

        public OpenapiComponents Components { get; set; } = new();
    }
}
