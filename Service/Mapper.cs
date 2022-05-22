using Data.API;
using Service.API;
using System.Collections.Generic;

namespace Service
{
    internal abstract class Mapper
    {
        internal static IEnumerable<IModelBook> MapBooks(IEnumerable<IBook> books)
        {
            List<IModelBook> booksList = new();
            foreach(var book in books)
            {
                booksList.Add(new ModelBook(book.id, book.title, book.author));
            }
            return booksList;
        }
        internal static IEnumerable<IModelState> MapStates(IEnumerable<IState> states)
        {
            List<IModelState> statesList = new();
            foreach (var state in states)
            {
                statesList.Add(new ModelState(state.id, state.book_id, state.available));
            }
            return statesList;
        }
        internal static IEnumerable<IModelUser> MapUsers(IEnumerable<IUser> users)
        {
            List<IModelUser> usersList = new();
            foreach (var user in users)
            {
                usersList.Add(new ModelUser(user.id, user.name, user.surname));
            }
            return usersList;
        }
        internal static IEnumerable<IModelEvent> MapEvents(IEnumerable<IEvent> events)
        {
            List<IModelEvent> eventsList = new();
            foreach (var @event in events)
            {
                eventsList.Add(new ModelEvent(@event.id, @event.state_id, @event.user_id, @event.type));
            }
            return eventsList;
        }
    }

    #region modelClasses
    internal class ModelBook : IModelBook
    {
        internal ModelBook(int id, string title, string author)
        {
            this.id = id;
            this.title = title;
            this.author = author;
        }
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
    }

    internal class ModelState : IModelState
    {
        internal ModelState(int id, int book_id, string available)
        {
            this.id = id;
            this.book_id = book_id;
            this.available = available;
        }
        public int id { get; set; }
        public int book_id { get; set; }
        public string available { get; set; }
    }

    internal class ModelUser : IModelUser
    {
        internal ModelUser(int id, string name, string surname)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
        }
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }

    internal class ModelEvent : IModelEvent
    {
        internal ModelEvent(int id, int state_id, int user_id, string type)
        {
            this.id = id;
            this.state_id = state_id;
            this.user_id = user_id;
            this.type = type;
        }
        public int id { get; set; }
        public int state_id { get; set; }
        public int user_id { get; set; }
        public string type { get; set; }
    }
    #endregion modelClasses
}
