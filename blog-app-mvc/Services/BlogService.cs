using System;
using System.Collections.Generic;
using System.Linq;
using blog_app_mvc.Models;
using blog_app_mvc.Models.ViewModels;
using blog_app_mvc.Repositories;

namespace blog_app_mvc.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPostRepository _postRepository;
        private readonly ICommentRepository _commentRepository;

        public BlogService(IPostRepository postRepository, ICommentRepository commentRepository)
        {
            _postRepository = postRepository;
            _commentRepository = commentRepository;
        }

        #region Post

        public IList<Post> GetPostAllPosts()
        {
            var posts = _postRepository.GetAll();
            return posts.ToList();
        }

        public Post GetPostById(int postId)
        {
            var post = _postRepository.GetById(postId);
            return post;
        }

        public int CreatePost(PostViewModel postViewModel)
        {
            var post = new Post();
            post.Title = postViewModel.Title;
            post.Content = postViewModel.Content;
            post.Author = postViewModel.Author;

            _postRepository.Add(post);
            return post.Id;
        }

        public void UpdatePost(PostViewModel postViewModel)
        {
            var post = _postRepository.GetById(postViewModel.Id);

            post.Title = postViewModel.Title;
            post.Content = postViewModel.Content;
            post.Author = postViewModel.Author;

            _postRepository.Update(post);
        }

        public void DeletePost(int postId)
        {
            var post = _postRepository.GetById(postId);
            _postRepository.Delete(post);
        }

        #endregion

        #region Comment

        public void CreateComment(CommentViewModel commentViewModel)
        {
            var comment = new Comment();
            comment.Author = commentViewModel.Author;
            comment.Content = commentViewModel.Content;

            var post = _postRepository.GetById(commentViewModel.PostId);
            post.Comments.Add(comment);
            _postRepository.Update(post);
        }

        public void DeleteComment(int commentId)
        {
            var comment = _commentRepository.GetById(commentId);
            _commentRepository.Delete(comment);
        }

        #endregion
    }
}