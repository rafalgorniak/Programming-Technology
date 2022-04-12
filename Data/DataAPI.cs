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

            public override void AddBook(IBook book)
            {
                repository.Context.AddBook(book);
            }
            public override void AddUser(IUser user)
            {
                repository.Context.AddUser(user);
            }

            public override bool BookExists(string id)
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

            public override void RentElement(IRental rental)
            {
                repository.Context.RentBook(rental);
            }

            public override void ReturnElement(IReturn @return)
            {
                repository.Context.ReturnBook(@return);
            }

            public override bool UserExists(string id)
            {
                return repository.Context.UserExists(id);
            }
            public override bool HasBook(string bookId, string userId)
            {
                return repository.Context.HasBook(bookId, userId);
            }

            public override void MakeBookAvailable(IState state, bool available)
            {
                repository.Context.MakeBookAvailable(state, available);
            }

            public override void AddElementOccurrence(IState state)
            {
                repository.Context.addBookOccurrence(state);
            }

            public override void RemoveElementOccurrence(string bookNo)
            {
                repository.Context.removeBookOccurence(bookNo);
            }

            public override List<string> GetElementOccurrences(string id)
            {
                return repository.Context.getBookOccurrences(id);
            }
            public override IState WhichBookHas(string bookId, string userId)
            {
                return repository.Context.WhichBookHas(bookId, userId);
            }

            public override IState WhichBookIsAvailable(string bookId)
            {
                return repository.Context.WhichBookIsAvailable(bookId);
            }

            public override IState GetState(string no)
            {
                return repository.Context.GetState(no);
            }

            public override IBook GetBook(string id)
            {
                return repository.Context.GetBook(id);
            }

            public override IUser GetUser(string id)
            {
                return repository.Context.GetUser(id);
            }
        }

        public static AbstractDataAPI CreateDataLayer(IInitialiser initialiser = default(EmptyInitialiser))
        {
            return new DataLayer(initialiser == null ? new EmptyInitialiser() : initialiser);
        }

        public abstract void AddBook(IBook book);
        public abstract void RemoveElement(string id);
        public abstract void AddElementOccurrence(IState state);
        public abstract void RemoveElementOccurrence(string bookNo);
        public abstract List<string> GetElementOccurrences(string id);
        public abstract bool BookExists(string id);
        public abstract void AddUser(IUser user);
        public abstract void RemoveUser(string id);
        public abstract bool UserExists(string id);
        public abstract bool ElementIsAvailable(string id);
        public abstract void MakeBookAvailable(IState state, bool available);
        public abstract void RentElement(IRental rental);
        public abstract void ReturnElement(IReturn @return);
        public abstract bool HasBook(string bookId, string userId);
        public abstract IState WhichBookHas(string bookId, string userId);
        public abstract IState WhichBookIsAvailable(string bookId);
        public abstract IState GetState(string no);
        public abstract IBook GetBook(string id);
        public abstract IUser GetUser(string id);
    }
}
