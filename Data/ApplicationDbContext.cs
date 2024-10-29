using DriveTech.Models;
using Microsoft.EntityFrameworkCore;

namespace DriveTech.Data
{
	public class ApplicationDbContext : DbContext
	{
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<ServicoModel> tb_servico {  get; set; }
        public DbSet<LoginModel> tb_login { get; set; }
    }
}
