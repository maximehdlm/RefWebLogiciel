using Microsoft.EntityFrameworkCore;
using RefWebLogiciel.Models;

namespace RefWebLogiciel.Data
{
    public class AppDbContext : DbContext
    {
        // Pont entre notre model et notre BDD
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt){}
        
        // Set le nom de la table 
        public DbSet<User> user {get; set;}
        public DbSet<ProjectTaskType> task_type {get; set;}
        public DbSet<ProjectTask> task {get; set;}
        public DbSet<UserSpecialization> UserSpecialization {get; set;}
        public DbSet<ProjectType> project_type {get; set;}
        public DbSet<Project> project {get; set;}
    }
}