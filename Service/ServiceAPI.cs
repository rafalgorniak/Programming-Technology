using Data.API;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.API
{
    public interface IService
    {
        Task AddBook(int id, string title, string author);
        Task AddEvent(int id, int state_id, int user_id, string type);
        Task AddState(int id, int book_id, string available);
        Task AddUser(int id, string name, string surname);
        Task DeleteBook(int id);
        Task DeleteEvent(int id);
        Task DeleteState(int id);
        Task DeleteUser(int id);
        Task<IEnumerable<IModelBook>> GetBooks();
        Task<IEnumerable<IModelEvent>> GetEvents();
        Task<IEnumerable<IModelState>> GetStates();
        Task<IEnumerable<IModelUser>> GetUsers();
        Task UpdateBook(int id, string title, string author);
        Task UpdateEvent(int id, int state_id, int user_id, string type);
        Task UpdateState(int id, int book_id, string available);
        Task UpdateUser(int id, string name, string surname);
    }

    public interface IModelBook
    {
        int id { get; set; }
        string title { get; set; }
        string author { get; set; }
    }
    public interface IModelState
    {
        int id { get; set; }
        int book_id { get; set; }
        string available { get; set; }
    }

    public interface IModelUser
    {
        int id { get; set; }
        string name { get; set; }
        string surname { get; set; }
    }

    public interface IModelEvent
    {
        int id { get; set; }
        int state_id { get; set; }
        int user_id { get; set; }
        string type { get; set; }
    }

    public abstract class DataServiceFactory
    {
        public static IService CreateService(IRepository repository = default)
        {
            return new DataService(repository ?? DataRepositoryFactory.CreateRepository());
        }
    }
}
