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
                new Post { PostId = 1, PostTitle = "Prefeitura de Florianópolis", PostContent = "Topazio calça as ruas do rio vermelho pelo amor de deussss", PostLikes = 300},
                new Post { PostId = 2, PostTitle = "Lana del rey", PostContent = "Que melancolia é essa, vai pra terapia moça", PostLikes = 14 },
                new Post { PostId = 3, PostTitle = "Eu Amo Carne", PostContent = "Veganos obriagda por deixarem mais para nósHAHAHA", PostLikes = 56 }
                );
            modelBuilder.Entity<Comments>().HasData(
                new Comments { CommentId = 1, CommentContent = "Já tamo lá!", CommentLikes = 12, PostId = 1 },
                new Comments { CommentId = 2, CommentContent = "Simm, por isso sou swiftie", CommentLikes = 50, PostId = 2 },
                new Comments { CommentId = 3, CommentContent = "O preço que se paga por saber ler...", CommentLikes = 6, PostId = 3 }
                );
        }
    }
}
