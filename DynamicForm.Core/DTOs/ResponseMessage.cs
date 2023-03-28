namespace DynamicForm.Core.DTOs
{
    public sealed class ResponseMessage
    {
        public ResponseMessage(string message, bool hasSucceed, object? data = null)
        {
            Message = message;
            HasSucceed = hasSucceed;
            Data = data;
        }

        public object? Data { get; set; }
        public string Message { get; set; }
        public bool HasSucceed { get; set; }
    }
}
