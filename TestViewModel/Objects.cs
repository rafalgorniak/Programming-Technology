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

    internal class Filler
    {
        private List<TestingBook> testingBooks = new()
        {
            new TestingBook()
            {
                id = 1,
                title = "a",
                author = "a"
            },
            new TestingBook()
            {
                id = 2,
                title = "b",
                author = "b"
            },
        };
        private List<TestingState> testingStates = new()
        {
            new TestingState()
            {
                id = 1,
                book_id = 1,
                available = "1"
            },
            new TestingState()
            {
                id = 2,
                book_id = 1,
                available = "1"
            },
            new TestingState()
            {
                id = 3,
                book_id = 2,
                available = "1"
            }
        };
        private List<TestingUser> testingUsers = new()
        {
            new TestingUser()
            {
                id = 1,
                name = "A",
                surname = "A"
            }
        };
        private List<TestingEvent> testingEvents = new()
        {
            new TestingEvent()
            {
                id = 1,
                state_id = 1,
                user_id = 1,
                type = "Rental",
            },
            new TestingEvent()
            {
                id = 2,
                state_id = 1,
                user_id = 1,
                type = "Return",
            },
            new TestingEvent()
            {
                id = 3,
                state_id = 2,
                user_id = 1,
                type = "Rental",
            },
            new TestingEvent()
            {
                id = 4,
                state_id = 3,
                user_id = 1,
                type = "Rental",
            }
        };
        internal List<TestingBook> Books => testingBooks;
        internal List<TestingState> States => testingStates;
        internal List<TestingUser> Users => testingUsers;
        internal List<TestingEvent> Events => testingEvents;
    }
}
