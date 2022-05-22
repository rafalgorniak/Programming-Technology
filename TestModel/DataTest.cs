using Data.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestModel
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void TestConnection()
        {
            IRepository repository = DataRepositoryFactory.CreateRepository();
            Thread.Sleep(1000);
            Assert.IsTrue(repository.GetBooks().Result.Count() > 0);
            Assert.IsTrue(repository.GetStates().Result.Count() > 0);
            Assert.IsTrue(repository.GetUsers().Result.Count() > 0);
            Assert.IsTrue(repository.GetEvents().Result.Count() > 0);
        }
    }
}