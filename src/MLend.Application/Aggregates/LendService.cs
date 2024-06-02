namespace MLend.Application;

public class LendService(ILendRepository repository) : ILendService
{
    private readonly ILendRepository _repository = repository;

    public async Task<IEnumerable<Lend>> GetLendsByStatus(Status status, CancellationToken cancellationToken) =>
        await _repository.GetLendsByStatus(status, cancellationToken);

    public async Task<Guid> InsertAsync(LendRequest request, CancellationToken cancellationToken)
    {
        var bookLoan = await _repository.ExistWithBookIdAndStatusLoan(request.BookId, cancellationToken);

        if(bookLoan)
            throw new Exception("Esse livro já está emprestado!");


        var lend = new Lend(request.Document, request.BookId);
        await _repository.InsertAsync(lend, cancellationToken);
        return lend.Id;
    }

    public async Task UpdateAsync(Guid id, CancellationToken cancellationToken)
    {
        var lend = await _repository.GetByIdAsync(id, cancellationToken);
        lend.ReturnBook();
        await _repository.UpdateAsync(lend, cancellationToken);
    }
}
