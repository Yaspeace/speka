namespace Speka.Models.Specifications.OpenapiSpec
{
    public class OpenapiMethod
    {
        public required string OperationId { get; set; }

        public string? Summary { get; set; }

        public string? Description { get; set; }

        public ICollection<OpenapiParameter>? Parameters { get; set; }

        public OpenapiBody? RequestBody { get; set; }

        public Dictionary<string, OpenapiBody>? Responses { get; set; }

        public ICollection<Dictionary<string, object[]>>? Security { get; set; }

        public ICollection<string>? Tags { get; set; }
    }
}
