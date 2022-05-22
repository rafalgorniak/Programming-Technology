using Microsoft.VisualStudio.TestTools.UnitTesting;
using Presentation;

namespace TestViewModel
{
    [TestClass]
    public class ViewModelTest
    {
        [TestMethod]
        public void TestFirstModel()
        {
            FirstTestingService service = new();
            Model model = new(service);
            ViewModel viewModel = new(model);
            Assert.AreEqual(viewModel.ModelBooks.Count(), 9);
            Assert.AreEqual(viewModel.ModelStates.Count(), 9);
            Assert.AreEqual(viewModel.ModelUsers.Count(), 9);
            Assert.AreEqual(viewModel.ModelEvents.Count(), 9);
        }

        [TestMethod]
        public void TestSecondModel()
        {
            Filler filler = new();
            SecondTestingService service = new()
            {
                Books = filler.Books,
                States = filler.States,
                Users = filler.Users,
                Events = filler.Events
            };
            Assert.AreEqual(service.GetEvents().Result.Count(), 4);
            Model model = new(service);
            ViewModel viewModel = new(model);
            Assert.AreEqual(viewModel.ModelBooks.Count(), 2);
            Assert.AreEqual(viewModel.ModelStates.Count(), 3);
            Assert.AreEqual(viewModel.ModelUsers.Count(), 1);
            Assert.AreEqual(viewModel.ModelEvents.Count(), 4);
        }
    }
}