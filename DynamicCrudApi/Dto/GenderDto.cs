using DynamicCrud.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Api.Dto
{
    public class GenderDto : ICrudDto
    {
        public int Id { get; set; }
        public char Gender { get; set; }
        public string? Description { get; set; }
        public string IsValidData(bool isInsert)
        {
            List<string> errorFields = new List<string>();

            if ((isInsert && Id > 0) || (!isInsert && Id <= 0))
            {
                errorFields.Add(nameof(Id));
            }

            if (char.IsLetter(Gender))
            {
                errorFields.Add(nameof(Gender));
            }

            if (string.IsNullOrEmpty(Description))
            {
                errorFields.Add(nameof(Description));
            }

            return string.Join(", ", errorFields);
        }
    }
}
