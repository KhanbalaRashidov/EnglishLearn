using EnglishLearn.Contexts;
using EnglishLearn.Entities;
using EnglishLearn.Repositories.Abstracts;

namespace EnglishLearn.Repositories.Concretes
{
    public class EnglishRepository:RepositoryBase<Vocabulary>,IEnglishRepository
    {
        public EnglishRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
