using System.Linq.Expressions;
using TextEditor_NGSQL_DotNET.Commons;
using TextEditor_NGSQL_DotNET.Entity;
using TextEditor_NGSQL_DotNET.Model;

namespace TextEditor_NGSQL_DotNET.Interface
{
    public interface IPostContentService
    {
        Task<BaseResponse<Post>> CreateAsync(PostContent con);
        Task<BaseResponse<Post>> GetAsync(Expression<Func<Post, bool>> expression);
        Task<BaseResponse<IEnumerable<Post>>> GetAllAsync(Expression<Func<Post, bool>> expression = null);
        Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Post, bool>> expression);
        Task<BaseResponse<Post>> UpdateAsync(int id, PostContent con);
    }
}
