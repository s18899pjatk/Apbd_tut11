using apbd_11.Entities;
using apbd_11.Models.Requests;
using apbd_11.Models.Responses;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apbd_11.Services
{
    public class DoctorsServiceDb : IDoctorsServiceDb
    {

        private readonly DoctorDbContext _doctorDbContext;

        public DoctorsServiceDb(DoctorDbContext doctorDbContext)
        {
            this._doctorDbContext = doctorDbContext;
        }

        public GetDoctorsResponse getDoctor(int id)
        {
            var exists = _doctorDbContext.Doctors.Any(d => d.IdDoctor.Equals(id));
            if (exists)
            {
                var doctor = _doctorDbContext
             .Doctors
             .Where(d => d.IdDoctor.Equals(id)).FirstOrDefault();

                return new GetDoctorsResponse
                {
                    IdDoctor = doctor.IdDoctor,
                    LastName = doctor.LastName

                };
            }
            return null;
        }

        public InsertDoctorResponse InsertDoctor(InsertDoctorRequest request)
        {
            //id auto generated
            var doctor = new Doctor()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };
            _doctorDbContext.Add(doctor);
            _doctorDbContext.SaveChanges();

            return new InsertDoctorResponse
            {
                IndexNumber = doctor.IdDoctor,
                LastName = doctor.LastName
            };
        }

        public UpdateDoctorResponse UpdateDoctor(UpdateDoctorRequest request)
        {
            var exists = _doctorDbContext.Doctors.Any(d => d.IdDoctor.Equals(request.IdDoctor));
            if (!exists) { return null; }

            var prevEmail = _doctorDbContext.Doctors.Where(s => s.IdDoctor.Equals(request.IdDoctor))
             .Select(s => s.Email).FirstOrDefault();
            var d = new Doctor
            {
                IdDoctor = request.IdDoctor,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            _doctorDbContext.Attach(d);
            _doctorDbContext.Entry(d).State = EntityState.Modified;
            _doctorDbContext.SaveChanges();

            return new UpdateDoctorResponse
            {
                IdDoctor = d.IdDoctor,
                Email = d.Email,
                PrevEmail = prevEmail
            };
        }

        public DeleteDoctorResponse DeleteDoctor(int id)
        {
            var exists = _doctorDbContext.Doctors.Any(d => d.IdDoctor.Equals(id));
            if (!exists) return null;

            //prescription deletes automatically 
            var d = new Doctor
            {
                IdDoctor = id
            };
            _doctorDbContext.Attach(d);
            _doctorDbContext.Remove(d);
            _doctorDbContext.SaveChanges();

            return new DeleteDoctorResponse
            {
                IdDoctor = d.IdDoctor
            };
        }
    }
}
