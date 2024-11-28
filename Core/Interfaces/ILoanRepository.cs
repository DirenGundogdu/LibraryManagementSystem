using Core.Entities;

namespace Core.Interfaces;

public interface ILoanRepository : IRepository<Loan>
{
    Task<IEnumerable<Loan>> GetLoansByUserAsync(int userId);
}