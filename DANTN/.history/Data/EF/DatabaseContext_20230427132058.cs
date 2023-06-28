using DANTN.Data.Entities;
using Microsoft.EntityFrameworkCore;
using static DANTN.Data.Entities.Topic;

namespace DANTN.Data.EF;

public class DatabaseContext : DbContext
{
  public DatabaseContext(DbContextOptions options) : base(options)
  {
  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.ApplyConfiguration(new UserConfiguration());
    User.SeedData(modelBuilder);
    modelBuilder.ApplyConfiguration(new TopicConfiguration());
    Topic.SeedData(modelBuilder);

    modelBuilder.ApplyConfiguration(new VocabularyConfiguration());
    Vocabulary.SeedData(modelBuilder);

    modelBuilder.ApplyConfiguration(new QuestionConfiguration());
    Question.SeedData(modelBuilder);

  }

  public DbSet<User> Users { set; get; } = default!;
  public DbSet<Topic> Topics { set; get; } = default!;
  public DbSet<Vocabulary> Vocabularies { set; get; } = default!;
  public DbSet<Question> Questions { set; get; } = default!;
  public DbSet<Level> Levels { set; get; } = default!;





}
