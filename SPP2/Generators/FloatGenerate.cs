namespace SPP2.Generators
{
    public class FloatGenerate : IGenerate
    {
        public object GenerateValue()
        {
            double range = float.MaxValue - float.MinValue;
            double baseNum = new Random().NextDouble();
            return (float)(baseNum * range + float.MaxValue);
        }

        public Type GetGeneratorType()
        {
            return typeof(float);
        }
    }
}
