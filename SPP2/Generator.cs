using SPP2.Generators;
using System.Reflection;

namespace SPP2
{
    public class Generator
    {
        private Dictionary<Type, IGenerate> generators = new Dictionary<Type, IGenerate>();
        public Generator()
        {
            generators.Add(typeof(int), new IntGenerate());
            generators.Add(typeof(DateTime), new DateTimeGenerate());
            generators.Add(typeof(float), new FloatGenerate());
            generators.Add(typeof(long), new LongGenerate());

            GetDllGenerators();
        }

        private void GetDllGenerators()
        {
            string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\lib\\");
            string[] libs = Directory.GetFiles(path, "*.dll");
            foreach (string dllPath in libs)
            {
                Assembly asm = Assembly.LoadFrom(dllPath);
                foreach (Type type in asm.GetExportedTypes())
                {
                    //Console.WriteLine(type);
                    if (type.IsClass && typeof(IGenerate).IsAssignableFrom(type))
                    {
                        IGenerate generator = (IGenerate)Activator.CreateInstance(type);
                        generators.Add(generator.GetGeneratorType(), generator);
                    }
                }
            }
        }

        public bool Exists(Type type) 
        {
            return generators.ContainsKey(type);
        }

        public object Generate(Type type) 
        { 
            return generators[type].GenerateValue();
        }
    }
}
