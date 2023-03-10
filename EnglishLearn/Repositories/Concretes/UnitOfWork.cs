using EnglishLearn.Contexts;
using EnglishLearn.Repositories.Abstracts;

namespace EnglishLearn.Repositories.Concretes
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationContext _context;
        public UnitOfWork(ApplicationContext context)
        {
            _context=context;
            EnglishRepository = new EnglishRepository(context);
        }
        public IEnglishRepository EnglishRepository { get; private set; }
        public void Dispose()
        {
            _context.Dispose();
        }


        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
