using Domain.Entities;

public interface IUserRepository
{
    Task<int> AddUserAsync(User user);
    Task<bool> ActiveUserAsync(string activeCode);
    Task<bool> IsMobileNumberExistAsync(string mobileNumber);
    Task<User> GetUserAsync(string Id);
    Task<bool> UpdateUserAsync(User user);
}
