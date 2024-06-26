using Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Model;
using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Plugin.Misc.NopStationTeams.Services;
using Nop.Services;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Factories;
public class EmployeeModelFactory : IEmployeeModelFactory
{
    #region Fields

    private readonly IEmployeeService _employeeService;
    private readonly ILocalizationService _localizationService;
    private readonly IPictureService _pictureService;

    #endregion


    #region Ctor
    public EmployeeModelFactory(IEmployeeService employeeService, ILocalizationService localizationService, IPictureService pictureService)
    {
        _employeeService = employeeService;
        _localizationService = localizationService;
        _pictureService = pictureService;
    }

    #endregion

    #region Method
    public async Task<EmployeeListModel> PrepareEmployeeListModelAsync(EmployeeSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(nameof(searchModel));
        var employees = await _employeeService.SearchEmployeesAsync(searchModel.Name, searchModel.EmployeeStatusId,

                       pageIndex: searchModel.Page - 1,
                       pageSize: searchModel.PageSize);

        //prepare grid model

        var model = await new EmployeeListModel().PrepareToGridAsync(searchModel, employees, () =>
        {
            return employees.SelectAwait(async employee =>
            {
                ////fill in model values from the entity
                //var employeeModel = new EmployeeModel()
                //{
                //    Designation = employee.Designation,
                //    EmployeeStatusId = employee.EmployeeStatusId,
                //    Id = employee.Id,
                //    Name = employee.Name,
                //    IsCertified = employee.IsCertified,
                //    IsMVP = employee.IsMVP,
                //    EmployeeStatusStr = await _localizationService.GetLocalizedEnumAsync(employee.EmployeeStatus)
                //};


                return await PrepareEmployeeModelAsync(null, employee, true);
            });
        });

        return model;
    }





    public async Task<EmployeeModel> PrepareEmployeeModelAsync(EmployeeModel model, Employee employee, bool excludeProperties = false)
    {
        if (employee != null)
        {
            if (model == null)
                //fill in model values from the entity
                model = new EmployeeModel()
                {
                    Designation = employee.Designation,
                    EmployeeStatusId = employee.EmployeeStatusId,
                    Id = employee.Id,
                    Name = employee.Name,
                    IsCertified = employee.IsCertified,
                    IsMVP = employee.IsMVP,
                    EmployeeStatusStr = await _localizationService.GetLocalizedEnumAsync(employee.EmployeeStatus),
                    PictureId = employee.PictureId
                };
            var picture = await _pictureService.GetPictureByIdAsync(employee.PictureId);
            (model.PictureThumbnailUrl, _) = await _pictureService.GetPictureUrlAsync(picture, 75);


            model.EmployeeStatusStr = await _localizationService.GetLocalizedEnumAsync(employee.EmployeeStatus);
        }

        if (!excludeProperties)
            model.AvailableEmployeeStatusOptions = (await EmployeeStatus.Active.ToSelectListAsync()).ToList();

        return model;
    }



    public async Task<EmployeeSearchModel> PrepareEmployeeSearchModelAsync(EmployeeSearchModel searchModel)
    {
        ArgumentNullException.ThrowIfNull(nameof(searchModel));
        searchModel.AvailableEmployeeStatusOptions = (await EmployeeStatus.Active.ToSelectListAsync()).ToList();
        searchModel.AvailableEmployeeStatusOptions.Insert(0,
             new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem
             {
                 Text = "All",
                 Value = "0"

             });

        //prepare page parameters
        searchModel.SetGridPageSize();

        return searchModel;
    }

    #endregion
}
