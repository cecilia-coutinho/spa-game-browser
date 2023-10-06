using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SPAGameBrowser.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, NotNull]
        [Display (Name = "Nickname")]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "String length must be greater than or equal 4 characters and not exceed 15 characters")]
        public string? Nickname { get; set; }

        public List<UserScoreBoard>? UserScoreBoards { get; set; }
    }
}
