namespace Speka.Models.Specifications.OpenapiSpec
{
    public class OpenapiComponents
    {
        public Dictionary<string, OpenapiSchemaObject> Schemas { get; set; } = [];

        public Dictionary<string, OpenapiParameter> Parameters { get; set; } = [];
    }
}
