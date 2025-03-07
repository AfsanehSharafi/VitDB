using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ActiveModel : PageModel
{
    private readonly IUserRepository _userRepository;

    [BindProperty]
    public string ActivationCode { get; set; }

    public string Id { get; set; }

    public ActiveModel(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void OnGet(string id)
    {
        Id = id;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page();

        var user = await _userRepository.GetUserAsync(Id);
        if (user == null)
            return NotFound();

        if (user.Code == ActivationCode)
        {
            user.IsActive = true;
            await _userRepository.UpdateUserAsync(user);

            return RedirectToPage("Account/Profile");
        }

        ModelState.AddModelError("", "کد فعال‌سازی نامعتبر است");
        return Page();
    }
}
