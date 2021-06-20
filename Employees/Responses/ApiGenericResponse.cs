using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employees.Responses
{
    public class ApiGenericResponse<T>
    {
        public ApiGenericResponse(T data)
        {
            Data = data;
        }
        public T Data { get; set; }

        public Metadata Meta { get; set; }
    }
}
