namespace Data
{
    internal class Book
    {
        private string id;
        private string title;
        private string author;

        public Book(string id, string title, string author)
        {
            this.id = id;
            this.title = title;
            this.author = author;
        }

        internal string Id => id;
        internal string Title => title;
        internal string Author => author;
    }
}
