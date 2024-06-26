using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Plugin.Misc.NopStationTeams.Factories;
using Nop.Plugin.Misc.NopStationTeams.Services;
using Nop.Web.Framework.Components;

namespace Nop.Plugin.Misc.NopStationTeams.Components;
public class EmployeeComponent : NopViewComponent
{
    #region Fields
    
    private readonly IEmployeeService _employeeService;
    private readonly IEmployeeHomeModelFactory _employeeHomeModelFactory;

    #endregion

    #region Ctor
    public EmployeeComponent(IEmployeeService employeeService, IEmployeeHomeModelFactory employeeModelFactory)
    {
        _employeeService = employeeService;
        _employeeHomeModelFactory = employeeModelFactory;
    }

    #endregion

    #region Method
    public async Task<IViewComponentResult> InvokeAsync(string widgetZone, object additionalData)
    {
        var employees = await _employeeService.SearchEmployeesAsync(
             name: null,
             statusId: (int) EmployeeStatus.Active
         );

        if (!employees.Any())
            return Content("");
        var model = await _employeeHomeModelFactory.PrepareEmployeeHomeListModelAsync(employees);

        return View("~/Plugins/Misc.NopStationTeams/Views/HomePage.cshtml", model);
    }

    #endregion
}
