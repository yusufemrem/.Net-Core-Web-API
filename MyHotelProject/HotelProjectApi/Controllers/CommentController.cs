using MHBusinessLayer.Abstract;
using MHBusinessLayer.Concrete;
using MHDtoLayer.CommentDto;
using MHEntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HotelProjectApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _commentService.TGetByID(id);
            return Ok(values);
        }
        [HttpGet("getListCommnent")]
        public IActionResult getListCommnent()
        {
          var values =  _commentService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddComment(CreateCommentDto createCommentDto)
        {
            DateTime now = DateTime.Now;
            DateTime dateOnly = now.Date;
            var comment = new Comment
            {
                CommentID = createCommentDto.commentID,
                CommentUser = createCommentDto.commentUser,
                CommentContent = createCommentDto.commentContent,
                CommentState = createCommentDto.commentState,
                CommentDate = DateTime.Now.Date
                
            };

            _commentService.TInsert(comment);
            return Ok();

        }
    }
}
