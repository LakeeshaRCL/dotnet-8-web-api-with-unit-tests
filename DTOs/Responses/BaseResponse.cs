using System.Text.Json.Serialization;

namespace DotnetWebApiUnitTesting.DTOs.Responses
{
    public class BaseResponse
    {
        [JsonPropertyName("status_code")]
        public int statusCode { get; set; }

        public object? data { get; set; }


        public BaseResponse()
        {
            
        }



        public BaseResponse(int statusCode, object? data)
        {
            this.statusCode = statusCode;
            this.data = data;
        }


        public BaseResponse(int statusCode, string message)
        {
            this.statusCode = statusCode;
            this.data = new MessageDTO(message);
        }
    }
}
