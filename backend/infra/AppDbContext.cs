using domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace infra
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
        public DbSet<Group> Groups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<domain.Entities.Task> Tasks { get; set; }
        public DbSet<Membering> Membering { get; set; }
        public DbSet<User_Task> User_Task { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<domain.Entities.Task>()
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
        }
    }
}
