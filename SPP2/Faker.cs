using System.Collections;
using System.Reflection;

namespace SPP2
{
    public class Faker
    {
        readonly Generator generator;
        private List<Type> types = new List<Type>();

        public Faker() 
        {
            generator = new Generator();
        }
        public T Create<T>() 
        {
            return (T)CreateDTO(typeof(T));
        }

        private object CreateObject(Type type)
        {
            try
            {
                var constructor = getConstructor(type.GetConstructors());
                var constructorParameters = constructor.GetParameters();
                List<object> creationParameters = new List<object>();

                if (constructorParameters.Count()>0)
                { 
                    foreach (var parameter in constructorParameters)
                    {
                        creationParameters.Add(CreateDTO(parameter.ParameterType));
                    }
                }
                return constructor.Invoke(creationParameters.ToArray());
            }
            catch
            {
                return Activator.CreateInstance(type);
            }
        }

        private ConstructorInfo? getConstructor(ConstructorInfo[] constructors)
        {
            if (constructors.Length > 1)
            {
                return constructors.OrderBy(c => c.GetParameters().Count()).First();
            }
            else return constructors.First();
        }

        private object CreateDTO(Type type) 
        {
            object result;
            Console.WriteLine(type);
            if (generator.Exists(type))
            {
                result = generator.Generate(type);
            }
            else 
            {
                if (type.IsGenericType)
                {
                    var genericType = type.GetGenericArguments()[0];
                    var listType = typeof(List<>).MakeGenericType(genericType);
                    var list = (IList)Activator.CreateInstance(listType);

                    for (int i = 0; i < 3; i++)
                    {
                        list.Add(CreateDTO(genericType));
                    }
                    result = Convert.ChangeType(list, listType);
                }
                else
                {
                    if (types.Contains(type))
                    {
                        return null;
                    }
                    else
                    {
                        types.Add(type); 
                        result = CreateObject(type);
                        GenerateFields(result);
                        types.Remove(type);
                    }
                }
            }
            Console.WriteLine(result);
            return result;
        }

        private void GenerateFields(object result) 
        {
            var type = result.GetType();
            var publicFields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            foreach (var field in publicFields)
            {
                try
                {
                    field.SetValue(result, CreateDTO(field.FieldType));
                }
                catch 
                {
                    field.SetValue(result, null);
                }
            }

            var properties = type.GetProperties();

            foreach (var property in properties) 
            {
                if (property.SetMethod != null) 
                {
                    try
                    {
                        property.SetValue(result, CreateDTO(property.PropertyType));
                    }
                    catch {
                        property.SetValue(result, null);
                    }
                }
            }
        }
    }
}
