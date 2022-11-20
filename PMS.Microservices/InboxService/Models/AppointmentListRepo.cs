using InboxService.EFCoreSetUp;
using InboxService.ViewModel;
using LoginService.EFCoreSetUp;
using Microsoft.EntityFrameworkCore;
using SchedulerModule.EfCoreSetUp;
using SchedulerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.Models
{
    public class AppointmentListRepo : IAppointmentListRepo
    {
        private readonly NotesDbContext _notesDbContext;
        private readonly SchedulerModelDbContext _schedulerModelDbContext;
        private readonly LoginContext _loginContext;
        public AppointmentListRepo(NotesDbContext notesDbContext, SchedulerModelDbContext schedulerModelDbContext, LoginContext loginContext)
        {
            _notesDbContext = notesDbContext;
            _schedulerModelDbContext = schedulerModelDbContext;
            _loginContext = loginContext;
        }
        public Task<AppointmentDetails> Appointmentlist(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ViewAppointmentModel>> DashboardAppointmentListCount(int id)
        {
            if (_notesDbContext != null)
            {
                DateTime currentDate = DateTime.Now;
                DateTime startWeek = currentDate.AddDays(-(int)DateTime.Today.DayOfWeek + (int)DayOfWeek.Sunday);
                DateTime endWeek = startWeek.AddDays(6);

                var appointments = await _schedulerModelDbContext.appointmentDetails.
                    Where(a => (a.patientId == id || a.doctorId == id) &&
                    (a.visitDate.Date >= startWeek.Date && a.visitDate.Date <= endWeek.Date)).ToListAsync();
                var viewAppointmentModel = new List<ViewAppointmentModel>();
                foreach (var items in appointments)
                {
                    ViewAppointmentModel model = new ViewAppointmentModel();

                    var docName = _loginContext.Users.FirstOrDefault(d => d.Id == items.doctorId);
                    var patName = _loginContext.Users.FirstOrDefault(d => d.Id == items.patientId);

                    model.VisitId = items.VisitId;
                    model.VisitTitle = items.VisitTitle;
                    model.VisitDescription = items.VisitDescription;
                    model.doctorId = items.doctorId;
                    model.patientId = items.patientId;
                    model.visitDate = items.visitDate;
                    //model.visitTime = items.visitTime;
                    model.DoctorName = docName.Title + " " + docName.FirstName + " " + docName.LastName;
                    model.PatientName = patName.Title + " " + patName.FirstName + " " + patName.LastName;
                    //model.VisitStatusName = _notesDbContext.VisitStatuses.FirstOrDefault(v => v.VisitStatusId == items.visitStatusId).VisitStatusName;
                    model.BackColor = items.visitDate.ToString("MM/dd/yyyy") == DateTime.Today.ToString("MM/dd/yyyy") ? "yes" : "no";
                    viewAppointmentModel.Add(model);
                }
                return viewAppointmentModel;
                //if (role == "nurse")
                //{
                //return await _notesDbContext.AppointmentDetails.ToListAsync();
                //}
                //else
                //{
                //    return await _appointmentDbContext.Appointments.Where(x => x.PatientId == userId || x.PhysicianId == userId).ToListAsync();
                //}

            }
            else
                return null;
        }

        public async Task<int> UpdateAppointmentlist(UpdateAppointmentModel updateAppointmentModel)
        {
            if (_notesDbContext != null)
            {
                var result = await _schedulerModelDbContext.appointmentDetails.FirstOrDefaultAsync(x => x.VisitId == updateAppointmentModel.AppointmentId);

                if (result != null)
                {
                    //result.visitStatusId = updateAppointmentModel.UpdateType;

                    _schedulerModelDbContext.appointmentDetails.Update(result);
                    return await _schedulerModelDbContext.SaveChangesAsync();
                }
            }
            return 0;
        }
    }
}
