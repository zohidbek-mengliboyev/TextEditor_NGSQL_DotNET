namespace TextEditor_NGSQL_DotNET.Commons
{
    public class ErrorResponse
    {
        public ErrorResponse(int? code = null, string message = null)
        {
            Code = code;
            Message = message;
        }
        public int? Code { get; set; }
        public string Message { get; set; }
    }
}
