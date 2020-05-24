using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_11.Models.Responses
{
    public class UpdateDoctorResponse
    {
        public int IdDoctor { get; set; }
        public string Email { get; set; }
        public string PrevEmail { get; set; }
    }
}
