using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Plugin.Misc.NopStationTeams.Model;

namespace Nop.Plugin.Misc.NopStationTeams.Factories;
public interface IEmployeeHomeModelFactory
{
    Task<IList<EmployeeHomeModel>> PrepareEmployeeHomeListModelAsync(IList<Employee> employee);
    Task<EmployeeHomeModel> PrepareEmployeeHomeModelAsync(Employee employee);
}
