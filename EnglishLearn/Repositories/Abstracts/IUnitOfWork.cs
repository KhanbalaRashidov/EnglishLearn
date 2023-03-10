namespace EnglishLearn.Repositories.Abstracts
{
    public interface IUnitOfWork : IDisposable
    {
        IEnglishRepository EnglishRepository { get; }
        int Save();
    }
}
