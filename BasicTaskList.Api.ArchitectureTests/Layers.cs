using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;

namespace BasicTaskList.Api.ArchitectureTests;

public static class Layers
{
    public static readonly IObjectProvider<IType> RestApi = ArchRuleDefinition.Types()
        .That()
        .ResideInNamespace("BasicTaskList.Api.Controllers")
        .Or()
        .ResideInNamespace("BasicTaskList.Api.Resources")
        .As("REST API layer");

    public static readonly IObjectProvider<IType> ApplicationService = ArchRuleDefinition.Types()
        .That()
        .ResideInNamespace("BasicTaskList.Api.Model.ApplicationServices")
        .As("application service layer");

    public static readonly IObjectProvider<IType> Core = ArchRuleDefinition.Types()
        .That()
        .ResideInNamespace("BasicTaskList.Api.Model.Core")
        .As("core layer");

    public static readonly IObjectProvider<IType> InfrastructureServices = ArchRuleDefinition.Types()
        .That()
        .ResideInNamespace("BasicTaskList.Api.Model.InfrastructureServices")
        .As("infrastructure services layer");

    public static readonly IObjectProvider<IType> Model = ArchRuleDefinition.Types()
        .That()
        .ResideInNamespace("BasicTaskList.Api.Model.*", true)
        .As("all model layers");
}