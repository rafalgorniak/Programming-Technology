namespace Data
{
    public interface IEvent
    {
        IUser User { get; }
        IState State { get; }
    }

    public interface IRental : IEvent { }

    public interface IReturn : IEvent { }
}
