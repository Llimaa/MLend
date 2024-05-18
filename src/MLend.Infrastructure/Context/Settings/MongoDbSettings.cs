namespace MLend.Infrastructure;

public record MongoDbSettings 
{
    public string ConnectionString { get; set; } = string.Empty!;
    public string DatabaseName { get; set; } = string.Empty!;
    public string LendCollection { get; set; } = string.Empty!;
}
