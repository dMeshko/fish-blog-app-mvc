using System.Collections.Generic;
using blog_app_mvc.Models;
using blog_app_mvc.Models.ViewModels;

namespace blog_app_mvc.Services
{
    public interface IBlogService
    {
        #region Post

        IList<Post> GetPostAllPosts();
        Post GetPostById(int postId);
        int CreatePost(PostViewModel postViewModel);
        void UpdatePost(PostViewModel postViewModel);
        void DeletePost(int postId);

        #endregion

        #region Comment

        void CreateComment(CommentViewModel commentViewModel);
        void DeleteComment(int commentId);

        #endregion
    }
}
