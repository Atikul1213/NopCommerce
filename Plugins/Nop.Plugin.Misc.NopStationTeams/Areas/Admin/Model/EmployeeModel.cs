using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nop.Web.Framework.Models;
using Nop.Web.Framework.Mvc.ModelBinding;

namespace Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Model;
public record EmployeeModel : BaseNopEntityModel
{
    public EmployeeModel()
    {
        AvailableEmployeeStatusOptions = new List<SelectListItem>();
    }
    [NopResourceDisplayName("Admin.Misc.Employee.Fields.Name")]
    public string Name { get; set; }

    [NopResourceDisplayName("Admin.Misc.Employee.Fields.Designation")]
    public string Designation { get; set; }

    [NopResourceDisplayName("Admin.Misc.Employee.Fields.IsMVP")]
    public bool IsMVP { get; set; }

    [NopResourceDisplayName("Admin.Misc.Employee.Fields.IsCertified")]
    public bool IsCertified { get; set; }

    public string PictureThumbnailUrl { get; set; }

    [UIHint("Picture")]
    [NopResourceDisplayName("Admin.Misc.Employee.Fields.Picture")]
    public int PictureId { get; set; }

    [NopResourceDisplayName("Admin.Misc.Employee.Fields.EmployeeStatus")]
    public int EmployeeStatusId { get; set; }

    [NopResourceDisplayName("Admin.Misc.Employee.Fields.EmployeeStatus")]
    public string EmployeeStatusStr { get; set; }


    public IList<SelectListItem> AvailableEmployeeStatusOptions { get; set; }


}
