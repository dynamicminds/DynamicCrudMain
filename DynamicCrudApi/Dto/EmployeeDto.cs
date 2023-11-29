using DynamicCrud.Api.Helpers;
using DynamicCrud.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Api.Dto
{
    public class EmployeeDto : ICrudDto
    {
        public int Id { get; set; }

        [Required]
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //[DataType(DataType.Date)]
        public DateTime? DOB { get; set; }
        public string? Address { get; set; }
        //[Required]
        public int GenderId { get; set; }
        public int? OccupationId { get; set; }
        public bool IsActive { get; set; }
        public GenderDto? Gender { get; set; }
        public string? PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }
        public string IsValidData(bool isInsert)
        {
            List<string> errorFields = new List<string>();

            if ((isInsert && Id > 0) || (!isInsert && Id <= 0))
            {
                errorFields.Add(nameof(Id));
            }

            if (string.IsNullOrEmpty(FirstName))
            {
                errorFields.Add(nameof(FirstName));
            }

            if (string.IsNullOrEmpty(LastName))
            {
                errorFields.Add(nameof(LastName));
            }

            if (IsActive == false)
            {
                errorFields.Add(nameof(IsActive));
            }

            if (string.IsNullOrEmpty(EmailAddress) || ValidationHelper.IsValidEmail(EmailAddress))
            {
                errorFields.Add(nameof(EmailAddress));
            }

            if (string.IsNullOrEmpty(PhoneNumber))
            {
                errorFields.Add(nameof(PhoneNumber));
            }

            return string.Join(", ", errorFields);
        }
    }
}
