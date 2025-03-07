using Domain.Entities;
using Infrastructure.Utilities.Infrastructure.Utilities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

public class UserRepository : IUserRepository
{
    private readonly DataBaseContext _context;

    public UserRepository(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<int> AddUserAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user.Id;
    }

    public async Task<bool> ActiveUserAsync(string activeCode)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => !u.IsActive && u.Code == activeCode);

        if (user != null)
        {
            user.Code = CodeGenerators.ActiveCode();
            user.IsActive = true;
            await _context.SaveChangesAsync();
            return true;
        }

        return false;
    }





    public async Task<bool> IsMobileNumberExistAsync(string mobileNumber)
    {
        return await _context.Users.AnyAsync(u => u.Mobile == mobileNumber);
    }

    public async Task<User> GetUserAsync(string Id)
    {
        return await _context.Users.FindAsync(Id)
               ?? throw new Exception("کاربر مورد نظر یافت نشد");
    }


    public async Task<bool> UpdateUserAsync(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
        return true;
    }
}
