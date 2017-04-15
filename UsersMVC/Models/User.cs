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

        public User(string lo)
        {
            Login = lo;
            FirstName = lo;
            LastName = lo;
            Phone = lo;
            Address = lo;
            Email = lo;
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

        //   [Required (ErrorMessage = "Please enter your first name.")]
        [Column("first_name")]
        public string FirstName
        {
            get;
            set;
        }

        //   [Required(ErrorMessage = "Please enter your last name.")]
        [Column("last_name")]
        public string LastName
        {
            get;
            set;

        }

        // [Required(ErrorMessage = "Please enter your phone number.")]
        [Column("phone_number")]
        public string Phone
        {
            get;
            set;
        }

        [Required (ErrorMessage = "Please enter your Email.")]
       // [Index(IsUnique = true)]
        [Column("email")]
        public string Email
        {
            get;
            set;
        }

        //[Required(ErrorMessage = "Please enter your home address.")]
        [Column("home_address")]
        public string Address
        {
            get;
            set;
        }
    }

}