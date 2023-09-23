namespace WebApplication1.Utility
{
    public class SD
    {

        public static string? APIBase = "https://localhost:7270";

        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE
        }
        public enum ContentType
        {
            Json,
            MultipartFormData,
        }
    }
}
