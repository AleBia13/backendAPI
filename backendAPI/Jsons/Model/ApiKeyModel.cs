namespace backendAPI.Jsons.Model
{
    public class ApiKeyModel
    {
        public OpenAI OpenAI { get; set; }
    }

    public class OpenAI
    {
        public string ApiKey { get; set; }
    }
}
