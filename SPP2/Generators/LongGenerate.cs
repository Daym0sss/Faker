namespace SPP2.Generators
{
    public class LongGenerate : IGenerate
    {
        public object GenerateValue()
        {
            return new Random().NextInt64();
        }
        public Type GetGeneratorType()
        {
            return typeof(long);
        }
    }
}
