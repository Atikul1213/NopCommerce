using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Plugin.Misc.NopStationTeams.Components;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;

namespace Nop.Plugin.Misc.NopStationTeams
{
    public class NopStationTeamsPlugin : BasePlugin , IWidgetPlugin
    {
        #region Fields

        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor
        public NopStationTeamsPlugin(IWebHelper webHelper,ILocalizationService localizationService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
        }

        #endregion

        #region Method

        public bool HideInWidgetList => false;

        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/Employee/List";
        }

        #endregion

        #region WidgetZone
        public Type GetWidgetViewComponent(string widgetZone)
        {
          //  if (widgetZone == PublicWidgetZones.HomepageTop)
          //  {
                return typeof(EmployeeComponent);
            //}
        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(
                new List<string>
                {
                PublicWidgetZones.HomepageTop,
                });
        }

        #endregion


        #region Install
        public override async Task InstallAsync()
        {

            //locales
            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {

                ["Admin.Misc.Employees"] = "Employees",
                ["Admin.Misc.Employees.AddNew"] = "Add new Employee",
                ["Admin.Misc.Employees.EditDetails"] = "Edit Employee Details",
                ["Admin.Misc.Employees.BackToList"] = "Back to Employee List",


                ["Admin.Misc.Employee.Fields.Name"] = "Name",
                ["Admin.Misc.Employee.Fields.Designation"] = "Designation",
                ["Admin.Misc.Employee.Fields.IsMVP"] = "IsMVP",
                ["Admin.Misc.Employee.Fields.IsCertified"] = "IsCertified",
                ["Admin.Misc.Employee.Fields.EmployeeStatus"] = "Status",  
                [("Admin.Misc.Employee.Fields.Picture")] = "Picture",
                
                ["Admin.Misc.Employee.Fields.Name.Hint"] = "Enter Employee Name.",
                ["Admin.Misc.Employee.Fields.Designation.Hint"] = "Enter Employee Designation.",
                ["Admin.Misc.Employee.Fields.IsMVP.Hint"] = "Checked if Employee IsMVP.",
                ["Admin.Misc.Employee.Fields.IsCertified.Hint"] = "Checked if Employee IsCertified.",
                ["Admin.Misc.Employee.Fields.EmployeeStatus.Hint"] = "Select Employee Status.", 
                [("Admin.Misc.Employee.Fields.Picture.Hint")] = "Profile Image",


                ["Admin.Misc.Employee.List.Name"] = "Name", 
                ["Admin.Misc.Employee.List.EmployeeStatus"] = "Status", 
                ["Admin.Misc.Employee.List.Name.Hint"] = "Search by Employee Name", 
                ["Admin.Misc.Employee.List.EmployeeStatus.Hint"] = "Search by Employee Status", 
            });
            await base.InstallAsync();
        }

        #endregion


        #region Uninstall
        public override async Task UninstallAsync()
        {
           
            await base.UninstallAsync();
        }

        #endregion

    }
}
