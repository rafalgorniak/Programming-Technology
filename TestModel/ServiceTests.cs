using Data.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Service.API;

namespace TestModel
{
    [TestClass]
    public class ServiceTest
    {
        private IRepository repository = Substitute.For<IRepository>();

        [TestMethod]
        public void TestBooks()
        {
            IService service = DataServiceFactory.CreateService(repository);
            repository.GetBooks().Returns(new List<TestingBook>());
            IEnumerable<IModelBook> books = service.GetBooks().Result;
            Assert.IsNotNull(books);
            service.AddBook(1, "a", "a");
            repository.GetBook(1).Returns(new TestingBook());
            service.UpdateBook(1, "b", "b");
            service.DeleteBook(1);
            service.AddBook(2, "c", "c");
            repository.GetBook(2).Returns(new TestingBook());
            service.UpdateBook(2, "d", "d");
            service.DeleteBook(2);
        }
        [TestMethod]
        public void TestStates()
        {
            IService service = DataServiceFactory.CreateService(repository);
            repository.GetStates().Returns(new List<TestingState>());
            IEnumerable<IModelState> states = service.GetStates().Result;
            Assert.IsNotNull(states);
            repository.GetBook(1).Returns(new TestingBook());
            repository.GetBook(2).Returns(new TestingBook());
            service.AddState(1, 1, "1");
            repository.GetState(1).Returns(new TestingState());
            service.UpdateState(1, 2, "1");
            service.DeleteState(1);
        }

        [TestMethod]
        public void TestUsers()
        {
            IService service = DataServiceFactory.CreateService(repository);
            repository.GetUsers().Returns(new List<TestingUser>());
            IEnumerable<IModelUser> users = service.GetUsers().Result;
            Assert.IsNotNull(users);
            service.AddUser(1, "a", "a");
            repository.GetUser(1).Returns(new TestingUser());
            service.UpdateUser(1, "b", "b");
            service.DeleteUser(1);
        }

        [TestMethod]
        public void TestEvents()
        {
            IService service = DataServiceFactory.CreateService(repository);
            repository.GetEvents().Returns(new List<TestingEvent>());
            IEnumerable<IModelEvent> events = service.GetEvents().Result;
            Assert.IsNotNull(events);
            repository.GetState(1).Returns(new TestingState());
            repository.GetUser(1).Returns(new TestingUser());
            service.AddEvent(1, 1, 1, "Rental");
            repository.GetEvent(1).Returns(new TestingEvent());
            service.UpdateEvent(1, 1, 1, "Return");
            service.DeleteEvent(1);
        }
    }
}
