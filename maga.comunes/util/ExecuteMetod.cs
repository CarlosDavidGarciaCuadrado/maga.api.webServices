using maga.Bussines;

namespace maga.commons.util
{
    public static class ExecuteMetod
    {
        public static async Task<ResponseExcecuteMetod<T>> RunMetodAsync<T>(Task<T> method, string message = "")
        {
            var result = new ResponseExcecuteMetod<T>();
            try
            {
                result.data = await method;
                result.SetState(message);
            }
            catch (Exception error)
            {
                result.LogError(error);
            }
            return result;
        }
    }
}
