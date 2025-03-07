using Application.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Website.Endpoint.Pages.Account
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public string Mobile { get; set; }
        [BindProperty]
        public string Password { get; set; }

        private readonly IMediator _mediator;
        private readonly IUserRepository _userRepository; // اضافه کردن IUserRepository

        public RegisterModel(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository; // تزریق IUserRepository
        }

        public async Task<IActionResult> OnPostAsync(RegisterUserCommand command)
        {
            if (!ModelState.IsValid)
                return Page();

            // بررسی وجود شماره موبایل
            if (await _userRepository.IsMobileNumberExistAsync(Mobile))
            {
                ModelState.AddModelError("Mobile", "این شماره موبایل قبلاً ثبت شده است.");
                return Page();
            }

            var userId = await _mediator.Send(command);
            return RedirectToPage("/Account/Active", new { userId = userId });
        }
    }
}
