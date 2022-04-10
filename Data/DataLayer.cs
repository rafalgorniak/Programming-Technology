using System.Collections.Generic;

namespace Data
{
    public abstract class AbstractDataAPI
    {
        private Repository repository;

        private class DataLayer : AbstractDataAPI
        {
            public DataLayer(IInitialiser initialiser)
            {
                repository = new Repository(initialiser);
            }

            public override void AddElement(string id, string title, string author)
            {
                repository.Context.AddBook(id, title, author);
            }
            public override void AddUser(string id, string name, string surname)
            {
                repository.Context.AddUser(id, name, surname);
            }

            public override bool ElementExists(string id)
            {
                return repository.Context.BookExists(id);
            }

            public override bool ElementIsAvailable(string id)
            {
                return repository.Context.BookIsAvailible(id);
            }

            public override void RemoveElement(string id)
            {
                repository.Context.RemoveBook(id);
            }

            public override void RemoveUser(string id)
            {
                repository.Context.RemoveUser(id);
            }

            public override void RentElement(string elementId, string userId)
            {
                repository.Context.RentBook(elementId, userId);
            }

            public override void ReturnElement(string bookNo, string userId)
            {
                repository.Context.ReturnBook(bookNo, userId);
            }

            public override bool UserExists(string id)
            {
                return repository.Context.UserExists(id);
            }
            public override bool HasBook(string bookId, string userId)
            {
                return repository.Context.HasBook(bookId, userId);
            }

            public override void MakeElementAvailable(string id, bool available)
            {
                repository.Context.MakeBookAvailable(id, available);
            }

            public override void AddElementOccurrence(string bookNo, string id)
            {
                repository.Context.addBookOccurrence(bookNo, id);
            }

            public override void RemoveElementOccurrence(string bookNo)
            {
                repository.Context.removeBookOccurence(bookNo);
            }

            public override List<string> GetElementOccurrences(string id)
            {
                return repository.Context.getBookOccurrences(id);
            }
            public override string WhichBookHas(string bookId, string userId)
            {
                return repository.Context.WhichBookHas(bookId, userId);
            }
        }

        public static AbstractDataAPI CreateDataLayerEmpty()
        {
            return new DataLayer(new EmptyInitialiser());
        }

        public static AbstractDataAPI CreateDataLayerConstant()
        {
            return new DataLayer(new ConstantInitialiser());
        }

        public static AbstractDataAPI CreateDataLayerXml()
        {
            return new DataLayer(new XmlInitialiser());
        }

        public abstract void AddElement(string id, string title, string author);
        public abstract void RemoveElement(string id);
        public abstract void AddElementOccurrence(string bookNo, string id);
        public abstract void RemoveElementOccurrence(string bookNo);
        public abstract List<string> GetElementOccurrences(string id);
        public abstract bool ElementExists(string id);
        public abstract void AddUser(string id, string name, string surname);
        public abstract void RemoveUser(string id);
        public abstract bool UserExists(string id);
        public abstract bool ElementIsAvailable(string id);
        public abstract void MakeElementAvailable(string bookNo, bool available);
        public abstract void RentElement(string elementId, string userId);
        public abstract void ReturnElement(string bookNo, string userId);
        public abstract bool HasBook(string bookId, string userId);
        public abstract string WhichBookHas(string bookId, string userId);  
    }
}
