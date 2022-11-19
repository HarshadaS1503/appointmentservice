using InboxService.ViewModel;
using SchedulerModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InboxService.Models
{
    public interface IAppointmentListRepo
    {
        Task<List<ViewAppointmentModel>> DashboardAppointmentListCount(int id);

        Task<AppointmentDetails> Appointmentlist(int id);

        Task<int> UpdateAppointmentlist(UpdateAppointmentModel updateAppointmentModel);
    }
}
