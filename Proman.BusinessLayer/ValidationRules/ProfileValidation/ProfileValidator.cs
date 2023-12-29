using FluentValidation;
using Proman.EntityLayer.Concrete;

namespace Proman.BusinessLayer.ValidationRules.ProfileValidation
{
    public class ProfileValidator : AbstractValidator<MyProfile>
    {
        public ProfileValidator()
        {
            RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad Soyad boş bırakılamaz");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Unvan boş bırakılamaz");
            RuleFor(x => x.ImageURL).NotEmpty().WithMessage("Resim URL boş bırakılamaz");
        }
    }
}
