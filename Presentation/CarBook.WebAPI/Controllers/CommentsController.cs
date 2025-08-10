using CarBook.Application.Features.Mediator.Commands.CommentCommands;
using CarBook.Application.Features.RepositoryPattern;
using CarBook.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CarBook.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _repository;
        private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult ListComment() 
        {
            var values = _repository.GetAll();
            return Ok(values);
        
        }
        [HttpPost]
        public IActionResult CreateComment(Comment comment) 
        {
            _repository.Create(comment);
            return Ok("Yorum Başarıla Oluşturuldu");
        
        }
        [HttpDelete]
        public IActionResult DeleteComment(int id) 
        {
           var value= _repository.GetById(id);
            _repository.Delete(value);
            return Ok("Yorum Başarıla Silindi");
        
        }
        [HttpPut]
        public IActionResult UpdateComment(Comment comment) 
        {
            _repository.Update(comment);
            return Ok("Yorum Başarıla Güncellendi");
        
        }
        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _repository.GetById(id);
            return Ok(values);

        }
        [HttpGet("GetCommentsByBlog")]
        public IActionResult GetCommentsByBlog(int id)
        {
            var values = _repository.GetCommentsByBlogId(id);
            return Ok(values);

        }
        [HttpGet("GetCommentsCountByBlog")]
        public IActionResult GetCommentsCountByBlog(int id)
        {
            var values = _repository.GetCountCommentByBlog(id);
            return Ok(values);

        }
        [HttpPost("CreateCommentWithMediator")]
        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok("Yorum Eklendi");

        }

    }
}
