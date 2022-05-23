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

        [TestMethod]
        public void TestViewModelSelectedProperties()
        {
            FirstTestingService service = new();
            Model model = new(service);
            ViewModel viewModel = new(model);

            Assert.IsNull(viewModel.SelectedBook);
            Assert.IsNull(viewModel.SelectedState);
            Assert.IsNull(viewModel.SelectedUser);
            Assert.IsNull(viewModel.SelectedEvent);
        }

        [TestMethod]
        public void TestViewModelMethods()
        {
            FirstTestingService service = new();
            Model model = new(service);
            ViewModel viewModel = new(model);

            Task.Run(() => viewModel.AddBook());
            Task.Run(() => viewModel.UpdateBook());
            Task.Run(() => viewModel.DeleteBook());
        }

        [TestMethod]
        public void TestViewModelCommandProperties()
        {
            FirstTestingService service = new();
            Model model = new(service);
            ViewModel viewModel = new(model);
            Assert.IsNotNull(viewModel.AddBookCommandProperty);
            Assert.IsNotNull(viewModel.UpdateBookCommandProperty);
            Assert.IsNotNull(viewModel.DeleteBookCommandProperty);

            Assert.IsNotNull(viewModel.AddStateCommandProperty);
            Assert.IsNotNull(viewModel.UpdateStateCommandProperty);
            Assert.IsNotNull(viewModel.DeleteStateCommandProperty);

            Assert.IsNotNull(viewModel.AddUserCommandProperty);
            Assert.IsNotNull(viewModel.UpdateUserCommandProperty);
            Assert.IsNotNull(viewModel.DeleteUserCommandProperty);

            Assert.IsNotNull(viewModel.AddEventCommandProperty);
            Assert.IsNotNull(viewModel.UpdateEventCommandProperty);
            Assert.IsNotNull(viewModel.DeleteEventCommandProperty);

            Assert.IsFalse(viewModel.AddBookCommandProperty.CanExecute(null));
        }
    }
}