public class Code
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Language { get; set; }
    public string CodeSnippet { get; set; }
    public int UserId { get; set; }
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}
