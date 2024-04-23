using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;

namespace SpecFlowProjectUsingBDD.StepDefinitions
{
    [Binding]
    public class FacebookHomePageStep
    {
        IWebDriver driver;
        [Given(@"user navigate to the facebook home page")]
        public void GivenUserNavigateToTheFacebookHomePage()
        {
           /* var htmlReporter = new ExtentSparkReporter("C:\\Users\\Deepak\\OneDrive\\Desktop\\Report\\index.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Dark;
            ExtentReports extentReports = new ExtentReports();
            extentReports.AttachReporter(htmlReporter);
            ExtentTest featureName = extentReports.CreateTest<Feature>("FacebookHome Page Login");
            ExtentTest testScenario = featureName.CreateNode<Scenario>("To chcek the login functionality for the facebook with invalid credentials");
            testScenario.CreateNode<Given>("user navigate to the facebook home page");
            extentReports.Flush();*/
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl("https://www.facebook.com/login/");
        }

        [When(@"user enters the username as (.*) and password as (.*)")]
        public void WhenUserEntersTheUsernameAsAndPasswordAs(string username,string password)
        {
            driver.FindElement(By.Id("email")).SendKeys(username);
            driver.FindElement(By.Id("pass")).SendKeys(password);
        }

        [When(@"user click on the login button")]
        public void WhenUserClickOnTheLoginButton()
        {
            driver.FindElement(By.Name("login")).Click();
        }

        [Then(@"login should be unsuccessful")]
        public void ThenLoginShouldBeUnsuccessful()
        {
            Console.WriteLine(driver.Title);
            String ExpectedTitle = "Log in to Facebook1";
            String ActualTile = driver.Title;
            Assert.AreEqual(ExpectedTitle, ActualTile);
            driver.Close();
        }

    }
}
