using Service.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;


namespace Presentation
{
    public class ViewModel : INotifyPropertyChanged
    {
        private IModel model;

        public ViewModel(IModel model)
        {
            this.model = model;
            addBookCommand = new(this);
            updateBookCommand = new(this);
            deleteBookCommand = new(this);
            addStateCommand = new(this);
            updateStateCommand = new(this);
            deleteStateCommand = new(this);
            addUserCommand = new(this);
            updateUserCommand = new(this);
            deleteUserCommand = new(this);
            addEventCommand = new(this);
            updateEventCommand = new(this);
            deleteEventCommand = new(this);
            Task.Run(() => RefreshBooks());
            Thread.Sleep(100);
            Task.Run(() => RefreshStates());
            Thread.Sleep(100);
            Task.Run(() => RefreshUsers());
            Thread.Sleep(100);
            Task.Run(() => RefreshEvents());
            Thread.Sleep(100);
        }

        #region modelBooks
        private IEnumerable<IModelBook> modelBooks;
        public IEnumerable<IModelBook> ModelBooks
        {
            get
            {
                return modelBooks;
            }
            set
            {
                modelBooks = value;
            }
        }
        private IModelBook selectedBook;
        public IModelBook SelectedBook
        {
            get
            {
                return selectedBook;
            }
            set
            {
                selectedBook = value;
                OnPropertyChanged("SelectedBook");
            }
        }
        private async Task RefreshBooks()
        {
            ModelBooks = await Task.Run(() => model.Service.GetBooks());
        }
        public async Task AddBook()
        {
            try
            {
                await Task.Run(() => model.Service.AddBook(SelectedBook.id, SelectedBook.title, SelectedBook.author));
                await Task.Run(() => RefreshBooks());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public async Task UpdateBook()
        {
            try
            {
                await Task.Run(() => model.Service.UpdateBook(SelectedBook.id, SelectedBook.title, SelectedBook.author));
                await Task.Run(() => RefreshBooks());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public async Task DeleteBook()
        {
            try
            {
                await Task.Run(() => model.Service.DeleteBook(SelectedBook.id));
                await Task.Run(() => RefreshBooks());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion modelBooks

        #region modelStates
        private IEnumerable<IModelState> modelStates;

        public IEnumerable<IModelState> ModelStates
        {
            get
            {
                return modelStates;
            }
            set
            {
                modelStates = value;
            }
        }

        private IModelState selectedState;

        public IModelState SelectedState
        {
            get
            {
                return selectedState;
            }
            set
            {
                selectedState = value;
                OnPropertyChanged("SelectedState");
            }
        }
        private async Task RefreshStates()
        {
            ModelStates = await Task.Run(() => model.Service.GetStates());
        }
        public async Task AddState()
        {
            try
            {
                await Task.Run(() => model.Service.AddState(SelectedState.id, SelectedState.book_id, SelectedState.available));
                await Task.Run(() => RefreshStates());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public async Task UpdateState()
        {
            try
            {
                await Task.Run(() => model.Service.UpdateState(SelectedState.id, SelectedState.book_id, SelectedState.available));
                await Task.Run(() => RefreshStates());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public async Task DeleteState()
        {
            try
            {
                await Task.Run(() => model.Service.DeleteState(SelectedState.id));
                await Task.Run(() => RefreshStates());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion modelStates

        #region modelUsers
        private IEnumerable<IModelUser> modelUsers;
        public IEnumerable<IModelUser> ModelUsers
        {
            get { return modelUsers; }
            set { modelUsers = value; }
        }
        private IModelUser selectedUser;
        public IModelUser SelectedUser
        {
            get
            {
                return selectedUser;
            }
            set
            {
                selectedUser = value;
                OnPropertyChanged("SelectedUser");
            }
        }
        private async Task RefreshUsers()
        {
            ModelUsers = await Task.Run(() => model.Service.GetUsers());
        }
        public async Task AddUser()
        {
            try
            {
                await Task.Run(() => model.Service.AddUser(SelectedUser.id, SelectedUser.name, SelectedUser.surname));
                await Task.Run(() => RefreshUsers());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public async Task UpdateUser()
        {
            try
            {
                await Task.Run(() => model.Service.UpdateBook(SelectedUser.id, SelectedUser.name, SelectedUser.surname));
                await Task.Run(() => RefreshUsers());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public async Task DeleteUser()
        {
            try
            {
                await Task.Run(() => model.Service.DeleteUser(SelectedUser.id));
                await Task.Run(() => RefreshUsers());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion modelUsers

        #region modelEvents
        private IEnumerable<IModelEvent> modelEvents;
        public IEnumerable<IModelEvent> ModelEvents
        {
            get { return modelEvents; }
            set { modelEvents = value; }
        }
        private IModelEvent selectedEvent;
        public IModelEvent SelectedEvent
        {
            get
            {
                return selectedEvent;
            }
            set
            {
                selectedEvent = value;
                OnPropertyChanged("SelectedEvent");
            }
        }
        private async Task RefreshEvents()
        {
            ModelEvents = await Task.Run(() => model.Service.GetEvents());
        }
        public async Task AddEvent()
        {
            try
            {
                await Task.Run(() => model.Service.AddEvent(SelectedEvent.id, SelectedEvent.state_id, SelectedEvent.user_id, SelectedEvent.type));
                await Task.Run(() => RefreshEvents());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public async Task UpdateEvent()
        {
            try
            {
                await Task.Run(() => model.Service.UpdateEvent(SelectedEvent.id, SelectedEvent.state_id, SelectedEvent.user_id, SelectedEvent.type));
                await Task.Run(() => RefreshEvents());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public async Task DeleteEvent()
        {
            try
            {
                await Task.Run(() => model.Service.DeleteEvent(SelectedEvent.id));
                await Task.Run(() => RefreshEvents());
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        #endregion modelEvents

        #region bookCommands
        private AddBookCommand addBookCommand;
        public AddBookCommand AddBookCommandProperty => addBookCommand;
        public class AddBookCommand : ICommand
        {
            private ViewModel viewModel;

            public AddBookCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedBook != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.AddBook());
            }
        }

        private UpdateBookCommand updateBookCommand;
        public UpdateBookCommand UpdateBookCommandProperty => updateBookCommand;
        public class UpdateBookCommand : ICommand
        {
            private ViewModel viewModel;

            public UpdateBookCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedBook != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.UpdateBook());
            }
        }

        private DeleteBookCommand deleteBookCommand;
        public DeleteBookCommand DeleteBookCommandProperty => deleteBookCommand;
        public class DeleteBookCommand : ICommand
        {
            private ViewModel viewModel;

            public DeleteBookCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedBook != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.DeleteBook());
            }
        }
        #endregion bookCommands

        #region stateCommands

        private AddStateCommand addStateCommand;
        public AddStateCommand AddStateCommandProperty => addStateCommand;
        public class AddStateCommand : ICommand
        {
            private ViewModel viewModel;

            public AddStateCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedState != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.AddState());
            }
        }

        private UpdateStateCommand updateStateCommand;
        public UpdateStateCommand UpdateStateCommandProperty => updateStateCommand;
        public class UpdateStateCommand : ICommand
        {
            private ViewModel viewModel;

            public UpdateStateCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedState != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.UpdateState());
            }
        }

        private DeleteBookCommand deleteStateCommand;
        public DeleteBookCommand DeleteStateCommandProperty => deleteStateCommand;
        public class DeleteStateCommand : ICommand
        {
            private ViewModel viewModel;

            public DeleteStateCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedState != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.DeleteState());
            }
        }
        #endregion stateCommands

        #region userCommands
        private AddUserCommand addUserCommand;
        public AddUserCommand AddUserCommandProperty => addUserCommand;
        public class AddUserCommand : ICommand
        {
            private ViewModel viewModel;

            public AddUserCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedUser != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.AddUser());
            }
        }

        private UpdateUserCommand updateUserCommand;
        public UpdateUserCommand UpdateUserCommandProperty => updateUserCommand;
        public class UpdateUserCommand : ICommand
        {
            private ViewModel viewModel;

            public UpdateUserCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedUser != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.UpdateUser());
            }
        }

        private DeleteUserCommand deleteUserCommand;
        public DeleteUserCommand DeleteUserCommandProperty => deleteUserCommand;
        public class DeleteUserCommand : ICommand
        {
            private ViewModel viewModel;

            public DeleteUserCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedUser != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.DeleteUser());
            }
        }
        #endregion userCommands

        #region eventCommands
        private AddEventCommand addEventCommand;
        public AddEventCommand AddEventCommandProperty => addEventCommand;
        public class AddEventCommand : ICommand
        {
            private ViewModel viewModel;

            public AddEventCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedEvent != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.AddEvent());
            }
        }

        private UpdateEventCommand updateEventCommand;
        public UpdateEventCommand UpdateEventCommandProperty => updateEventCommand;
        public class UpdateEventCommand : ICommand
        {
            private ViewModel viewModel;

            public UpdateEventCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedEvent != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.UpdateEvent());
            }
        }

        private DeleteEventCommand deleteEventCommand;
        public DeleteEventCommand DeleteEventCommandProperty => deleteEventCommand;
        public class DeleteEventCommand : ICommand
        {
            private ViewModel viewModel;

            public DeleteEventCommand(ViewModel viewModel)
            {
                this.viewModel = viewModel;
                this.viewModel.PropertyChanged += (s, e) =>
                {
                    if (this.CanExecute != null)
                    {
                        CanExecuteChanged(this, new EventArgs());
                    }
                };
            }

            public bool CanExecute(object parameter)
            {
                return viewModel.SelectedEvent != null;
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                Task.Run(() => viewModel.DeleteEvent());
            }
        }
        #endregion userCommands

        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
