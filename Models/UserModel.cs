using DotnetWebApiUnitTesting.DTOs.Requests;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace DotnetWebApiUnitTesting.Models
{
    [Table("user")]
    public class UserModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long id { get; set; }

        public required string name { get; set; }

        public required string email { get; set; }

        [Column("contact_number")]
        public required string contactNumber { get; set; }  

        public string? address { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Column("created_at")]
        public DateTime createdAt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed), Column("updated_at")]
        public DateTime updatedAt { get; set; }



        public UserModel()
        {
            // default constructor
        }


        [SetsRequiredMembers]
        public UserModel(CreateUserRequest request)
        {
            //if (string.IsNullOrEmpty(request.name))
            //{
            //    throw new ArgumentNullException("Required property cannot be null or empty "+nameof(request.name));
            //}

            //if (string.IsNullOrEmpty(request.email))
            //{
            //    throw new ArgumentNullException("Required property cannot be null or empty " + nameof(request.email));
            //}

            //if (string.IsNullOrEmpty(request.contactNumber))
            //{
            //    throw new ArgumentNullException("Required property cannot be null or empty " + nameof(request.contactNumber));
            //}

            this.name = request.name;
            this.email = request.email;
            this.contactNumber = request.contactNumber;
            this.address = request.address;
        }

    }
}
