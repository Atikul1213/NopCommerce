using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;
using Microsoft.AspNetCore.Http.HttpResults;
using Nop.Data.Extensions;
using Nop.Data.Migrations;
using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Plugin.Misc.NopStationTeams.Mapping.Builders;
using Nop.Plugin.Misc.NopStationTeams.Model;

namespace Nop.Plugin.Misc.NopStationTeams.Migrations;
[NopSchemaMigration("2024/06/25 08:40:55:1687541", "NopStationTeams base schema", MigrationProcessType.Installation)]
public class SchemaMigration : ForwardOnlyMigration
{
    public override void Up()
    {
        Create.TableFor<Employee>();
    }
}
