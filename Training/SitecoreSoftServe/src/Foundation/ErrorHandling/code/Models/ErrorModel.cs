namespace SitecoreSoftServe.Foundation.ErrorHandling.Models
{
    public class ErrorModel
    {
        public ErrorModel(string message, MessageType type)
        {
            Message = message;
            Type = type;
        }

        public string Message { get; set; }
        public MessageType Type { get; set; }


        public enum MessageType
        {
            Info,
            Warning,
            Error
        }

        public static ErrorModel Error(string message) => new ErrorModel(message, MessageType.Error);
        public static ErrorModel Warning(string message) => new ErrorModel(message, MessageType.Warning);
        public static ErrorModel Info(string message) => new ErrorModel(message, MessageType.Info);
    }
}