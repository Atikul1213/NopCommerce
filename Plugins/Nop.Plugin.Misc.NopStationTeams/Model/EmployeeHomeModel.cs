using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Web.Framework.Models;
using Nop.Web.Models.Media;

namespace Nop.Plugin.Misc.NopStationTeams.Model;
public record EmployeeHomeModel : BaseNopEntityModel
{
    public EmployeeHomeModel()
    {
        Picture = new PictureModel();
    }

    public string Name { get; set; }
    public PictureModel Picture { get; set; }
    public bool IsMVP { get; set; }
    public bool IsCertified { get; set; }
    public EmployeeStatus EmployeeStatus { get; set; }
    public string EmployeeStatusStr { get; set; }
    public string Designation{ get; set; }
}
