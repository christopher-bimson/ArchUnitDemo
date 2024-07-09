using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;

namespace BasicTaskList.Api.ArchitectureTests;

public static class Namespaces
{
    public static readonly IObjectProvider<IType> MicrosoftAspNetCore = ArchRuleDefinition.Types()
        .That()
        .ResideInNamespace("Microsoft\\.AspNetCore.*", true)
        .As("Microsoft.AspNetCore namespace");
}