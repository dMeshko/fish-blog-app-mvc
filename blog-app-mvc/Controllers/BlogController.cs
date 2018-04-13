using System.Web.Mvc;
using blog_app_mvc.Models.ViewModels;
using blog_app_mvc.Services;

namespace blog_app_mvc.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [HttpGet]
        public ActionResult GetPostAllPosts()
        {
            var posts = _blogService.GetPostAllPosts();
            return Json(posts, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetPostById(int id)
        {
            var post = _blogService.GetPostById(id);
            return Json(post, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CreatePost(PostViewModel postViewModel)
        {
            var postId = _blogService.CreatePost(postViewModel);
            return Json(postId);
        }

        [HttpPost]
        public ActionResult UpdatePost(PostViewModel postViewModel)
        {
            _blogService.UpdatePost(postViewModel);
            return Json(true);
        }

        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            _blogService.DeletePost(id);
            return Json(true);
        }

        [HttpPost]
        public ActionResult CreateComment(CommentViewModel commentViewModel)
        {
            _blogService.CreateComment(commentViewModel);
            return Json(true);
        }

        [HttpPost]
        public ActionResult DeleteComment(int id)
        {
            _blogService.DeleteComment(id);
            return Json(true);
        }
    }
}