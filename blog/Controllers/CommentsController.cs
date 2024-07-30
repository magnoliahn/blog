using blog.Data;
using blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace blog.Controllers
{
    public class CommentsController : Controller
    {
        private readonly AppDbContext _db;
        public CommentsController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet("getComment")]
        public ActionResult<Comments> GetComment(int commentId)
        {
            var comment = _db.comments.FirstOrDefault(comment => comment.CommentId == commentId);
            if (comment == null)
            {
                return NotFound("Não foi encontrada nenhum comentário com este Id.");
            }
            return Ok(comment);
        }

        [HttpPost("addComment")]
        public ActionResult AddComment(int postId, string commentContent)
        {
            if (string.IsNullOrEmpty(commentContent))
            {
                return BadRequest("É obrigatório o preenchimento do campo acima com o que voc deseja comentar.");
            }
            if (postId == null)
            {
                return BadRequest("É obrigatório o preenchimento do campo acima com o id do post o qual você deseja comentar");
            }
            var post = _db.post.FirstOrDefault(post => post.PostId == postId);
            if (post == null)
            {
                return NotFound("Post não encontrado.");
            }
            var comment = new Comments
            {
                CommentContent = commentContent,
                PostId = post.PostId
            };
            _db.comments.Add(comment);
            _db.SaveChanges();
            return Ok("Comentário publicado!");
        }

        [HttpPost("likeComment")]
        public ActionResult LikeComment (int commentId)
        {
            var comment = _db.comments.FirstOrDefault(comment => comment.CommentId == commentId);
            if (comment == null)
            {
                return NotFound("Não foi encontrada nenhum comentário com este Id.");
            }
            comment.CommentLikes += 1;
            _db.SaveChanges();
            return Ok("Comentário curtido!");
        }

        [HttpDelete("DeleteComment")]
        public ActionResult DeleteComment(int commentId)
        {
            var comment = _db.comments.FirstOrDefault(c => c.CommentId == commentId);
            if (comment == null)
            {
                return NotFound("Não foi encontrada nenhum comentário com este Id.");
            }

            _db.comments.Remove(comment);
            _db.SaveChanges();

            return Ok("Comentário removido com sucesso!");
        }

    }
}


