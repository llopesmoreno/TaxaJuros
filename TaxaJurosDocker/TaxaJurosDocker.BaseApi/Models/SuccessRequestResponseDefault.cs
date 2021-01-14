namespace TaxaJurosDocker.BaseApi.Models
{
    public class SuccessRequestResponseDefault<T>
    {
        public SuccessRequestResponseDefault(T data)
        {
            Valid = true;
            Data = data;
        }

        public bool Valid { get; }
        public T Data { get; }
    }
}
