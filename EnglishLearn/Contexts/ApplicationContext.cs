using EnglishLearn.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnglishLearn.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Vocabulary> Vocabularies { get; set; }
    }
}
