using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IRepository
    {
        Task<IBook> GetBook(int id);
        Task<IEnumerable<IBook>> GetBooks();
        Task AddBook(int id, string title, string author);
        Task UpdateBook(int id, string title, string author);
        Task DeleteBook(int id);
        Task<IState> GetState(int id);
        Task<IEnumerable<IState>> GetBookStates(int id);
        Task<IEnumerable<IState>> GetStates();
        Task AddState(int id, int book_id, string available);
        Task UpdateState(int id, int book_id, string available);
        Task DeleteState(int id);
        Task<IUser> GetUser(int id);
        Task<IEnumerable<IUser>> GetUsers();
        Task AddUser(int id, string name, string surname);
        Task UpdateUser(int id, string name, string surname);
        Task DeleteUser(int id);
        Task<IEvent> GetEvent(int id);
        Task<IEnumerable<IEvent>> GetStateEvents(int id);
        Task<IEnumerable<IEvent>> GetUserEvents(int id);
        Task<IEnumerable<IEvent>> GetEvents();
        Task AddEvent(int id, int state_id, int user_id, string type);
        Task UpdateEvent(int id, int state_id, int user_id, string type);
        Task DeleteEvent(int id); 
    }

    public abstract class DataRepositoryFactory
    {
        public static IRepository CreateRepository()
        {
            return new Repository();
        }
    }

    public interface IBook
    {
        int id { get; set; }
        string title { get; set; }
        string author { get; set; }
    }

    public interface IState
    {
        int id { get; set; }
        int book_id { get; set; }
        string available { get; set; }
    }

    public interface IUser
    {
        int id { get; set; }
        string name { get; set; }
        string surname { get; set; }
    }

    public interface IEvent
    {
        int id { get; set; }
        int state_id { get; set; }
        int user_id { get; set; }
        string type { get; set; }
    }
}
