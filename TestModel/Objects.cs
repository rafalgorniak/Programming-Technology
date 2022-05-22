using Data.API;

namespace TestModel
{
    internal class TestingBook : IBook
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
    }

    internal class TestingState : IState
    {
        public int id { get; set; }
        public int book_id { get; set; }
        public string available { get; set; }
    }

    internal class TestingUser : IUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }

    internal class TestingEvent : IEvent
    {
        public int id { get; set; }
        public int state_id { get; set; }
        public int user_id { get; set; }
        public string type { get; set; }
    }
}
