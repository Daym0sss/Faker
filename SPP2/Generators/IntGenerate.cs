namespace SPP2.Generators
{
    public class IntGenerate : IGenerate
    {
        public object GenerateValue()
        {
            return new Random().Next();
        }

        public Type GetGeneratorType()
        {
            return typeof(int);
        }
    }
}
