using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator.Builders.Create.Table;
using Nop.Data.Mapping.Builders;
using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Plugin.Misc.NopStationTeams.Model;

namespace Nop.Plugin.Misc.NopStationTeams.Mapping.Builders;
public class NopStationTeamsRecordBuilder : NopEntityBuilder<Employee>
{
    public override void MapEntity(CreateTableExpressionBuilder table)
    {
        table.WithColumn(nameof(Employee.Id)).AsInt32().PrimaryKey().Identity()
        .WithColumn(nameof(Employee.Name)).AsString(400)
        .WithColumn(nameof(Employee.Designation)).AsString(400)
        .WithColumn(nameof(Employee.IsMVP)).AsBoolean()
        .WithColumn(nameof(Employee.IsCertified)).AsBoolean();

    }
}
