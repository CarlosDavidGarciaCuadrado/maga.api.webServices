
namespace maga.Bussines
{
    public class ResponseExcecuteMetod<T>
    {
        public bool state { get; set; }
        public string? responseType { get; set; }
        public string message { get; set; }
        public string? traceMessage { get; set; }
        public T? data { get; set; }

        public ResponseExcecuteMetod() 
        { 
            state = false;
            responseType = string.Empty;
            message = string.Empty;
            traceMessage = string.Empty;
        }

        public void SetState(string messageExt)
        {
            state = true;
            responseType = "OK";
            message = data != null ? "No hay registros." : messageExt;
        }

        public void LogError(Exception error)
        {
            responseType = "Error";
            message = error?.Message ?? string.Empty;
            traceMessage = $"{error?.InnerException?.Message} {error?.StackTrace}";
        }
    }
}
