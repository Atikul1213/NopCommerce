using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Plugin.Misc.NopStationTeams.Model;
using Nop.Plugin.Misc.NopStationTeams.Services;
using Nop.Services;
using Nop.Services.Localization;
using Nop.Web;
using Nop.Web.Framework.Models.Extensions;

namespace Nop.Plugin.Misc.NopStationTeams.Factories;
public class EmployeeModelFactory : IEmployeeModelFactory
{
    private readonly IEmployeeService _employeeService;
    private readonly ILocalizationService _localizationService;
    public EmployeeModelFactory(IEmployeeService employeeService, ILocalizationService localizationService)
    {
        _employeeService = employeeService;
        _localizationService = localizationService;
    }

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
                //fill in model values from the entity
                var employeeModel = new EmployeeModel()
                {
                    Designation = employee.Designation,
                    EmployeeStatusId = employee.EmployeeStatusId,
                    Id = employee.Id,
                    Name = employee.Name,
                    IsCertified = employee.IsCertified,
                    IsMVP = employee.IsMVP,
                    EmployeeStatusStr = await _localizationService.GetLocalizedEnumAsync(employee.EmployeeStatus)
                };

             
                return employeeModel;
            });
        });

        return model;
    }

    public async Task<EmployeeSearchModel>PrepareEmployeeSearchModelAsync(EmployeeSearchModel searchModel)
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
}
