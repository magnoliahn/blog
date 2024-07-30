using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace blog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Post> post { get; set; }
        public DbSet<Comments> comments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Prefeitura de Florianópolis", Content = "Topazio calça as ruas do rio vermelho pelo amor de deussss", Likes = 300},
                new Post { Id = 2, Title = "Lana del rey", Content = "Que melancolia é essa, vai pra terapia moça", Likes = 14 },
                new Post { Id = 3, Title = "Eu Amo Carne", Content = "Veganos obriagda por deixarem mais para nós HAHAYSAGDYUBGEDWUY", Likes = 56 }
                );
            modelBuilder.Entity<Comments>().HasData(
                new Comments { Id = 1, Name = "Topázio Pref.", Content = "Já tamo lá!", PostId = 1 },
                new Comments { Id = 2, Name = "I Love TS", Content = "Simm, por isso sou swiftie", PostId = 2 },
                new Comments { Id = 3, Name = "TheVeggieOne.", Content = "O preço que se paga por saber ler...", PostId = 3 }
                );
        }
    }
}
