namespace Data
{
    public interface IState
    {
        bool Available { get; set; }
        IBook Book { get; }
        string BookNo { get; }
    }
}
