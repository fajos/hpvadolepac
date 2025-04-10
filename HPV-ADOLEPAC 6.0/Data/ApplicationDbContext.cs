using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HPV_ADOLEPAC_6._0.Models;

namespace HPV_ADOLEPAC_6._0.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HPV_ADOLEPAC_6._0.Models.PostTestQuestions>? PostTestQuestions { get; set; }
        public DbSet<HPV_ADOLEPAC_6._0.Models.PostTestAnswer>? PostTestAnswer { get; set; }
        public DbSet<HPV_ADOLEPAC_6._0.Models.PreTestQuestions>? PreTestQuestions { get; set; }
        public DbSet<HPV_ADOLEPAC_6._0.Models.TestQuestions>? TestQuestions { get; set; }
        public DbSet<HPV_ADOLEPAC_6._0.Models.PreTestAnswers>? PreTestAnswer { get; set; }
        public DbSet<HPV_ADOLEPAC_6._0.Models.student>? student { get; set; }
        public DbSet<HPV_ADOLEPAC_6._0.Models.TestAnswers>? TestAnswers { get; set; }
    }
}