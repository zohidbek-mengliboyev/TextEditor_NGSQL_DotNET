using TextEditor_NGSQL_DotNET.Context;
using TextEditor_NGSQL_DotNET.Entity;
using TextEditor_NGSQL_DotNET.IRepository;

namespace TextEditor_NGSQL_DotNET.Repository
{
    public class PostContentRepository : GenericRepository<Post>, IPostContentRepository
    {
        public PostContentRepository(TxtEditorDbContext dbContext, Serilog.ILogger logger) : base(dbContext, logger)
        {
        }
    }
}
