using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IbmAdmissions2019.Models
{
    public class TestSlotViewModel
    {
        public int SlotId { get; set; }
        public int CenterId { get; set; }
        public String CenterName { get; set; }
        public System.DateTime TestDateTime { get; set; }
        public int RollNumberStart { get; set; }
        public int RollNumberEnd { get; set; }
    }

    public class TestSlotAssignmentModel
    {
        public DateTime SlotDateTime { get; set; }
        public int totalCapacity { get; set; }
        public int usedCapacity { get; set; }

        public int RollNumberStart { get; set; }
        public int CurrentRollNumber { get; set; }
    }
}