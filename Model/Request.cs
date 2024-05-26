using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Model
{
    public class Request
    {
        public int Id { get; set; }
        public DateTime DateUpdate { get; set; }
        public int? EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }
        public int TypeFaultId { get; set; }
        public TypeFault TypeFault { get; set; }
        public string? Description { get; set; }
        public int UserId { get; set; }
        public User User{ get; set; }
        public int StateRequestId { get; set; }
        public StateRequest StateRequest { get; set; }


    }
}
