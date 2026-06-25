namespace WebAssemblyDemo.Client
{
    public class ContainerStorage
    {
        private string _message = string.Empty;

        public string Message
        {
            get => _message;
            set => _message = value;
        }
    }
}
