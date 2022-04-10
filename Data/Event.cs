namespace Data
{
    internal abstract class Event
    {
        protected State state;
        protected User user;
        internal string BookId => state.BookId;
        internal string UserId => user.Id;
        internal State State => state;
    }

    internal class Rental : Event
    {
        internal Rental(State state, User user)
        {
            this.state = state;
            this.user = user;
        }
    }

    internal class Return : Event
    {
        internal Return(State state, User user)
        {
            this.state = state;
            this.user = user;
        }
    }
}
