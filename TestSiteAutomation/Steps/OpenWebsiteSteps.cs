using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using TestSiteAutomation.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestSiteAutomation.Steps
{
    [Binding]
    public class OpenWebsiteSteps
    {
        private IWebDriver _driver;
        private HomePage _homePage;

        [Given(@"I have opened the browser")]
        public void GivenIHaveOpenedTheBrowser()
        {
            // Optionally use WebDriverManager to manage driver binaries
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _homePage = new HomePage(_driver);
        }

        [When(@"I navigate to the home page")]
        public void WhenINavigateToTheHomePage()
        {
            _homePage.NavigateTo();
        }

        [Then(@"the page title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string expectedTitle)
        {
            string actualTitle = _homePage.GetPageTitle();
            Assert.That(expectedTitle, Is.EqualTo(actualTitle), "Page title does not match.");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}