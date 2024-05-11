using System.Text.Json.Serialization;

namespace DotnetWebApiUnitTesting.DTOs.Requests
{
    public class CreateUserRequest
    {
        public required string name {  get; set; }

        public required string email {  get; set; }

        [JsonPropertyName("contact_number")]
        public required string contactNumber {  get; set; }

        public  string? address {  get; set; }

    }
}
