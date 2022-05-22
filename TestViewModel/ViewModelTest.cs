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
            Task.Run(() => viewModel.AddBook());
            Assert.AreEqual(viewModel.ModelStates.Count(), 9);
            Assert.AreEqual(viewModel.ModelUsers.Count(), 9);
            Assert.AreEqual(viewModel.ModelEvents.Count(), 9);
        }
    }
}