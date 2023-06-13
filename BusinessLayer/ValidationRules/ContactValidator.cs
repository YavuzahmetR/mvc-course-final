using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad Soyad Kısmı Boş Geçilemez! ");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail Kısmı Boş Geçilemez! ");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih Kısmı Boş Geçilemez! ");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj Kısmı Boş Geçilemez! ");
        }
    }
}
