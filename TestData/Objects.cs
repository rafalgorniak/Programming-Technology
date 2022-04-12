using Data;

namespace TestData
{
    internal class Book : IBook
    {
        internal Book(string id, string title, string author)
        {
            Id = id;
            Title = title;
            Author = author;
        }
        public string Id { get; }
        public string Title { get; }
        public string Author { get; }
    }
    internal class User : IUser
    {
        internal User(string id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }
        public string Id { get; }
        public string Name { get; }
        public string Surname { get; }
    }
    internal class State : IState
    {
        internal State(IBook book, string bookNo)
        {
            Available = true;
            BookNo = bookNo;
            Book = book;
        }
        public bool Available { get; set; }
        public IBook Book { get; }
        public string BookNo { get; }
    }
    internal class Rental : IRental
    {
        internal Rental(IUser user, IState state)
        {
            User = user;
            State = state;
        }
        public IUser User { get; }
        public IState State { get; }
    }
    internal class Return : IReturn
    {
        internal Return(IUser user, IState state)
        {
            User = user;
            State = state;
        }
        public IUser User { get; }
        public IState State { get; }
    }
}
