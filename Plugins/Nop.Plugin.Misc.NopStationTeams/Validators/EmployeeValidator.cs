using FluentValidation;
using Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Model;
using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Services.Localization;
using Nop.Web.Framework.Validators;

namespace Nop.Plugin.Misc.NopStationTeams.Validators
{
    public partial class EmployeeValidator : BaseNopValidator<EmployeeModel>
    {
        public EmployeeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Misc.Employee.Fields.Name.Required"));
            RuleFor(x => x.Designation).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Misc.Employee.Fields.Designation.Required"));
            RuleFor(x => x.PictureId).NotEmpty().WithMessageAwait(localizationService.GetResourceAsync("Admin.Misc.Employee.Fields.Picture.Required"));



            SetDatabaseValidationRules<Employee>();
        }
    }
}