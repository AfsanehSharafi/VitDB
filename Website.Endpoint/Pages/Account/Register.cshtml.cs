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
        private readonly IUserRepository _userRepository;

        public RegisterModel(IMediator mediator, IUserRepository userRepository)
        {
            _mediator = mediator;
            _userRepository = userRepository;
        }

        public async Task<IActionResult> OnPostAsync(RegisterUserCommand command)
        {
            if (!ModelState.IsValid)
                return Page();

            if (await _userRepository.IsMobileNumberExistAsync(Mobile))
            {
                ModelState.AddModelError("Mobile", "این شماره موبایل قبلاً ثبت شده است.");
                return Page();
            }

            var Id = await _mediator.Send(command);
            return RedirectToPage("/Account/Active", new { Id = Id });
        }
    }
}
