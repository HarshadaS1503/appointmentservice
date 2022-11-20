using Microsoft.EntityFrameworkCore;
using SchedulerModule.EfCoreSetUp;
using SchedulerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModule.Repository
{

    public class AppointmentDetailsRepo : IAppointmentDetailsRepo
    {

        private readonly SchedulerModelDbContext _schedulerModelDbContext;
        public AppointmentDetailsRepo(SchedulerModelDbContext schedulerModelDbContext)
        {
            _schedulerModelDbContext = schedulerModelDbContext;
        }
        public async Task<int> AddAppointmentDetails(AppointmentDetails AppointmentModel)
        {
            if(_schedulerModelDbContext!=null)
            {
                AppointmentModel.createdOn = DateTime.Now;
                await _schedulerModelDbContext.AddAsync(AppointmentModel);
                await _schedulerModelDbContext.SaveChangesAsync();
            }
            return 0;
            
        }

        public  async Task<AppointmentDetails> GetAppointmentDetailById(int id)
        {
            if(_schedulerModelDbContext!=null)
            {
                var AptDetailsToFetch =  _schedulerModelDbContext.appointmentDetails.Where(aptId => aptId.VisitId == id).OrderBy(datetime => datetime.createdOn).FirstOrDefaultAsync();
                if (AptDetailsToFetch != null)
                {
                    return await AptDetailsToFetch;
                }
                else
                {
                    return null;
                }
            

            }
            return null;
            

        }

        public async Task<List<AppointmentDetails>> GetAllAppointmentDetails()
        {
           if(_schedulerModelDbContext!=null)
            {
                return await _schedulerModelDbContext.appointmentDetails.ToListAsync();
            }
            return null;
        }

        public async Task<int> UpdateAppointmentDetails(int id, AppointmentDetails appointmentDetailsModel)
        {
            if (_schedulerModelDbContext != null)
            {
                var AptDetailsToUpdate = await _schedulerModelDbContext.appointmentDetails.FirstOrDefaultAsync(aptId => aptId.VisitId == id);
                if (AptDetailsToUpdate != null)
                {
                    AptDetailsToUpdate.visitDate = appointmentDetailsModel.visitDate;
                    AptDetailsToUpdate.VisitTitle = appointmentDetailsModel.VisitTitle;
                    AptDetailsToUpdate.updatedOn = DateTime.Now;
                    AptDetailsToUpdate.VisitDescription = appointmentDetailsModel.VisitDescription;
                    AptDetailsToUpdate.visitStatusId = appointmentDetailsModel.visitStatusId;
                    AptDetailsToUpdate.visitTime = appointmentDetailsModel.visitTime;
                    AptDetailsToUpdate.createdBy = appointmentDetailsModel.createdBy;
                    AptDetailsToUpdate.updatedBy = appointmentDetailsModel.updatedBy;
                    _schedulerModelDbContext.appointmentDetails.Update(AptDetailsToUpdate);
                    await _schedulerModelDbContext.SaveChangesAsync();
                }

            }

            return appointmentDetailsModel.VisitId;
        }

        public void DeleteAppointmentDetails(AppointmentDetails appointment)
        {
            _schedulerModelDbContext.appointmentDetails.Remove(appointment);
            _schedulerModelDbContext.SaveChanges();
            
        }

        public bool IsAppointmentAvailable(int visitId)
        {
            return _schedulerModelDbContext.appointmentDetails.Any(e => e.VisitId == visitId);
        }

        public async Task<AppointmentDetails> GetAppointmentDetailByIdAndRoleId(int id, int roleId)
        {
            if(_schedulerModelDbContext!=null)
            {
                var appointmentDetails = await _schedulerModelDbContext.appointmentDetails.Where(i => i.VisitId == id && i.users.RoleID == roleId).FirstOrDefaultAsync();
                if(appointmentDetails!=null)
                {
                    return appointmentDetails;
                }
                return null;
            }
            return null;
        }

        public async Task<List<AppointmentDetails>> GetAppointmentDatesByPhysician(DateTime dateTime, int id)
        {
            if(_schedulerModelDbContext!=null)
            {
                List<AppointmentDetails> AvailableSlots = await _schedulerModelDbContext.appointmentDetails.Where(i => i.visitTime == dateTime && i.doctorId == id).ToListAsync();

                if(AvailableSlots != null)
                {
                    return AvailableSlots;
                }
                return null;

            }
            return null;
        }

        
    }
}
