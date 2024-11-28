using Application.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Enums;
using Core.Exceptions;
using Core.Interfaces;

namespace Application.Services;

public class LoanService
{
    private readonly ILoanRepository _loanRepository;
    private readonly IUserRepository _userRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public LoanService(ILoanRepository loanRepository, IUserRepository userRepository, IBookRepository bookRepository, IMapper mapper) {
        _loanRepository = loanRepository;
        _userRepository = userRepository;
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<LoanDTO> LoanBookAsync(int userId, int bookId) {
        var book = await _bookRepository.GetByIdAsync(bookId);
        var user = await _userRepository.GetByIdAsync(userId);
        
        if(book == null || user == null){throw new CustomException("User or Book not found");}

        var loan = new Loan {
            UserId = userId,
            BookId = bookId,
            LoanDate = DateTime.Now,
            Status = LoanStatus.Pending
        };
        await _loanRepository.AddAsync(loan);
        return _mapper.Map<LoanDTO>(loan);
    }

    public async Task<LoanDTO> ReturnBookAsync(int loadId) {
        var loan = await _loanRepository.GetByIdAsync(loadId);
        if(loan == null){throw new CustomException("Loan not found");}

        loan.Status = LoanStatus.Complete;
        loan.ReturnDate = DateTime.Now;

        await _loanRepository.UpdateAsync(loan);
        return _mapper.Map<LoanDTO>(loan);
    }

    public async Task<IEnumerable<LoanDTO>> GetLoansByUserIdAsync(int userId) {
        var loans = await _loanRepository.GetLoansByUserAsync(userId);
        return _mapper.Map<IEnumerable<LoanDTO>>(loans);
    }
}