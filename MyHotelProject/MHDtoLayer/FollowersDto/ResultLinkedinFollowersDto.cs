using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDtoLayer.FollowersDto
{
    public class ResultLinkedinFollowersDto
    {
        public Data data { get; set; }
        public class Data
        {
            public int followers_count { get; set; }
        }

    }
}


