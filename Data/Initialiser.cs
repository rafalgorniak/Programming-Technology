using System.Collections.Generic;

namespace Data
{
    public interface IInitialiser
    {
        Dictionary<string, IBook> InitialiseBooks();
        List<IUser> InitialiseUsers();
        List<IState> InitialiseStates();
        List<IEvent> InitialiseEvents();
    }

    internal class EmptyInitialiser : IInitialiser
    {
        private Dictionary<string, IBook> books = new Dictionary<string, IBook>();
        private List<IUser> users = new List<IUser>();
        private List<IState> states = new List<IState>();
        private List<IEvent> events = new List<IEvent>();
        
        public List<IEvent> InitialiseEvents()
        {
            return events;
        }

        public List<IState> InitialiseStates()
        {
            return states;
        }

        public List<IUser> InitialiseUsers()
        {
            return users;
        }

        public Dictionary<string, IBook> InitialiseBooks()
        {
            return books;
        }
    }
}
