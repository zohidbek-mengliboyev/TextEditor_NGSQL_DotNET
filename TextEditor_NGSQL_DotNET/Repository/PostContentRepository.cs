using TextEditor_NGSQL_DotNET.Context;
using TextEditor_NGSQL_DotNET.Entity;
using TextEditor_NGSQL_DotNET.IRepository;

namespace TextEditor_NGSQL_DotNET.Repository
{
    public class PostContentRepository : GenericRepository<Post>, IPostContentRepository
    {
        public PostContentRepository(TxtEditorDbContext dbContext) : base(dbContext)
        {
        }
    }
}
