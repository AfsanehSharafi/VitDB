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

        public RegisterModel(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> OnPostAsync(RegisterUserCommand command)
        {
            if (!ModelState.IsValid)
                return Page();

            var userId = await _mediator.Send(command);
            return RedirectToPage("/Account/Active", new { userId = userId });
        }
    }

}
