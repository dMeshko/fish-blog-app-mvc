using FluentNHibernate.Mapping;

namespace blog_app_mvc.Models
{
    public class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Id(x => x.Id)
                .GeneratedBy.Increment();

            Map(x => x.Author)
                .Not.Nullable();

            Map(x => x.Title)
                .Not.Nullable();

            Map(x => x.Content)
                .Length(1000)
                .Not.Nullable();

            HasMany(x => x.Comments)
                .Cascade.AllDeleteOrphan();
        }
    }
}