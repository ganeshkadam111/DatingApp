using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DattingApp.API.Dto
{
    public class UserForRegistrationDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        [StringLength(8,MinimumLength =4,ErrorMessage ="You must specify password between 4 and 8")]
        public string Password { get; set; }

    }
}
