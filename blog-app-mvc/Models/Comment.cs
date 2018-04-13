namespace blog_app_mvc.Models
{
    public class Comment
    {
        public virtual int Id { get; set; }
        public virtual string Author { get; set; }
        public virtual string Content { get; set; }
               
        public Comment()
        {
            
        }
    }
}