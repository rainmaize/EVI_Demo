namespace mvcbasic.Data

{
    using mvc.Models;
    using Microsoft.EntityFrameworkCore;
 
    public class MvcBasicDbContext : DbContext
    {
        public MvcBasicDbContext(DbContextOptions<MvcBasicDbContext> options) : base(options)
        {
        }
 
        public DbSet<Config> Configs { get; set; }
        public DbSet<Recruitment_plan> Recruitment_Plans {get;set;}
    }
}