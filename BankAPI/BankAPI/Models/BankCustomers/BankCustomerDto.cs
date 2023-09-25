//using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
//using BankAPI.CustomAttributes;


namespace BankAPI.Models.BankCustomers
{
    public class BankCustomerDto
    {
        [Required]
        //[FourDigit(ErrorMessage = "Id must be a 4-digit number.")]
        //[MaxDigits(4, ErrorMessage = "Id must have at most 4 digits.")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
    }
}
