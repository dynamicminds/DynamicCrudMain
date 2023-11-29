using DynamicCrud.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Api.Dto
{
    public class RolesDto : ICrudDto
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string IsValidData(bool isInsert)
        {
            List<string> errorFields = new List<string>();

            if ((isInsert && Id > 0) || (!isInsert && Id <= 0))
            {
                errorFields.Add(nameof(Id));
            }

            if (string.IsNullOrEmpty(Name))
            {
                errorFields.Add(nameof(Action));
            }

            return string.Join(", ", errorFields);
        }
    }
}
