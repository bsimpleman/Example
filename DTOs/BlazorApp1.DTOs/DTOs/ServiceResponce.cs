using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp1.DTOs.DTOs
{
    public class ServiceResponse<T>
    {
        public T ReturnType { get; set; }
        public string? Message { get; set; }
        public bool Worked { get; set; } = true;
    }
}
