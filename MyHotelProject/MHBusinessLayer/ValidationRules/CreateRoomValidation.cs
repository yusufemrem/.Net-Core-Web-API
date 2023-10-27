using FluentValidation;
using MHDtoLayer.RoomDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHBusinessLayer.ValidationRules
{
    public class CreateRoomValidation : AbstractValidator<CreateRoomDto>
    {
        public CreateRoomValidation()
        {
            RuleFor(x => x.RoomNumber).NotEmpty().WithMessage("Oda Numarası Boş Geçilemez");
            RuleFor(x => x.Price).NotEmpty().WithMessage("Oda Ücreti Boş Geçilemez");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Oda Başlığı Boş Geçilemez.");
            RuleFor(x => x.BedCount).NotEmpty().WithMessage("En Az 3 Karakter Girişi Yapmalısınız.");
            RuleFor(x => x.Wifi).NotEmpty().WithMessage("Wifi Alanı Boş Geçilemez");

        }

    }
}
