using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class LoanRepository : BaseRepository<Loan>, ILoanRepository
{
    public LoanRepository(ApplicationDbContext context) : base(context) {}

    public async Task<IEnumerable<Loan>> GetLoansByUserAsync(int userId) => await _context.Loans.Where(x=>x.UserId == userId).ToListAsync();
}