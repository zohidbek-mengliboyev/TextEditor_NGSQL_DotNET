using Microsoft.AspNetCore.Mvc;
using TextEditor_NGSQL_DotNET.Commons;
using TextEditor_NGSQL_DotNET.Entity;
using TextEditor_NGSQL_DotNET.Entity.Enum;
using TextEditor_NGSQL_DotNET.Interface;
using TextEditor_NGSQL_DotNET.Model;

namespace TextEditor_NGSQL_DotNET.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostContentController : ControllerBase
    {
        private readonly IPostContentService postContentService;
        public PostContentController(IPostContentService postContentService)
        {
            this.postContentService = postContentService;
        }

        [HttpPost]
        public async Task<ActionResult<BaseResponse<Post>>> Create(Content con)
        {
            var result = await postContentService.CreateAsync(con);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);

        }

        [HttpGet]
        public async Task<ActionResult<BaseResponse<IEnumerable<Post>>>> GetAll()
        {
            var result = await postContentService.GetAllAsync();

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseResponse<Post>>> Get([FromRoute] int id)
        {
            var result = await postContentService.GetAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BaseResponse<Post>>> Update(int id, [FromForm] Content con)
        {
            var result = await postContentService.UpdateAsync(id, con);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseResponse<bool>>> Delete(int id)
        {
            var result = await postContentService.DeleteAsync(p => p.Id == id && p.State != ItemState.Deleted);

            return StatusCode(result.Code ?? result.Error.Code.Value, result);
        }
    }
}
