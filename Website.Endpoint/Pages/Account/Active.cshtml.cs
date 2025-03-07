using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        UserId = userId; // ذخیره شناسه کاربر برای استفاده در فعال‌سازی
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
            return Page(); // اگر مدل معتبر نیست، صفحه را دوباره بارگذاری کن

        var user = await _userRepository.GetUserAsync(UserId); // دریافت کاربر با شناسه
        if (user == null)
            return NotFound(); // اگر کاربر پیدا نشد، خطای 404 برگردان

        if (user.Code == ActivationCode) // بررسی کد فعال‌سازی
        {
            user.IsActive = true; // تغییر وضعیت کاربر به فعال
            await _userRepository.UpdateUserAsync(user); // به‌روزرسانی کاربر در دیتابیس

            // هدایت به صفحه پروفایل بعد از فعال‌سازی موفق
            return RedirectToPage("/Profile"); // فرض بر این است که صفحه پروفایل شما "/Profile" است
        }

        ModelState.AddModelError("", "کد فعال‌سازی نامعتبر است"); // خطا در صورت نامعتبر بودن کد
        return Page(); // صفحه را دوباره بارگذاری کن
    }
}
