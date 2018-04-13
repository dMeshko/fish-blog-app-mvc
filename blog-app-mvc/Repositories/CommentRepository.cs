using blog_app_mvc.Models;

namespace blog_app_mvc.Repositories
{
    public class CommentRepository : RepositoryBase<Comment>, ICommentRepository
    {
        public CommentRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}