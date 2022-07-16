using System.ComponentModel.DataAnnotations;

namespace TextEditor_NGSQL_DotNET.Model
{
    public class PostContent
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
