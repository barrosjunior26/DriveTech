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
    }
}
