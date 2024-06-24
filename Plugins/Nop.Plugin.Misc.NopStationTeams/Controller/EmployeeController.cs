using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Mvc;
using Nop.Plugin.Misc.NopStationTeams.Domain;
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

    public async Task<IActionResult> Create()
    {
        var model = await _employeeModelFactory.PrepareEmployeeModelAsync(new EmployeeModel(), null);

        return View("~/Plugins/Misc.NopStationTeams/Views/Employee/Create.cshtml",model);
    }


    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Create(EmployeeModel model, bool continueEditing)
    {
        if(ModelState.IsValid)
        {
            var employee = new Employee
            {
                Name = model.Name,
                Designation = model.Designation,
                IsMVP = model.IsMVP,
                IsCertified = model.IsCertified,
                EmployeeStatusId = model.EmployeeStatusId,
            };

            await _employeeService.InsertEmployeeAsync(employee);

           
            return continueEditing? RedirectToAction("Edit", new {id= employee.Id} ):  RedirectToAction("List");
        }

        model = await _employeeModelFactory.PrepareEmployeeModelAsync(model, null);
        return View("~/Plugins/Misc.NopStationTeams/Views/Employee/Create.cshtml", model);
    }



    public async Task<IActionResult> Edit(int id)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(id);

        if (employee == null)
            return RedirectToAction("List");


        var model = await _employeeModelFactory.PrepareEmployeeModelAsync(null, employee);

        return View("~/Plugins/Misc.NopStationTeams/Views/Employee/Edit.cshtml", model);
    }


    [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
    public async Task<IActionResult> Edit(EmployeeModel model, bool continueEditing)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(model.Id);
        if (employee==null)
        {
            return RedirectToAction("List"); 
        }


        if (ModelState.IsValid)
        {

            employee.Name = model.Name;
            employee.Designation = model.Designation;
            employee.IsMVP = model.IsMVP;
            employee.IsCertified = model.IsCertified;
            employee.EmployeeStatusId = model.EmployeeStatusId;
             

            await _employeeService.UpdateEmployeeAsync(employee);

            return continueEditing ? RedirectToAction("Edit", new { id = employee.Id}) : RedirectToAction("List");
        }

        model = await _employeeModelFactory.PrepareEmployeeModelAsync(model, employee);
        return View("~/Plugins/Misc.NopStationTeams/Views/Employee/Edit.cshtml", model);
    }




    [HttpPost]
    public async Task<IActionResult> Delete(EmployeeModel model)
    {
        var employee = await _employeeService.GetEmployeeByIdAsync(model.Id);
        if (employee == null)
        {
            return RedirectToAction("List");
        }


        await _employeeService.DeleteEmployeeAsync(employee);
        return RedirectToAction("List");
    }



}
