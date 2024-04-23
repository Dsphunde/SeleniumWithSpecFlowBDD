using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using TechTalk.SpecFlow;

//For before step and after step, before feature after feature only static method is required

namespace SpecFlowProjectUsingBDD.StepDefinitions
{
    [Binding]
    public sealed class SpecFlowHooks
    {
        private static ExtentReports extent;
        private static ExtentTest featureName;
        private static ExtentTest scenarioName;


        [BeforeTestRun]
        public static void BeforeTestRun() 
        {
            var extentSparkReporter = new ExtentSparkReporter("C:\\Users\\Deepak\\OneDrive\\Desktop\\Report\\index.html");
            extentSparkReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
            extent = new ExtentReports();
            extent.AttachReporter(extentSparkReporter);
        }
        [AfterTestRun]
        public static void AfterTestRun()
        {
            extent.Flush();
        }
        [BeforeFeature(Order = 10)]
        public static void BeforeFeature()
        {
            featureName = extent.CreateTest<Feature>(FeatureContext.Current.FeatureInfo.Title);
        }
        [AfterFeature(Order = 10)]
        public static void AfterFeature()
        {
            Console.WriteLine("In method after feature run");
        }
        [BeforeScenario(Order =20)]
        [Scope(Tag ="Smoke")]
        public  void BeforeScenario()
        {
            scenarioName = featureName.CreateNode<Scenario>(ScenarioContext.Current.ScenarioInfo.Title);
        }
        [AfterScenario(Order =20)]
        [AfterScenario("Regression")]
        public  void AfterScenario()
        {
            Console.WriteLine("In method after scenario run");
        }
        [BeforeScenarioBlock(Order = 30)]
        public void BeforeScenarioBlock()
        {
            Console.WriteLine("In method before scenario block run");
        }
        [AfterScenarioBlock(Order = 30)]
        public void AfterScenarioBlock()
        {
            Console.WriteLine("In method after scenario block run");
        }
        [BeforeStep(Order=40)]
        public  void BeforeStep()
        {
            Console.WriteLine("In method before Step run");
        }
        [AfterStep(Order =40)]
        public  void AfterStep()
        {
            var stepType=ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (ScenarioContext.Current.TestError == null)
            {
                if (stepType == "Given")
                {
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                } else if (stepType == "When")
                {
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                } else if (stepType == "And")
                {
                    scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
                } else if (stepType == "Then")
                {
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                }
            } else if (ScenarioContext.Current.TestError !=null) 
            {
                if (stepType == "Given")
                {
                    scenarioName.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                } else if (stepType == "When")
                {
                    scenarioName.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                } else if (stepType == "And")
                {
                    scenarioName.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                } else if (stepType=="Then") 
                {
                    scenarioName.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(ScenarioContext.Current.TestError.Message);
                }
            }
        }
    }
}