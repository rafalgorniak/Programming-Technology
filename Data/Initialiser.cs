using System.Collections.Generic;
using System.Xml;

namespace Data
{
    internal interface IInitialiser
    {
        List<Book> InitialiseBooks();
        List<User> InitialiseUsers();
        List<State> InitialiseStates();
        List<Event> InitialiseEvents();
    }

    internal class EmptyInitialiser : IInitialiser
    {
        private List<Book> books = new List<Book>();
        private List<User> users = new List<User>();
        private List<State> states = new List<State>();
        private List<Event> events = new List<Event>();
        
        public List<Event> InitialiseEvents()
        {
            return events;
        }

        public List<State> InitialiseStates()
        {
            return states;
        }

        public List<User> InitialiseUsers()
        {
            return users;
        }

        public List<Book> InitialiseBooks()
        {
            return books;
        }
    }

    internal class ConstantInitialiser : IInitialiser
    {
        private List<Book> books = new List<Book>();
        private List<User> users = new List<User>();
        private List<State> states = new List<State>();
        private List<Event> events = new List<Event>();

        internal ConstantInitialiser()
        {
            users.Add(new User("u01", "Gaius Julius", "Ceasar"));
            users.Add(new User("u02", "Gnaeus Pompeius", "Magnus"));
            users.Add(new User("u03", "Marcus Licinius", "Crassus"));

            books.Add(new Book("b01", "Les Miserables", "Victor Hugo"));
            books.Add(new Book("b02", "Pale Paryz", "Bruno Jasienski"));
            books.Add(new Book("b03", "Ulysses", "James Joyce"));
            books.Add(new Book("b04", "Der Process", "Franz Kafka"));

            foreach (Book book in books)
            {
                states.Add(new State(book.Id + "/1", book));
                states.Add(new State(book.Id + "/2", book));
                states.Add(new State(book.Id + "/3", book));
            }
        }

        public List<Event> InitialiseEvents()
        {
            return events;
        }

        public List<State> InitialiseStates()
        {
            return states;
        }

        public List<User> InitialiseUsers()
        {
            return users;
        }

        public List<Book> InitialiseBooks()
        {
            return books;
        }
    }
    internal class XmlInitialiser : IInitialiser
    {
        private List<Book> books = new List<Book>();
        private List<User> users = new List<User>();
        private List<State> states = new List<State>();
        private List<Event> events = new List<Event>();

        internal XmlInitialiser()
        {
            XmlDocument document = new XmlDocument();
            document.Load("../../../../Data/Data.xml");
            XmlElement root = document.DocumentElement;
            XmlNode xmlBooks = root.ChildNodes[0];
            XmlNode xmlUsers = root.ChildNodes[1];
            XmlNode xmlStates = root.ChildNodes[2];
            XmlNode xmlEvents = root.ChildNodes[3];
            foreach(XmlNode xmlBook in xmlBooks.ChildNodes)
            {
                books.Add(new Book(xmlBook.ChildNodes[0].InnerText, xmlBook.ChildNodes[1].InnerText,
                                   xmlBook.ChildNodes[2].InnerText));
            }
            foreach (XmlNode xmlUser in xmlUsers.ChildNodes)
            {
                users.Add(new User(xmlUser.ChildNodes[0].InnerText, xmlUser.ChildNodes[1].InnerText,
                                   xmlUser.ChildNodes[2].InnerText));
            }
            foreach (XmlNode xmlState in xmlStates.ChildNodes)
            {
                foreach(Book book in books)
                {
                    if(book.Id == xmlState.ChildNodes[0].InnerText)
                    {
                        states.Add(new State(xmlState.ChildNodes[1].InnerText, book));
                        break;
                    }
                }
            }
            foreach (XmlNode xmlEvent in xmlEvents.ChildNodes)
            {
                User eventUser = null;
                State eventState = null;
                foreach(User user in users)
                {
                    if(user.Id == xmlEvent.ChildNodes[1].InnerText)
                    {
                        eventUser = user;
                        break;
                    }
                }
                foreach(State state in states)
                {
                    if(state.BookNo == xmlEvent.ChildNodes[2].InnerText)
                    {
                        eventState = state;
                        break;
                    }
                }
                if (xmlEvent.ChildNodes[0].InnerText == "rental")
                {
                    events.Add(new Rental(eventState, eventUser));
                }
                else if (xmlEvent.ChildNodes[0].InnerText == "return")
                {
                    events.Add(new Return(eventState, eventUser));
                }
            }
        }



        public List<Event> InitialiseEvents()
        {
            return events;
        }

        public List<State> InitialiseStates()
        {
            return states;
        }

        public List<User> InitialiseUsers()
        {
            return users;
        }

        public List<Book> InitialiseBooks()
        {
            return books;
        }
    }
}
