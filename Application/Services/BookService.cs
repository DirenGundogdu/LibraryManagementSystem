using Application.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services;

public class BookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper) {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookDTO>> GetAllBooksAsync() {
        var books = await _bookRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<BookDTO>>(books);
    }

    public async Task<BookDTO> GetBookByIdAsync(int id) {
        var book = await _bookRepository.GetByIdAsync(id);
        return _mapper.Map<BookDTO>(book);
    }

    public async Task AddBookAsync(BookDTO bookDto) {
        var book = _mapper.Map<Book>(bookDto);
        await _bookRepository.AddAsync(book);
    }
    
}