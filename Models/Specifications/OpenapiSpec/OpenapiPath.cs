namespace Speka.Models.Specifications.OpenapiSpec
{
    public class OpenapiPath
    {
        public OpenapiMethod? Get { get; set; }

        public OpenapiMethod? Post { get; set; }

        public OpenapiMethod? Put { get; set; }

        public OpenapiMethod? Delete { get; set; }

        public OpenapiMethod? Patch { get; set; }

        public OpenapiMethod? Head { get; set; }

        public OpenapiMethod? Options { get; set; }

        public OpenapiMethod? Trace { get; set; }

        public ICollection<OpenapiParameter>? Parameters { get; set; }
    }
}
