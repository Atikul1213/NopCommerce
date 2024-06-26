using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;

using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Plugin.Misc.NopStationTeams.Model;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Models.Media;

namespace Nop.Plugin.Misc.NopStationTeams.Factories;
public class EmployeeHomeModelFactory : IEmployeeHomeModelFactory
{
    private readonly ILocalizationService _localizationService;
    private readonly IPictureService _pictureService;
    public EmployeeHomeModelFactory(ILocalizationService localizationService, IPictureService pictureService)
    {
        _localizationService = localizationService;
        _pictureService = pictureService;
    }

    public async Task<IList<EmployeeHomeModel>> PrepareEmployeeHomeListModelAsync(IList<Employee> employee)
    {
         var model = new List<EmployeeHomeModel>();
         
        foreach(var emp in employee)
        {
            model.Add(await PrepareEmployeeHomeModelAsync(emp));
        }
        return model;
    }

    public async Task<EmployeeHomeModel> PrepareEmployeeHomeModelAsync(Employee employee)
    {
        var picture = await _pictureService.GetPictureByIdAsync(employee.PictureId);

        var pictureModel = new PictureModel
        { 
            Id = employee.PictureId,
            AlternateText = "Picture of " + employee.Name,
            Title = "Picture of " + employee.Name,
            ThumbImageUrl = (await _pictureService.GetPictureUrlAsync(picture, 200)).Url,
            FullSizeImageUrl = (await _pictureService.GetPictureUrlAsync(picture)).Url

        };

        return new EmployeeHomeModel()
        {
            Id = employee.Id,
            Name = employee.Name,
            IsMVP = employee.IsMVP,
            IsCertified = employee.IsCertified,
            Picture = pictureModel
        };
    }
}
