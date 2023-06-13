using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator() 
        {
            RuleFor(x => x.Description1).NotEmpty().WithMessage("Açıklama 1 kısmı boş geçilemez");
            RuleFor(x => x.Description2).NotEmpty().WithMessage("Açıklama 2 kısmı boş geçilemez");
            RuleFor(x => x.Description3).NotEmpty().WithMessage("Açıklama 3 kısmı boş geçilemez");
            RuleFor(x => x.Description4).NotEmpty().WithMessage("Açıklama 4 kısmı boş geçilemez");
            RuleFor(x => x.MapInfo).NotEmpty().WithMessage("Harita Bilgisi kısmı boş geçilemez");
            RuleFor(x => x.Description1).MaximumLength(30).WithMessage("Lütfen en az 20 karakter değeri giriniz.");
            RuleFor(x => x.Description2).MaximumLength(30).WithMessage("Lütfen en az 20 karakter değeri giriniz.");
            RuleFor(x => x.Description3).MaximumLength(30).WithMessage("Lütfen en az 20 karakter değeri giriniz.");
            RuleFor(x => x.Description4).MaximumLength(30).WithMessage("Lütfen en az 20 karakter değeri giriniz.");
        }
        
    }
}
