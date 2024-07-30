using blog.Data;
using blog.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blog.Controllers
{
    public class PostsController : Controller
    {
        private readonly AppDbContext _db;
        public PostsController(AppDbContext db)
        {
            _db = db;

        }
        [HttpGet("allPosts")]
        public ActionResult<IEnumerable<Post>> GetPosts()
        {
            return _db.post.Include(post => post.Comments).ToList();
        }

        [HttpGet("getPost")]
        public ActionResult<Post> GetPost(int postId)
        {
            var post = _db.post.Include(post => post.Comments).FirstOrDefault(post => post.PostId == postId);
            if (post == null)
            {
                return NotFound("Não foi encontrada nenhuma publicação com este Id.");
            }
            return Ok(post);
        }

        [HttpPost("createPost")]
        public ActionResult CreatePost(string postTitle, string postContent)
        {
            if (string.IsNullOrEmpty(postTitle) || string.IsNullOrEmpty(postContent))
            {
                return BadRequest("É obrigatório o preenchimento do campo title e content, escreva o que você deseja publicar.");
            }
            var post = new Post
            {
                PostTitle = postTitle,
                PostContent = postContent
            };
            _db.post.Add(post);
            _db.SaveChanges();

            return Ok("Post feito com sucesso!");
        }

        [HttpPost("likePost")]
        public ActionResult LikePost(int postId)
        {
            var post = _db.post.FirstOrDefault(post => post.PostId == postId);
            if (post == null)
            {
                return NotFound("Não foi encontrada nenhuma publicação com este Id.");
            }
            post.PostLikes += 1;
            _db.SaveChanges();
            return Ok("Post curtido com sucesso!");
        }

        [HttpDelete("DeletePost")]
        public ActionResult DeletePost (int postId)
        {
            var post = _db.post.FirstOrDefault(post => post.PostId == postId);
            if (post == null)
            {
                return NotFound("Não foi encontrada nenhuma publicação com este Id.");
            }
            var comments = _db.comments.Where(c => c.PostId == postId).ToList();
            _db.comments.RemoveRange(comments);

            _db.post.Remove(post);
            _db.SaveChanges();
            return Ok("Post removido com sucesso!");
        }
    }
}

