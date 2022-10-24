using SPP2.Generators;

namespace ClassLibrary2
{
    public class DoubleGenerate : IGenerate
    {
        public object GenerateValue()
        {
            var random = new Random();
            return random.NextDouble();
        }

        public Type GetGeneratorType()
        {
            return typeof(double);
        }
    }
}
