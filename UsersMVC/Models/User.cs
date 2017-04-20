using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UsersMVC.Models
{
    [Table("Users")]
    public class User : IUser
    {
        public User()
        {

        }

        [Key]
        [Column("id")]
        public long ID
        {
            get;
            set;
        }

        [Column("login")]
        [Index(IsUnique = true)]
        [Required (ErrorMessage = "Please enter your login.")]
        [MaxLength(25, ErrorMessage = "Login must be 5-25 characters."), MinLength(5, ErrorMessage = "Login must be 5-25 characters.")]
        public string Login
        {
            get;
            set;
        }

        [Column("first_name")]
        public string FirstName
        {
            get;
            set;
        }

        [Column("last_name")]
        public string LastName
        {
            get;
            set;

        }

        [Column("phone_number")]
        public string Phone
        {
            get;
            set;
        }

        [Index(IsUnique = true)]
        [StringLength(450)]
        [Required (ErrorMessage = "Please enter your Email.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Column("email")]
        public string Email
        {
            get;
            set;
        }

        [Column("home_address")]
        public string Address
        {
            get;
            set;
        }

        [Column("password")]
        [Required(ErrorMessage = "Please enter password.")]
        [MaxLength(15, ErrorMessage = "Password must be 5-15 characters."), MinLength(5, ErrorMessage = "Password must be 5-15 characters.")]
        public string Password
        {
            get;
            set;
        }
    }

}