using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Model;
public record EmployeeListModel : BasePagedListModel<EmployeeModel>
{
    public string Name { get; set; }
}
