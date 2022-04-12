using System.Collections.Generic;
using System.Linq;

namespace Data
{
    internal class Context
    {
        private Dictionary<string, IBook> books;
        private List<IUser> users;
        private List<IState> states;
        private List<IEvent> events;

        internal Context(Dictionary<string, IBook> books, List<IUser> users, 
                       List<IState> states, List<IEvent> events)
        {
            this.books = books;
            this.users = users;
            this.states = states;
            this.events = events;
        }

        internal void AddBook(IBook book)
        {
            books.Add(book.Id, book);
        }

        internal void addBookOccurrence(IState state)
        {
            states.Add(state);
        }

        internal void removeBookOccurence(string bookNo)
        {
            foreach (IState state in states)
            {
                if (state.BookNo == bookNo)
                {
                    states.Remove(state);
                    break;
                }
            }
        }
        internal List<string> getBookOccurrences(string id)
        {
            List<string> result = new List<string>();
            foreach (IState state in states)
            {
                if(state.Book.Id == id)
                {
                    result.Add(state.BookNo);
                }
            }
            return result;
        }
        internal void AddUser(IUser user)
        {
            users.Add(user);
        }

        internal IUser GetUser(string id)
        {
            foreach (IUser user in users)
            {
                if (user.Id == id) return user;
            }
            return null;
        }

        internal IBook GetBook(string id) 
        {
            return books[id]; 
        }

        internal IState GetState(string no)
        {
            foreach (IState state in states)
            {
                if(state.BookNo == no)
                {
                    return state;
                }
            }
            return null;
        }

        internal void RemoveBook(string id)
        {
            books.Remove(id);
        }

        internal void RemoveUser(string id)
        {
            foreach (IUser user in users)
            {
                if (user.Id == id)
                {
                    users.Remove(user);
                    break;
                }
            }
        }
        internal bool BookExists(string id)
        {
            return books.ContainsKey(id);
        }

        internal bool UserExists(string id)
        {
            foreach (IUser user in users)
            {
                if (user.Id == id) return true;
            }
            return false;
        }

        internal bool BookIsAvailible(string id)
        {
            foreach (IState state in states)
            {
                if (state.Book.Id == id && state.Available)
                {
                    return true;
                }
            }
            return false;
        }

        internal void MakeBookAvailable(IState state, bool available)
        {
            state.Available = available;
        }

        internal void RentBook(IRental rental)
        {
            events.Add(rental);
        }

        internal void ReturnBook(IReturn @return)
        {
            events.Add(@return);
        }

        internal bool HasBook(string bookId, string userId)
        {
            if(events.OfType<IRental>() == null) return false;
            if (events.OfType<IReturn>() == null) return false;
            int rentals = 0;
            int returns = 0;
            foreach (IRental rental in events.OfType<IRental>())
            {
                if (rental.State.Book.Id == bookId && rental.User.Id == userId) rentals++;
            }
            foreach (IReturn @return in events.OfType<IReturn>())
            {
                if (@return.State.Book.Id == bookId && @return.User.Id == userId) returns++;
            }
            return rentals != returns;
        }

        internal IState WhichBookHas(string bookId, string userId)
        {
            foreach (IRental rental in events.OfType<IRental>())
            {
                if (rental.State.Book.Id == bookId && rental.User.Id == userId && !rental.State.Available)
                {
                    return rental.State;
                }
            }
            return null;
        }

        internal IState WhichBookIsAvailable(string bookId)
        {
            foreach (IState state in states)
            {
                if (state.Book.Id == bookId && state.Available)
                {
                    return state;
                }
            }
            return null;
        }
    }
}
