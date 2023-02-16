using Exo.WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Exo.WebApi.Context
{
    public class ProjectContext : DbContext
    {
            public ProjectContext()
            {
            }
            public ProjectContext(DbContextOptions<ProjectContext> options) : base(options)
            {
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseSqlServer("Data Source = DESKTOP-7IKBQ90\\SQLEXPRESS; initial catalog = Projetos;Integrated Security = true;Encrypt = False");
                }
            }
            public DbSet<Project> Projeto { get; set; }
            public DbSet<User> Usuario { get; set; }

    }
}
