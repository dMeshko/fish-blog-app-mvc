namespace blog_app_mvc.Models.ViewModels
{
    public class CommentViewModel
    {
        public virtual int PostId { get; set; }
        public virtual string Author { get; set; }
        public virtual string Content { get; set; }
    }
}