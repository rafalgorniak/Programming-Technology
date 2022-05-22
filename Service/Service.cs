using Data.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    internal class DataService : IService
    {
        private IRepository repository;

        internal DataService(IRepository repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<IModelBook>> GetBooks()
        {
            return Mapper.MapBooks(await Task.Run(() => repository.GetBooks()));
        }
        public async Task AddBook(int id, string title, string author)
        {
            if ((await Task.Run(() => repository.GetBook(id))) != null)
            {
                throw new ArgumentException("Book with given id already exists");
            }
            await Task.Run(() => repository.AddBook(id, title, author));
        }
        public async Task UpdateBook(int id, string title, string author)
        {
            if (await Task.Run(() => repository.GetBook(id)) == null)
            {
                throw new ArgumentException("Book with given id does not exist");
            }
            await Task.Run(() => repository.UpdateBook(id, title, author));
        }
        public async Task DeleteBook(int id)
        {
            if (await Task.Run(() => repository.GetBook(id)) == null)
            {
                throw new ArgumentException("Book with given id does not exist");
            }
            if ((await Task.Run(() => repository.GetBookStates(id))).Count() > 0)
            {
                throw new ArgumentException("Book with given id has states");
            }
            await Task.Run(() => repository.DeleteBook(id));
        }

        public async Task<IEnumerable<IModelState>> GetStates()
        {
            return Mapper.MapStates(await Task.Run(() => repository.GetStates()));
        }
        public async Task AddState(int id, int book_id, string available)
        {
            if (await Task.Run(() => repository.GetState(id)) != null)
            {
                throw new ArgumentException("State with given id already exists");
            }
            if (await Task.Run(() => repository.GetBook(book_id)) == null)
            {
                throw new ArgumentException("Book with given id does not exist");
            }
            await Task.Run(() => repository.AddState(id, book_id, available));
        }
        public async Task UpdateState(int id, int book_id, string available)
        {
            if (await Task.Run(() => repository.GetState(id)) == null)
            {
                throw new ArgumentException("State with given id does not exist");
            }
            if (await Task.Run(() => repository.GetBook(book_id)) == null)
            {
                throw new ArgumentException("Book with given id does not exist");
            }
            await Task.Run(() => repository.UpdateState(id, book_id, available));
        }
        public async Task DeleteState(int id)
        {
            if (await Task.Run(() => repository.GetState(id)) == null)
            {
                throw new ArgumentException("State with given id does not exist");
            }
            if ((await Task.Run(() => repository.GetStateEvents(id))).Count() > 0)
            {
                throw new ArgumentException("State with given id has states");
            }
            await Task.Run(() => repository.DeleteState(id));
        }

        public async Task<IEnumerable<IModelUser>> GetUsers()
        {
            return Mapper.MapUsers(await Task.Run(() => repository.GetUsers()));
        }
        public async Task AddUser(int id, string name, string surname)
        {
            if (await Task.Run(() => repository.GetUser(id)) != null)
            {
                throw new ArgumentException("User with given id already exists");
            }
            await Task.Run(() => repository.AddUser(id, name, surname));
        }
        public async Task UpdateUser(int id, string name, string surname)
        {
            if (await Task.Run(() => repository.GetUser(id)) == null)
            {
                throw new ArgumentException("User with given id does not exist");
            }
            await Task.Run(() => repository.UpdateUser(id, name, surname));
        }
        public async Task DeleteUser(int id)
        {
            if (await Task.Run(() => repository.GetUser(id)) == null)
            {
                throw new ArgumentException("User with given id does not exist");
            }
            if ((await Task.Run(() => repository.GetUserEvents(id))).Count() > 0)
            {
                throw new ArgumentException("User with given id has events");
            }
            await Task.Run(() => repository.DeleteUser(id));
        }

        public async Task<IEnumerable<IModelEvent>> GetEvents()
        {
            return Mapper.MapEvents(await Task.Run(() => repository.GetEvents()));
        }
        public async Task AddEvent(int id, int state_id, int user_id, string type)
        {
            if (await Task.Run(() => repository.GetEvent(id)) != null)
            {
                throw new ArgumentException("Event with given id already exists");
            }
            if (await Task.Run(() => repository.GetState(state_id)) == null)
            {
                throw new ArgumentException("State with given id does not exist");
            }
            if (await Task.Run(() => repository.GetUser(user_id)) == null)
            {
                throw new ArgumentException("User with given id does not exist");
            }
            await Task.Run(() => repository.AddEvent(id, state_id, user_id, type));
        }
        public async Task UpdateEvent(int id, int state_id, int user_id, string type)
        {
            if (await Task.Run(() => repository.GetEvent(id)) != null)
            {
                throw new ArgumentException("Event with given id already exists");
            }
            if (await Task.Run(() => repository.GetState(state_id)) == null)
            {
                throw new ArgumentException("State with given id does not exist");
            }
            if (await Task.Run(() => repository.GetUser(user_id)) == null)
            {
                throw new ArgumentException("User with given id does not exist");
            }
            await Task.Run(() => repository.UpdateEvent(id, state_id, user_id, type));
        }
        public async Task DeleteEvent(int id)
        {
            if (await Task.Run(() => repository.GetEvent(id)) == null)
            {
                throw new ArgumentException("Event with given id does not exist");
            }
            await Task.Run(() => repository.DeleteEvent(id));
        }
    }
}
