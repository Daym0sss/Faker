using SPP2;

public class Program 
{
    static void Main()
    {
        var faker = new Faker();
        var result = faker.Create<TestStr>();    
    }

    struct TestStr
    {
        public int X;
        public int Y;
    }

}