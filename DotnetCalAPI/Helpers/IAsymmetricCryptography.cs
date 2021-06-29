namespace DotnetCal.Helpers
{
    public interface IAssmyetricCryptography
    {

        public string SignData<T>(T data);

        public bool VerifySignature(string data, string signature);

        public string Encrypt<T>(T payload);

        public T Decrypt<T>(string payload);
    }
}