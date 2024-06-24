using Nop.Plugin.Misc.NopStationTeams.Model;

namespace Nop.Plugin.Misc.NopStationTeams.Factories;
public interface IEmployeeModelFactory
{
    Task<EmployeeListModel> PrepareEmployeeListModelAsync(EmployeeSearchModel searchModel);
    Task<EmployeeSearchModel> PrepareEmployeeSearchModelAsync(EmployeeSearchModel searchModel);
}
