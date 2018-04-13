using FluentNHibernate.Mapping;

namespace blog_app_mvc.Models
{
    public class CommentMap : ClassMap<Comment>
    {
        public CommentMap()
        {
            Id(x => x.Id)
                .GeneratedBy.Increment();

            Map(x => x.Author)
                .Not.Nullable();

            Map(x => x.Content)
                .Length(1000)
                .Not.Nullable();
        }
    }
}