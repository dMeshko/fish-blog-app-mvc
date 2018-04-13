namespace blog_app_mvc.Models.ViewModels
{
    public class PostViewModel
    {
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string Content { get; set; }
        public virtual string Author { get; set; }
    }
}