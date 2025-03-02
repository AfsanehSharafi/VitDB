using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

public class ActiveModel : PageModel
{
    private readonly IUserRepository _userRepository;

    [BindProperty]
    public string ActivationCode { get; set; }

    public string UserId { get; set; }

    public ActiveModel(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void OnGet(string userId)
    {
        UserId = userId;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var user = await _userRepository.GetUserAsync(UserId);
        if (user == null)
            return NotFound();

        if (user.Code == ActivationCode)
        {
            user.IsActive = true;
            await _userRepository.UpdateUserAsync(user);
            return RedirectToPage("/Login");
        }

        ModelState.AddModelError("", "کد فعال‌سازی نامعتبر است");
        return Page();
    }
}
