using Microsoft.EntityFrameworkCore;
using TextEditor_NGSQL_DotNET.Entity;

namespace TextEditor_NGSQL_DotNET.Context
{
    public class TxtEditorDbContext : DbContext
    {
        public TxtEditorDbContext(DbContextOptions<TxtEditorDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Post> Posts { get; set; }
    }
}
