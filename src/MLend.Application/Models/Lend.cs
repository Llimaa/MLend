namespace MLend.Application;

public class Lend 
{
    public Lend(string document, Guid bookId)
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        ReturnedAt = null;
        Document = document;
        BookId = bookId;
        Status = Status.Loan;
    }

    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? ReturnedAt { get; private set; }
    public string Document { get; private set; }
    public Guid BookId { get; private set; }
    public Status Status { get; private set; }

    public void ReturnBook() 
    {
        Status = Status.Returned;
        ReturnedAt = DateTime.UtcNow;
    }
}
