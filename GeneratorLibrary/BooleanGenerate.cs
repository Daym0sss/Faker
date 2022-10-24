using SPP2.Generators;

namespace ClassLibrary2
{
    public class BooleanGenerate : IGenerate
    {
        public object GenerateValue()
        {
            return new Random().NextDouble() >= 0.5;
        }

        public Type GetGeneratorType()
        {
            return typeof(bool);
        }
    }
}
