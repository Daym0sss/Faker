namespace SPP2.Generators
{
    public interface IGenerate
    {
        object GenerateValue();
        Type GetGeneratorType();
    }
}
