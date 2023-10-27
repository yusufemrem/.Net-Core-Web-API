using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MHDtoLayer.CommentDto
{
    public class CreateCommentDto
    {
        public int commentID { get; set; }
        public string commentUser { get; set; }
        public string commentContent { get; set; }
        public bool commentState { get; set; }
        public DateTime commentTime { get; set; }

        //commentUser: null,
        //commentContent: null,
        //commentState: null,
    }
}
