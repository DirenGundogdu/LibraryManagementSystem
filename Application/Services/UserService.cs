using Application.DTOs;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;

namespace Application.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;


    public UserService(IUserRepository userRepository, IMapper mapper) {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<UserDTO>> GetAllUsersAsync() {
        var users = await _userRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<UserDTO>>(users);
    }

    public async Task<UserDTO> GetUserByIdAsync(int id) {
        var user = await _userRepository.GetByIdAsync(id);
        return _mapper.Map<UserDTO>(user);
    }
    
    public async Task AddUserAsync(UserDTO userDto) {
        var user = _mapper.Map<User>(userDto);
        await _userRepository.AddAsync(user);
    }
    
}