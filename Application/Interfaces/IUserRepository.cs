using Domain.Entities;

public interface IUserRepository
{
    Task<int> AddUserAsync(User user);
    Task<bool> ActiveUserAsync(string activeCode);
    Task<bool> IsMobileNumberExistAsync(string mobileNumber);
    Task<User> GetUserAsync(string userId); // افزودن این خط
    Task<bool> UpdateUserAsync(User user); // افزودن این خط
}
