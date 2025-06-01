using Microsoft.EntityFrameworkCore;

public class UserDbContext : DbContext
{

    public DbSet<User> Users { get; set; }
    public DbSet<Code> Codes { get; set; }
    public DbSet<Comment> Comments { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        optionsBuilder.UseSqlServer(
            "Server=db20835.public.databaseasp.net; Database=db20835; User Id=db20835; Password=g-3C4Q!tp@2F; Encrypt=True; TrustServerCertificate=True; MultipleActiveResultSets=True; ",
            options => options.EnableRetryOnFailure()
        );
    }
}
