namespace Data
{
    internal class State
    {
        private string bookNo;
        private Book book;
        private bool availible;

        internal State(string bookNo, Book book)
        {
            this.book = book;
            this.bookNo = bookNo;
            availible = true;
        }

        internal bool IsAvailible => availible;
        internal string BookId => book.Id;
        internal string BookNo => bookNo;

        internal void MakeAvailable(bool value) => availible = value;
    }
}
