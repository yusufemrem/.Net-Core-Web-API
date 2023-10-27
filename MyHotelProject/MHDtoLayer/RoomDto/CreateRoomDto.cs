using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDtoLayer.RoomDto
{
    public class CreateRoomDto
    {
        public string RoomNumber { get; set; }
        public int Price { get; set; }
        public string Title { get; set; }
        public string BedCount { get; set; }
        public string Wifi { get; set; }

    }
}
