using FakerTests.TestClasses;
using SPP2;

namespace FakerTests
{
    [TestClass]
    public class UnitTestClass
    {
        private Faker faker = new();
        [TestMethod]
        public void CheckAllTypes()
        {
            var testClass = faker.Create<TestClassAllTypes>();

            Assert.IsTrue(testClass.ival != 0);
            Assert.IsTrue(testClass.lval != 0);
            Assert.IsTrue(testClass.isTrue == true || testClass.isTrue==false);
            Assert.IsTrue(testClass.fval != 0);
            Assert.IsTrue(testClass.dblVal != 0);
            Assert.IsTrue(testClass.str != null);
            Assert.IsTrue(DateTime.Compare(testClass.dt,new DateTime(2000,2,25))>0);
        }

        [TestMethod]
        public void CheckProperties()
        {
            var testClass = faker.Create<TestClassProperties>();

            Assert.IsTrue(testClass.strProp != null);
            Assert.IsTrue(testClass.intProp != 0);
        }

        [TestMethod]
        public void ClassWithInnerClass()
        {
            var testClass = faker.Create<ClassWithClassInside>();
            var testClassSimple = faker.Create<OneFieldClass>();

            Assert.IsTrue(testClassSimple.b != 0);
            Assert.IsTrue(testClass.a != 0);
            Assert.IsTrue(testClass.innerClass.b != 0);
        }

        [TestMethod]
        public void TripleEnclosure()
        {
            var classA= faker.Create<ClassA>();

            Assert.IsTrue(classA.B.C.cVal!=0);
        }        

        [TestMethod]
        public void ClassWithConstructor()
        {
            var class1 = faker.Create<ClassConstructedWithParameters>();

            Assert.IsTrue(class1.intVal != 0);
            Assert.IsTrue(class1.doubleVal != 0);
        }

    }
}