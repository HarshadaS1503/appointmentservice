using LoginService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchedulerModule.Models
{
    public class AppointmentDetails
    {
        [Key]
        public int VisitId { get; set; }
        public string VisitTitle { get; set; }
        public string VisitDescription { get; set; }

        //[ForeignKey("users")]
        public int doctorId { get; set; }
        //[ForeignKey("users")]
        public int patientId { get; set; }
        public DateTime visitDate { get; set; }
        public DateTime visitTime { get; set; }
        
        public int createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public int updatedBy { get; set; }
         
        public DateTime updatedOn { get; set; }
        public int visitStatusId { get; set; }
        public ApplicationUser users { get; set; }




    }
}
