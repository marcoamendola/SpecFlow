﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace TechTalk.SpecFlow.Specs.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("AsyncSupport")]
    public partial class AsyncSupportFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "AsyncSupport.feature"
#line hidden
        
        [NUnit.Framework.TestFixtureSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "AsyncSupport", "", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.TestFixtureTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line hidden
#line 4
 testRunner.Given("the following binding class", "using System.Threading.Tasks;\r\nusing Microsoft.VisualStudio.TestTools.UnitTesting" +
                    ";\r\n\r\n[Binding]\r\npublic class AsyncSteps\r\n{\r\n\tprivate readonly ScenarioContext sc" +
                    "enarioContext;\r\n\r\n\tpublic AsyncSteps(ScenarioContext scenarioContext)\r\n\t{\r\n     " +
                    "   \r\n\t\tthis.scenarioContext = scenarioContext;\r\n\t}\r\n\r\n\t[Given(@\"I am calling an " +
                    "async step method\")]\r\n\tpublic async Task GivenIAmCallingAnAsyncStep()\r\n\t{\r\n\t\tawa" +
                    "it Task.Delay(250);\r\n\r\n\t\tthis.scenarioContext[\"GivenStepCompleted\"] = DateTime.N" +
                    "ow.Ticks;\r\n\t}\r\n\r\n\t[Given(@\"I am testing a component with async methods\")]\r\n\tpubl" +
                    "ic void GivenIAmTestingAComponentWithAsyncMethods()\r\n\t{\r\n\t\tthis.scenarioContext[" +
                    "\"Component\"] = new AsyncComponent();\r\n\t}\r\n\r\n\t[When(@\"I call the next async step " +
                    "method\")]\r\n\tpublic async Task WhenICallTheNextAsyncStepMethod()\r\n\t{\r\n\t\tawait Tas" +
                    "k.Delay(100);\r\n\r\n\t\tthis.scenarioContext[\"WhenStepCompleted\"] = DateTime.Now.Tick" +
                    "s;\r\n\t}\r\n\r\n\t[When(@\"I call an async method that throws an exception\")]\r\n\tpublic a" +
                    "sync Task WhenICallAnAsyncMethodThatThrowsAnException()\r\n\t{\r\n\t\ttry\r\n\t\t{\r\n\t\t\tawai" +
                    "t ((AsyncComponent)this.scenarioContext[\"Component\"]).AsyncMethod();\r\n\t\t}\r\n\t\tcat" +
                    "ch (Exception ex)\r\n\t\t{\r\n\t\t\tthis.scenarioContext[\"Exception\"] = ex;\r\n\t\t}\r\n\t}\r\n\r\n\t" +
                    "[Then(@\"both step methods should have been called in order before I get to the l" +
                    "ast step method\")]\r\n\tpublic void ThenBothStepMethodsShouldHaveBeenCalledInOrderB" +
                    "eforeIGetToTheLastStepMethod()\r\n\t{\r\n\t\tAssert.IsTrue(this.scenarioContext.Contain" +
                    "sKey(\"GivenStepCompleted\"));\r\n\t\tAssert.IsTrue(this.scenarioContext.ContainsKey(\"" +
                    "WhenStepCompleted\"));\r\n\t\tAssert.IsTrue((long)this.scenarioContext[\"WhenStepCompl" +
                    "eted\"] > (long)this.scenarioContext[\"GivenStepCompleted\"]);\r\n\t}\r\n\r\n\t[Then(@\"the " +
                    "exception should be sent back to my step method\")]\r\n\tpublic void ThenTheExceptio" +
                    "nShouldBeSentBackToMyStepMethod()\r\n\t{\r\n\t\tAssert.IsTrue(this.scenarioContext.Cont" +
                    "ainsKey(\"Exception\"));\r\n\t\tAssert.AreEqual(\"This exception should bubble up.\", ((" +
                    "Exception)this.scenarioContext[\"Exception\"]).Message);\r\n\t}\r\n\r\n\tprivate class Asy" +
                    "ncComponent\r\n\t{\r\n\t\tpublic async Task AsyncMethod()\r\n\t\t{\r\n\t\t\tawait Task.Delay(100" +
                    ");\r\n\r\n\t\t\tthrow new Exception(\"This exception should bubble up.\");\r\n\t\t}\r\n\t}\r\n}", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Should wait for aync step methods to complete before continuing to next step")]
        public virtual void ShouldWaitForAyncStepMethodsToCompleteBeforeContinuingToNextStep()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Should wait for aync step methods to complete before continuing to next step", ((string[])(null)));
#line 82
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line hidden
#line 83
 testRunner.Given("a scenario \'Wait for async step methods to complete before continuing to next ste" +
                    "p\' as", "Given I am calling an async step method\r\nWhen I call the next async step method\r\n" +
                    "Then both step methods should have been called in order before I get to the last" +
                    " step method\r\n", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 90
 testRunner.When("I execute the tests", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Succeeded"});
            table1.AddRow(new string[] {
                        "1"});
#line 91
 testRunner.Then("the execution summary should contain", ((string)(null)), table1, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Step method should recieve exception from async method call")]
        public virtual void StepMethodShouldRecieveExceptionFromAsyncMethodCall()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Step method should recieve exception from async method call", ((string[])(null)));
#line 95
this.ScenarioSetup(scenarioInfo);
#line 3
this.FeatureBackground();
#line hidden
#line 96
 testRunner.Given("a scenario \'Step method should recieve exception from async method call\' as", "Given I am testing a component with async methods\nWhen I call an async method tha" +
                    "t throws an exception\nThen the exception should be sent back to my step method\r\n" +
                    "", ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 103
 testRunner.When("I execute the tests", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Succeeded"});
            table2.AddRow(new string[] {
                        "1"});
#line 104
 testRunner.Then("the execution summary should contain", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
