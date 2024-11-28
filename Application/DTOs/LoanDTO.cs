using Core.Enums;

namespace Application.DTOs;

public class LoanDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int BookId { get; set; }
    public LoanStatus Status { get; set; }
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
}