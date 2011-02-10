// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.5.0.0
//      Runtime Version:4.0.30319.208
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
namespace Specs.ScenarioOutline
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.5.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Scenario outline")]
    public partial class ScenarioOutlineFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "ScenarioOutline.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Scenario outline", "In order to not have to type the same scenario over and over\nAs a SpecFlow evange" +
                    "list\nI want to show how to use ScenarioOutline", GenerationTargetLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Add two positive numbers with many examples")]
        [NUnit.Framework.TestCaseAttribute("10", "20", "30")]
        [NUnit.Framework.TestCaseAttribute("20", "20", "40")]
        [NUnit.Framework.TestCaseAttribute("20", "30", "50")]
        [NUnit.Framework.TestCaseAttribute("100", "20", "120")]
        [NUnit.Framework.TestCaseAttribute("1000", "20", "1020")]
        public virtual void AddTwoPositiveNumbersWithManyExamples(string number1, string number2, string result)
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Add two positive numbers with many examples", ((string[])(null)));
#line 8
this.ScenarioSetup(scenarioInfo);
#line 9
 testRunner.Given(string.Format("I have entered {0} into the calculator", number1));
#line 10
 testRunner.And(string.Format("I have entered {0} into the calculator", number2));
#line 11
 testRunner.When("I press add");
#line 12
 testRunner.Then(string.Format("the result should be {0} on the screen", result));
#line hidden
            testRunner.CollectScenarioErrors();
        }
    }
}
#endregion