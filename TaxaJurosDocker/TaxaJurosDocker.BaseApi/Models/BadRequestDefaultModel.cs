namespace TaxaJurosDocker.BaseApi.Models
{
    public class BadRequestDefaultModel
    {
        public BadRequestDefaultModel(string[] message)
        {
            Valid = false;
            Message = message;
        }

        public bool Valid { get; }
        public string[] Message { get; }
    }
}
