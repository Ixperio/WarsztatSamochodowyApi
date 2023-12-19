using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace WarsztatApi.Dto
{
    public class UserDto
    {
        
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Birthday { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

    }

    public class UserDtoLogin
    {
        [Required]
        public int Id { get; set; }

    }

    public class UserDtoRegister
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Name { get; set; }
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        public string Surname { get; set; }
        [Required]
        [MinLength(9)]
        [MaxLength(13)]
        public string Phone { get; set; }
        [Required]
        public string Birthday { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [EmailAddress]
        public string EmailConfirm { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MinLength(8)]
        public string PasswordConfirm { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Terms { get; set; }
    }

    public class UserTypeDto
    {
        [Required]
        public string Nazwa {  get; set; }
    
    }

    public class UserDtoUpdateName
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [RegularExpression(@"^[a-zżźćńłśąęóA-ZĄĘŻŚŹĆŃŁÓĘ\s]{2,40}$")]
        public string Name { get; set; }

        [Required]
        public string trustString { get; set; }
    }

    public class UserDtoUpdateSurname
    {
        [Required]
        [MinLength(2)]
        [MaxLength(40)]
        [RegularExpression(@"^[a-zżźćńłśąęóA-ZĄĘŻŚŹĆŃŁÓĘ\s]{2,40}$")]
        public string Surname { get; set; }

        [Required]
        public string trustString { get; set; }
    }

    public class UserDtoUpdateEmail
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [EmailAddress]
        public string EmailConfirm { get; set; }

        [Required]
        public string trustString { get; set; }
    }

    public class UserDtoUpdatePassword
    {
        [Required]
        [MinLength(8)]
        public string ActualPassword { get; set; }
        [Required]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        [MinLength(8)]
        public string PasswordConfirm { get; set; }

        [Required]
        public string trustString { get; set; }
    }

    public class UserDtoUpdateBirthday
    {
        [Required]
        [DataType(DataType.Date)]
        public string Birthday { get; set; }

        [Required]
        public string trustString { get; set; }
    }

    public class UserDtoUpdatePhone
    {
        [Required]
        [MinLength(9)]
        [MaxLength(9)]
        [RegularExpression(@"^[0-9]{9}$", ErrorMessage = "Format should be 123456789")]
        public string Phone { get; set; }

        [Required]
        public string trustString { get; set; }
    }

    public class UserDtoUpdateAdress
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z0-9\s]{3,100}$")]
        public string Adress { get; set; }

        [Required]
        public string trustString { get; set; }
    }

    public class UserDtoUpdatePost
    {
        [Required]
        [MaxLength(6)]
        [MinLength(6)]
        [RegularExpression(@"^\d{2}-\d{3}$", ErrorMessage = "Format should be XX-XXX")]
        public string Post { get; set; }

        [Required]
        public string trustString { get; set; }
    }

    public class UserDtoUpdateCity
    {
        [Required]
        [MinLength(3)]
        [MaxLength(40)]
        [RegularExpression(@"^[\p{L}0-9\s\-]+$", ErrorMessage = "Format jest nie poprawny!")]
       
        public string City { get; set; }

        [Required]
        public string trustString { get; set; }
    }

    public class UserDtoDelete
    {
        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        public string trustString { get; set; }
    }

}
