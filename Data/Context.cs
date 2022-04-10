using System.Collections.Generic;
using System.Linq;

namespace Data
{
    internal class Context
    {
        private Dictionary<string, Book> books;
        private List<User> users;
        private List<State> states;
        private List<Event> events;

        public Context(List<Book> books, List<User> users, List<State> states, List<Event> events)
        {
            this.books = new Dictionary<string, Book>();
            this.users = users;
            this.states = states;
            this.events = events;
            foreach (Book book in books)
            {
                this.books.Add(book.Id, book);
            }
        }

        internal void AddBook(string id, string title, string author)
        {
            Book book = new Book(id, title, author);
            books.Add(book.Id, book);
        }

        internal void addBookOccurrence(string bookNo, string id)
        {
            states.Add(new State(bookNo, books[id]));
        }

        internal void removeBookOccurence(string bookNo)
        {
            foreach (State state in states)
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
            foreach (State state in states)
            {
                if(state.BookId == id)
                {
                    result.Add(state.BookNo);
                }
            }
            return result;
        }
        internal void AddUser(string id, string name, string surname)
        {
            users.Add(new User(id, name, surname));
        }

        internal User GetUser(string id)
        {
            foreach (User user in users)
            {
                if (user.Id == id) return user;
            }
            return null;
        }

        internal void RemoveBook(string id)
        {
            books.Remove(id);
        }
        internal void RemoveUser(string id)
        {
            foreach (User user in users)
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
            foreach (User user in users)
            {
                if (user.Id == id) return true;
            }
            return false;
        }

        internal bool BookIsAvailible(string id)
        {
            foreach (State state in states)
            {
                if (state.BookId == id && state.IsAvailible)
                {
                    return true;
                }
            }
            return false;
        }

        internal void MakeBookAvailable(string bookNo, bool available)
        {
            foreach (State state in states)
            {
                if (state.BookNo == bookNo)
                {
                    state.MakeAvailable(available);
                    break;
                }
            }
        }

        internal void RentBook(string bookId, string userId)
        {
            foreach (State state in states)
            {
                if (state.BookId == bookId)
                {
                    events.Add(new Rental(state, GetUser(userId)));
                    break;
                }
            }
        }

        internal void ReturnBook(string bookNo, string userID)
        {
            foreach (State state in states)
            {
                if (state.BookNo == bookNo)
                {
                    events.Add(new Return(state, GetUser(userID)));
                }
            }
        }

        internal bool HasBook(string bookID, string userID)
        {
            int rentals = 0;
            int returns = 0;
            foreach (Rental rental in events.OfType<Rental>())
            {
                if (rental.BookId == bookID && rental.UserId == userID) rentals++;
            }
            foreach (Return @return in events.OfType<Return>())
            {
                if (@return.BookId == bookID && @return.UserId == userID) returns++;
            }
            return rentals != returns;
        }

        internal string WhichBookHas(string bookId, string userId)
        {
            foreach (Rental rental in events.OfType<Rental>())
            {
                if (rental.BookId == bookId && rental.UserId == userId && !rental.State.IsAvailible)
                {
                    return rental.State.BookNo;
                }
            }
            return null;
        }
    }
}
