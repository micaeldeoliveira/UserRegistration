namespace UserRegistration.Domain.Commands
{
    public class Result
    {
        public bool Success { get; set; }
        public object Data { get; set; }
        public object Error { get; set; }
    }
}
