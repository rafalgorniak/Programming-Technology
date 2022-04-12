using Data;
using System.Collections.Generic;
using System.Xml;

namespace TestData
{
    internal class ConstantInitialiser : IInitialiser
    {
        private Dictionary<string, IBook> books = new Dictionary<string, IBook>();
        private List<IUser> users = new List<IUser>();
        private List<IState> states = new List<IState>();
        private List<IEvent> events = new List<IEvent>();

        internal ConstantInitialiser()
        {
            users.Add(new User("u01", "Gaius Julius", "Ceasar"));
            users.Add(new User("u02", "Gnaeus Pompeius", "Magnus"));
            users.Add(new User("u03", "Marcus Licinius", "Crassus"));

            books.Add("b01", new Book("b01", "Les Miserables", "Victor Hugo"));
            books.Add("b02", new Book("b02", "Pale Paryz", "Bruno Jasienski"));
            books.Add("b03", new Book("b03", "Ulysses", "James Joyce"));
            books.Add("b04", new Book("b04", "Der Process", "Franz Kafka"));

            foreach (Book book in books.Values)
            {
                states.Add(new State(book, book.Id + "/1"));
                states.Add(new State(book, book.Id + "/2"));
                states.Add(new State(book, book.Id + "/3"));
            }
        }

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
    internal class XmlInitialiser : IInitialiser
    {
        private Dictionary<string, IBook> books = new Dictionary<string, IBook>();
        private List<IUser> users = new List<IUser>();
        private List<IState> states = new List<IState>();
        private List<IEvent> events = new List<IEvent>();

        internal XmlInitialiser()
        {
            XmlDocument document = new XmlDocument();
            document.Load("../../../../TestData/Data.xml");
            XmlElement root = document.DocumentElement;
            XmlNode xmlBooks = root.ChildNodes[0];
            XmlNode xmlUsers = root.ChildNodes[1];
            XmlNode xmlStates = root.ChildNodes[2];
            XmlNode xmlEvents = root.ChildNodes[3];
            foreach (XmlNode xmlBook in xmlBooks.ChildNodes)
            {
                books.Add(xmlBook.ChildNodes[0].InnerText, new Book(xmlBook.ChildNodes[0].InnerText, xmlBook.ChildNodes[1].InnerText,
                                   xmlBook.ChildNodes[2].InnerText));
            }
            foreach (XmlNode xmlUser in xmlUsers.ChildNodes)
            {
                users.Add(new User(xmlUser.ChildNodes[0].InnerText, xmlUser.ChildNodes[1].InnerText,
                                   xmlUser.ChildNodes[2].InnerText));
            }
            foreach (XmlNode xmlState in xmlStates.ChildNodes)
            {
                foreach (Book book in books.Values)
                {
                    if (book.Id == xmlState.ChildNodes[0].InnerText)
                    {
                        states.Add(new State(book, xmlState.ChildNodes[1].InnerText));
                        break;
                    }
                }
            }
            foreach (XmlNode xmlEvent in xmlEvents.ChildNodes)
            {
                User eventUser = null;
                State eventState = null;
                foreach (User user in users)
                {
                    if (user.Id == xmlEvent.ChildNodes[1].InnerText)
                    {
                        eventUser = user;
                        break;
                    }
                }
                foreach (State state in states)
                {
                    if (state.BookNo == xmlEvent.ChildNodes[2].InnerText)
                    {
                        eventState = state;
                        break;
                    }
                }
                if (xmlEvent.ChildNodes[0].InnerText == "rental")
                {
                    events.Add(new Rental(eventUser, eventState));
                }
                else if (xmlEvent.ChildNodes[0].InnerText == "return")
                {
                    events.Add(new Return(eventUser, eventState));
                }
            }
        }
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
