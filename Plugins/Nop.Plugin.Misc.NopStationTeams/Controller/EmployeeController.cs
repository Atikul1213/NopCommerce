using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Misc.NopStationTeams.Factories;
using Nop.Plugin.Misc.NopStationTeams.Model;
using Nop.Plugin.Misc.NopStationTeams.Services;
using Nop.Web.Framework;
using Nop.Web.Framework.Controllers;
using Nop.Web.Framework.Mvc.Filters;

namespace Nop.Plugin.Misc.NopStationTeams.Controller;
[AuthorizeAdmin]
[Area(AreaNames.ADMIN)]
public class EmployeeController : BasePluginController
{
    private readonly IEmployeeService _employeeService;
    private readonly IEmployeeModelFactory _employeeModelFactory;
    public EmployeeController(IEmployeeService employeeService, IEmployeeModelFactory employeeModelFactory)
    {
        _employeeService = employeeService;
        _employeeModelFactory = employeeModelFactory;
    }


    public async Task<IActionResult> List()
    {
        var searchModel = await _employeeModelFactory.PrepareEmployeeSearchModelAsync(new EmployeeSearchModel());

        return View("~/Plugins/Misc.NopStationTeams/Views/Employee/List.cshtml",searchModel);
    }



    [HttpPost]
    public async Task<IActionResult> List(EmployeeSearchModel searchModel)
    {
        var model = await _employeeModelFactory.PrepareEmployeeListModelAsync(searchModel);

        return Json(model);
    }



    



    public async Task<IActionResult> Configure()
    {
         
        return View("~/Plugins/Misc.NopStationTeams/View/Configure.cshtml");
    }

    




}
