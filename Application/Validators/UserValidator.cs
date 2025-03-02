using Domain.Entities;
using FluentValidation;

public class UserValidator : AbstractValidator<User>
{
    public UserValidator()
    {
        RuleFor(user => user.Mobile)
            .NotEmpty().WithMessage("مقدار شماره موبایل را وارد نمایید")
            .Length(11).WithMessage("مقدار شماره موبایل نمی تواند بیش تر از 11 کاراکتر باشد");

        RuleFor(user => user.Password)
            .MaximumLength(50).WithMessage("مقدار کلمه عبور نمی تواند بیش تر از 50 کاراکتر باشد");

        RuleFor(user => user.Code)
            .MaximumLength(6).WithMessage("مقدار کد فعالسازی نمی تواند بیش تر از 6 کاراکتر باشد");

        RuleFor(user => user.IsActive)
            .NotNull().WithMessage("وضعیت فعال/غیرفعال باید مشخص شود");
    }
}
