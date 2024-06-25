using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace Nop.Plugin.Misc.NopStationTeams.Domain
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public bool IsMVP { get; set; }
        public bool IsCertified { get; set; }
        public int EmployeeStatusId { get; set; }

        public int PictureId { get; set; }
        public EmployeeStatus EmployeeStatus
        {
            get => (EmployeeStatus)EmployeeStatusId;
            set => EmployeeStatusId = (int)value;
        }

      
    }

    public enum EmployeeStatus
    {
        Active = 10,
        Inactive = 20,
        Blocked = 30
    }


}
