using Service.API;

namespace TestViewModel
{
    internal class TestingBook : IModelBook
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
    }

    internal class TestingState : IModelState
    {
        public int id { get; set; }
        public int book_id { get; set; }
        public string available { get; set; }
    }

    internal class TestingUser : IModelUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
    }

    internal class TestingEvent : IModelEvent
    {
        public int id { get; set; }
        public int state_id { get; set; }
        public int user_id { get; set; }
        public string type { get; set; }
    }
}
