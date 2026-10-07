namespace Speka.Models.Specifications.OpenapiSpec
{
    public class OpenapiBody
    {
        public string? Description { get; set; }

        public Dictionary<string, OpenapiResponseContent>? Content { get; set; }
    }
}
