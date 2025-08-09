using domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Membering> Membering { get; set; }
        public DbSet<User_Task> User_Task { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Friends> Friends { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<domain.Entities.Tasks>()
                .HasOne(t => t.Group)
                .WithMany(g => g.Task)
                .HasForeignKey(t => t.Group_Id)
                .OnDelete(DeleteBehavior.Cascade);

            //Modelando a parte da relação do usuário com User-Task
            modelBuilder.Entity<User_Task>()
                .HasOne(ut => ut.User)
                .WithMany(u => u.User_Task)
                .HasForeignKey(ut => ut.UserId);

            //Modelando a parte da relação da task com User-Task
            modelBuilder.Entity<User_Task>()
                .HasOne(ut => ut.Task)
                .WithMany(t => t.User_Task)
                .HasForeignKey(ut => ut.TaskId);

            //Modelando a parte da relação do grupo com Membering
            modelBuilder.Entity<Membering>()
                .HasOne(m => m.Group)
                .WithMany(g => g.Membering)
                .HasForeignKey(m => m.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            //Modelando a parte da relação do usuário com Membering
            modelBuilder.Entity<Membering>()
                .HasOne(m => m.User)
                .WithMany(g => g.Membering)
                .HasForeignKey(m => m.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Image>()
                .HasOne(i => i.User_Task)
                .WithMany(ut => ut.Image)
                .HasForeignKey(i => i.User_Task_Id);

            modelBuilder.Entity<Comment>()
                .HasOne(i => i.User_Task)
                .WithMany(ut => ut.Comment)
                .HasForeignKey(i => i.User_Task_Id);

            modelBuilder.Entity<Friends>(entity =>
            {
                
                entity.HasKey(f => new { f.User1_Id, f.User2_Id });

                entity.HasOne(f => f.User1)
                .WithMany(u => u.Friends)
                .HasForeignKey(u => u.User1_Id)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(f => f.User2)
                .WithMany()
                .HasForeignKey(f => f.User2_Id)
                .OnDelete(DeleteBehavior.Cascade);

            });
        }
    }
}
