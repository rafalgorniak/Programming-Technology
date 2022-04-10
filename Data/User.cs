namespace Data
{
    internal class User
    {
        private string id;
        private string name;
        private string surname;

        internal User(string id, string name, string surname)
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
        }

        internal string Id => id;
        internal string Name => name;
        internal string Surname => surname;
    }
}
