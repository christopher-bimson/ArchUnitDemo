using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace BasicTaskList.Api.ArchitectureTests;

public class ArchitectureShould
{
    private static readonly Architecture Architecture = new ArchLoader()
        .LoadAssembliesIncludingDependencies([System.Reflection.Assembly.Load("BasicTaskList.Api")])
        .Build();
    
    [Fact]
    public void Not_Permit_RestAPI_Layer_To_Bypass_The_ApplicationService_Layer()   
    {
        var noCoreAccess = Types()
            .That().Are(Layers.RestApi)
            .Should()
            .NotDependOnAnyTypesThat().Are(Layers.Core)
            .Because("the application host should not access the core layer directly.");
        
        var noInfrastructureServicesAccess = Types()
            .That().Are(Layers.RestApi)
            .Should()
            .NotDependOnAnyTypesThat().Are(Layers.InfrastructureServices)
            .Because("the application host should not access the infrastructure services layer directly.");
        
        noCoreAccess.And(noInfrastructureServicesAccess).Check(Architecture);
    }

    [Fact]
    public void Not_Permit_The_Model_To_Depend_Upon_The_RestAPI_Layer()
    {
        var notDependOnRestApi = Types()
            .That().Are(Layers.Model)
            .Should()
            .NotDependOnAny(Types().That().Are(Layers.RestApi))
            .Because("the model should be ignorant of the application host(s) that consume it.");

        var notDependOnAspNetCore = Types()
            .That().Are(Layers.Model)
            .Should()
            .NotDependOnAny(Types().That().Are(Namespaces.MicrosoftAspNetCore))
            .Because("the model should be framework agnostic.");
        
        notDependOnRestApi.And(notDependOnAspNetCore).Check(Architecture);
    }

    [Fact]
    public void Not_Permit_The_Core_Layer_To_Depend_On_Other_Model_Layers()
    {
        var noAppServices = Types()
            .That().Are(Layers.Core)
            .Should()
            .NotDependOnAny(Layers.ApplicationService)
            .Because("dependencies should flow toward the core.");
        
        var noInfrastructureServices = Types()
            .That().Are(Layers.Core)
            .Should()
            .NotDependOnAny(Layers.InfrastructureServices)
            .Because("dependencies should flow toward the core.");
        
        noAppServices.And(noInfrastructureServices).Check(Architecture);
    }

    [Fact]
    public void Not_Permit_The_ApplicationServices_Layer_To_Use_InfrastructureServices_Directly()
    {
        var rule = Types()
            .That().Are(Layers.ApplicationService)
            .Should()
            .NotDependOnAny(Layers.InfrastructureServices)
            .Because("application services should use abstractions from the core rather than reference infrastructure services directly.");
        
        rule.Check(Architecture);
    }
}   