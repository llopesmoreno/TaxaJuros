namespace TaxaJurosDocker.BaseApi.Models
{
    public class SuccessRequestResponseDefault<T>
    {
        public SuccessRequestResponseDefault(bool valid, T data)
        {
            Valid = valid;
            Data = data;
        }

        public bool Valid { get; }
        public T Data { get; }
    }
}
