using AutoMapper;
using System.Linq.Expressions;
using TextEditor_NGSQL_DotNET.Commons;
using TextEditor_NGSQL_DotNET.Entity;
using TextEditor_NGSQL_DotNET.Entity.Enum;
using TextEditor_NGSQL_DotNET.Interface;
using TextEditor_NGSQL_DotNET.IRepository;
using TextEditor_NGSQL_DotNET.Model;

namespace TextEditor_NGSQL_DotNET.Service
{
    public class PostContentService : IPostContentService
    {
        private readonly IMapper mapper;
        private readonly IPostContentRepository repository;

        public PostContentService(IMapper mapper, IPostContentRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<BaseResponse<Post>> CreateAsync(PostContent con)
        {
            var response = new BaseResponse<Post>();

            // create after checking success
            var mappedTeacher = mapper.Map<Post>(con);

            var result = await repository.CreateAsync(mappedTeacher);

            await repository.SaveChangesAsync();

            response.Data = result;

            return response;
        }

        public async Task<BaseResponse<bool>> DeleteAsync(Expression<Func<Post, bool>> expression)
        {
            var response = new BaseResponse<bool>();

            // check for exist employee
            var existPost = await repository.GetAsync(expression);
            if (existPost is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }
            existPost.Delete();

            await repository.UpdateAsync(existPost);

            await repository.SaveChangesAsync();

            response.Data = true;

            return response;
        }

        public async Task<BaseResponse<IEnumerable<Post>>> GetAllAsync(Expression<Func<Post, bool>> expression = null)
        {
            var response = new BaseResponse<IEnumerable<Post>>();

            var employees = await repository.GetAllAsync(expression => expression.State != ItemState.Deleted);

            response.Data = employees.ToList();

            if (response.Data is null)
            {
                response.Error = new ErrorResponse(404, "Users not found");
            }

            return response;
        }

        public async Task<BaseResponse<Post>> GetAsync(Expression<Func<Post, bool>> expression)
        {
            var response = new BaseResponse<Post>();

            var post = await repository.GetAsync(expression);
            if (post is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            response.Data = post;

            return response;
        }

        public async Task<BaseResponse<Post>> UpdateAsync(int id, PostContent con)
        {
            var response = new BaseResponse<Post>();

            // check for exist employee
            var post = await repository.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);
            if (post is null)
            {
                response.Error = new ErrorResponse(404, "User not found");
                return response;
            }

            post.Title = con.Title;
            post.Content = con.Content;
            post.Update();

            var result = await repository.UpdateAsync(post);

            await repository.SaveChangesAsync();

            response.Data = result;

            return response;
        }
    }
}
