using apbd_11.Models.Requests;
using apbd_11.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_11.Services
{
    public interface IDoctorsServiceDb
    {
        public GetDoctorsResponse getDoctor(int id);
        public InsertDoctorResponse InsertDoctor(InsertDoctorRequest request);
        public UpdateDoctorResponse UpdateDoctor(UpdateDoctorRequest request);
        public DeleteDoctorResponse DeleteDoctor(int id);
    }
}
