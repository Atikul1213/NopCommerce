using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;
using Nop.Services.Cms;
using Nop.Services.Common;
using Nop.Services.Localization;
using Nop.Services.Plugins;

namespace Nop.Plugin.Misc.NopStationTeams
{
    public class NopStationTeamsPlugin : BasePlugin , IMiscPlugin
    {

        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;
        public NopStationTeamsPlugin(IWebHelper webHelper,ILocalizationService localizationService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
        }



        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/Employee/List";
        }
        public override async Task InstallAsync()
        {

            //locales
            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Admin.Misc.Employee.Fields.Name"] = "Name",
                ["Admin.Misc.Employee.Fields.Designation"] = "Designation",
                ["Admin.Misc.Employee.Fields.IsMVP"] = "IsMVP",
                ["Admin.Misc.Employee.Fields.IsCertified"] = "IsCertified",
                ["Admin.Misc.Employee.Fields.EmployeeStatus"] = "Status",  
                
                ["Admin.Misc.Employee.Fields.Name.Hint"] = "Enter Employee Name.",
                ["Admin.Misc.Employee.Fields.Designation.Hint"] = "Enter Employee Designation.",
                ["Admin.Misc.Employee.Fields.IsMVP.Hint"] = "Checked if Employee IsMVP.",
                ["Admin.Misc.Employee.Fields.IsCertified.Hint"] = "Checked if Employee IsCertified.",
                ["Admin.Misc.Employee.Fields.EmployeeStatus"] = "Select Employee Status.", 


                ["Admin.Misc.Employee.List.Name"] = "Name", 
                ["Admin.Misc.Employee.List.EmployeeStatus"] = "Status", 
                ["Admin.Misc.Employee.List.Name.Hint"] = "Search by Employee Name", 
                ["Admin.Misc.Employee.List.EmployeeStatus.Hint"] = "Search by Employee Status", 
            });
            await base.InstallAsync();
        }


        public override async Task UninstallAsync()
        {
           
            await base.UninstallAsync();
        }


    }
}
