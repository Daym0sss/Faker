namespace SPP2.Generators
{
    public class DateTimeGenerate : IGenerate
    {
        public object GenerateValue()
        {
            var random = new Random();
            DateTime dt = new DateTime(2003, 9, 11);
            int countDays = (DateTime.Today - dt).Days;
            return dt.AddDays(random.Next(countDays));
        }

        public Type GetGeneratorType()
        {
            return typeof(DateTime);
        }
    }
}
