using Microsoft.EntityFrameworkCore;
using TestingApp.Domain.Entities.Attachments;
using TestingApp.Domain.Entities.Courses;
using TestingApp.Domain.Entities.Quizes;
using TestingApp.Domain.Entities.Users;

namespace TestingApp.Data.DbContexts;

/// <summary>
/// DbContext represents a session with the database.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Constructor is to accept an instance of DbContextOptions<AppDbContext> through dependency injection.
    /// This allows external configuration, such as the database connection string and provider,
    /// to be injected into the database context. 
    /// </summary>
    /// <param name="options"></param>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    /// <summary>
    /// Each DbSet<T> property represents a table in the database and
    /// will be used to query and interact with data of the corresponding entity type.
    /// Declaring DbSet<T> properties as virtual enables features like lazy loading and 
    /// change tracking through the creation of proxy classes for more efficient and dynamic database interactions
    /// </summary>
    public virtual DbSet<Attachment> Attachments { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Answer> Answers { get; set; }
    public virtual DbSet<Question> Questions { get; set; }
    public virtual DbSet<Quiz> Quizs { get; set; }
    public virtual DbSet<QuizResult> QuizResults { get; set; }
    public virtual DbSet<SolvedQuestion> SolvedQuestions { get; set; }
    public virtual DbSet<User> Users { get; set; }

    /// <summary>
    /// This code configures a unique index on the Email property of the User entity,
    /// enforcing uniqueness for email addresses in the database using Entity Framework Core.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().
            HasIndex(u => u.Email).IsUnique(true);

        modelBuilder.Entity<Course>().
            HasIndex(c => c.Name).IsUnique(true);
    }
}
