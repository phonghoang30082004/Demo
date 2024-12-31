using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace Demo.Models
{
    public class AbsentModel
    {

        [Key]
        public int Id { get; set; }
        public int StaffId { get; set; }
        public DateTime AbsentDate { get; set; }

        public string Reason {  get; set; }

        public bool Status {  get; set; }
        public StaffModel Staff { get; set; }


    }
}
