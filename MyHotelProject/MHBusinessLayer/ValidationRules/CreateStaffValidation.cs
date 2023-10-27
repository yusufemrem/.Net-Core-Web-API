using FluentValidation;
using MHDtoLayer.StaffDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHBusinessLayer.ValidationRules
{
    public class CreateStaffValidation : AbstractValidator<StaffDto>
    {
        public CreateStaffValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Alanı Boş Geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Ünvan Alanı Boş Geçilemez");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("En Az 3 Karakter Girişi Yapmalısınız.");
            RuleFor(x=> x.Title).MinimumLength(3).WithMessage("En Az 3 Karakter Girişi Yapmalısınız.");
        }
    }
}
