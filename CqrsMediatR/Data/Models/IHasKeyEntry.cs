namespace CqrsMediatR.Data
{
    public interface IHasKeyEntry<TKey>
    {
        TKey Id { get; set; }
    }
}
