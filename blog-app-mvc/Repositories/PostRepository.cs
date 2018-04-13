using blog_app_mvc.Models;

namespace blog_app_mvc.Repositories
{
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository(IUnitOfWork unitOfWork) : base(unitOfWork) { }


    }
}