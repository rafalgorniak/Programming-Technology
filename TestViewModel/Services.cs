using Presentation;
using Service.API;

namespace TestViewModel
{
    internal class FirstTestingService : IService
    {
        private List<TestingBook> books = new();
        private List<TestingState> states = new();
        private List<TestingUser> users = new();
        private List<TestingEvent> events = new();

        internal FirstTestingService()
        {
            for(int i = 1; i < 10; i++)
            {
                var book = new TestingBook()
                {
                    id = i,
                    title = "a",
                    author = "a"
                };
                books.Add(book);
                var state = new TestingState()
                {
                    id = i,
                    book_id = i,
                    available = "1"
                };
                states.Add(state);
                var user = new TestingUser()
                {
                    id = i,
                    name = "a",
                    surname = "a"
                };
                users.Add(user);
                var @event = new TestingEvent()
                {
                    id = i,
                    state_id = i,
                    user_id = i,
                    type = "Rental"
                };
                events.Add(@event);
            }
        }

        public Task AddBook(int id, string title, string author)
        {
            var book = new TestingBook()
            {
                id = id,
                title = title,
                author = author
            };
            books.Add(book);
            return Task.CompletedTask;
        }

        public Task AddEvent(int id, int state_id, int user_id, string type)
        {
            return Task.CompletedTask;
        }

        public Task AddState(int id, int book_id, string available)
        {
            return Task.CompletedTask;
        }

        public Task AddUser(int id, string name, string surname)
        {
            return Task.CompletedTask;
        }

        public Task DeleteBook(int id)
        {
            return Task.CompletedTask;
        }

        public Task DeleteEvent(int id)
        {
            return Task.CompletedTask;
        }

        public Task DeleteState(int id)
        {
            return Task.CompletedTask;
        }

        public Task DeleteUser(int id)
        {
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<IModelBook>> GetBooks()
        {
            return books;
        }

        public async Task<IEnumerable<IModelEvent>> GetEvents()
        {
            return events;
        }

        public async Task<IEnumerable<IModelState>> GetStates()
        {
            return states;
        }

        public async Task<IEnumerable<IModelUser>> GetUsers()
        {
            return users;
        }

        public Task UpdateBook(int id, string title, string author)
        {
            return Task.CompletedTask;
        }

        public Task UpdateEvent(int id, int state_id, int user_id, string type)
        {
            return Task.CompletedTask;
        }

        public Task UpdateState(int id, int book_id, string available)
        {
            return Task.CompletedTask;
        }

        public Task UpdateUser(int id, string name, string surname)
        {
            return Task.CompletedTask;
        }
    }

    internal class SecondTestingService : IService
    {
        private List<TestingBook> books = new();
        private List<TestingState> states = new();
        private List<TestingUser> users = new();
        private List<TestingEvent> events = new();

        internal SecondTestingService()
        {

        }

        internal List<TestingBook> Books { set { books = value; } }
        internal List<TestingState> States { set { states = value; } }
        internal List<TestingUser> Users { set { users = value; } }
        internal List <TestingEvent> Events { set { events = value; } }

        public Task AddBook(int id, string title, string author)
        {
            return Task.CompletedTask;
        }

        public Task AddEvent(int id, int state_id, int user_id, string type)
        {
            return Task.CompletedTask;
        }

        public Task AddState(int id, int book_id, string available)
        {
            return Task.CompletedTask;
        }

        public Task AddUser(int id, string name, string surname)
        {
            return Task.CompletedTask;
        }

        public Task DeleteBook(int id)
        {
            return Task.CompletedTask;
        }

        public Task DeleteEvent(int id)
        {
            return Task.CompletedTask;
        }

        public Task DeleteState(int id)
        {
            return Task.CompletedTask;
        }

        public Task DeleteUser(int id)
        {
            return Task.CompletedTask;
        }

        public async Task<IEnumerable<IModelBook>> GetBooks()
        {
            return books;
        }

        public async Task<IEnumerable<IModelEvent>> GetEvents()
        {
            return events;
        }

        public async Task<IEnumerable<IModelState>> GetStates()
        {
            return states;
        }

        public async Task<IEnumerable<IModelUser>> GetUsers()
        {
            return users;
        }

        public Task UpdateBook(int id, string title, string author)
        {
            return Task.CompletedTask;
        }

        public Task UpdateEvent(int id, int state_id, int user_id, string type)
        {
            return Task.CompletedTask;
        }

        public Task UpdateState(int id, int book_id, string available)
        {
            return Task.CompletedTask;
        }

        public Task UpdateUser(int id, string name, string surname)
        {
            return Task.CompletedTask;
        }
    }
}
