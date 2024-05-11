namespace DotnetWebApiUnitTesting.DTOs
{
    public class MessageDTO
    {
        public string message {  get; set; }

        public MessageDTO()
        {
            
        }

        public MessageDTO(string message)
        {
            this.message = message;
        }
    }
}
