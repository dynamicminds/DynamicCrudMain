using DynamicCrud.Api.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicCrud.Api.Interfaces
{
    public interface ICrudDto
    {
        string IsValidData(bool isInsert);
    }
}
