using Data.API;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data
{
    internal class Repository : IRepository
    {
        private CatalogDataContext context;
        private string connectionString = "Data Source=Laptop-omsm3ee0;Initial Catalog = Library; Integrated Security = True";

        internal Repository()
        {
            try
            {
                context = new CatalogDataContext(connectionString);
                context.books.Count();
            }
            catch(System.Exception)
            {
                throw new System.ArgumentException("Error occured during conncetion to the server. \n'" 
                                                   + connectionString + "' may not be a valid connection string.");
            }
        }


        public async Task<IBook> GetBook(int id)
        {
            return await Task.Run<IBook>(() => context.books.Where(b => b.id == id).FirstOrDefault());
        }
        public async Task<IEnumerable<IBook>> GetBooks()
        {
            return await Task.Run<IEnumerable<IBook>>(() => context.books);
        }
        public async Task AddBook(int id, string title, string author)
        {
            book _book = new book
            {
                id = id,
                title = title,
                author = author
            };
            await Task.Run(() => context.books.InsertOnSubmit(_book));
            await Task.Run(() => context.SubmitChanges());
        }
        public async Task UpdateBook(int id, string title, string author)
        {
            book _book = await Task.Run(() => context.books.Where(b => b.id == id).FirstOrDefault());
            _book.title = title;
            _book.author = author;
            await Task.Run(() => context.SubmitChanges());
        }
        public async Task DeleteBook(int id)
        {
            await Task.Run(() => context.books.DeleteOnSubmit(context.books.Where(b => b.id == id).FirstOrDefault()));
            await Task.Run(() => context.SubmitChanges());
        }

        public async Task<IState> GetState(int id)
        {
            return await Task.Run<IState>(() => context.states.Where(s => s.id == id).FirstOrDefault());
        }
        public async Task<IEnumerable<IState>> GetBookStates(int id)
        {
            return await Task.Run<IEnumerable<IState>>(() => context.states.Where(s => s.book_id == id));
        }
        public async Task<IEnumerable<IState>> GetStates()
        {
            return await Task.Run<IEnumerable<IState>>(() => context.states);
        }
        public async Task AddState(int id, int book_id, string available)
        {
            state _state = new state
            {
                id = id,
                book_id = book_id,
                available = available
            };
            await Task.Run(() => context.states.InsertOnSubmit(_state));
            await Task.Run(() => context.SubmitChanges());
        }
        public async Task UpdateState(int id, int book_id, string available)
        {
            state _state = await Task.Run(() => context.states.Where(s => s.id == id).FirstOrDefault());
            _state.book_id = book_id;
            _state.available = available;
            await Task.Run(() => context.SubmitChanges());
        }
        public async Task DeleteState(int id)
        {
            await Task.Run(() => context.states.DeleteOnSubmit(context.states.Where(s => s.id == id).FirstOrDefault()));
            await Task.Run(() => context.SubmitChanges());
        }
        public async Task<IUser> GetUser(int id)
        {
            return await Task.Run<IUser>(() => context.users.Where(u => u.id == id).FirstOrDefault());
        }
        public async Task<IEnumerable<IUser>> GetUsers()
        {
            return await Task.Run<IEnumerable<IUser>>(() => context.users);
        }
        public async Task AddUser(int id, string name, string surname)
        {
            user _user = new user
            {
                id = id,
                name = name,
                surname = surname
            };
            await Task.Run(() => context.users.InsertOnSubmit(_user));
            await Task.Run(() => context.SubmitChanges());
        }
        public async Task UpdateUser(int id, string name, string surname)
        {
            user _user = await Task.Run(() => context.users.Where(u => u.id == id).FirstOrDefault());
            _user.name = name;
            _user.surname = surname;
            await Task.Run(() => context.SubmitChanges());
        }
        public async Task DeleteUser(int id)
        {
            await Task.Run(() => context.users.DeleteOnSubmit(context.users.Where(u => u.id == id).FirstOrDefault()));
            await Task.Run(() => context.SubmitChanges());
        }

        public async Task<IEvent> GetEvent(int id)
        {
            return await Task.Run<IEvent>(() => context.events.Where(e => e.id == id).FirstOrDefault());
        }
        public async Task<IEnumerable<IEvent>> GetStateEvents(int id) 
        {
            return await Task.Run<IEnumerable<IEvent>>(() => context.events.Where(e => e.state_id == id));
        }
        public async Task<IEnumerable<IEvent>> GetUserEvents(int id)
        {
            return await Task.Run<IEnumerable<IEvent>>(() => context.events.Where(e => e.user_id == id));
        }
        public async Task<IEnumerable<IEvent>> GetEvents()
        {
            return await Task.Run<IEnumerable<IEvent>>(() => context.events);
        }
        public async Task AddEvent(int id, int state_id, int user_id, string type)
        {
            @event _event = new @event
            {
                id = id,
                state_id = state_id,
                user_id = user_id,
                type = type
            };
            await Task.Run(() => context.events.InsertOnSubmit(_event));
            await Task.Run(() => context.SubmitChanges());
        }
        public async Task UpdateEvent(int id, int state_id, int user_id, string type)
        {
            @event _event = await Task.Run(() => context.events.Where(e => e.id == id).FirstOrDefault());
            _event.state_id = state_id;
            _event.user_id = user_id;
            _event.type = type;
            await Task.Run(() => context.SubmitChanges());
        }
        public async Task DeleteEvent(int id)
        {
            await Task.Run(() => context.events.DeleteOnSubmit(context.events.Where(e => e.id == id).FirstOrDefault()));
        }
    }
}
