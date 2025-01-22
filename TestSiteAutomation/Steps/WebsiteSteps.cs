using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using TestSiteAutomation.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestSiteAutomation.Steps
{
    [Binding]
    public class WebsiteSteps
    {
        private IWebDriver _driver;
        private HomePage _homePage;
        private LoginPage _loginPage;
        private SecurePage _securePage;
        private DragAndDropPage _dragAndDropPage;

        private string elementAText;
        private string elementBText;

        [Given(@"I have opened the browser")]
        public void GivenIHaveOpenedTheBrowser()
        {
            // Optionally use WebDriverManager to manage driver binaries
            new DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _homePage = new HomePage(_driver);
            _loginPage = new LoginPage(_driver);
            _securePage = new SecurePage(_driver);
            _dragAndDropPage = new DragAndDropPage(_driver);
        }

        [When(@"I navigate to the home page")]
        public void WhenINavigateToTheHomePage()
        {
            _homePage.NavigateTo();
        }

        [Then(@"the ""(.*)"" title should be ""(.*)""")]
        public void ThenThePageTitleShouldBe(string pageName, string expectedTitle)
        {
            string actualTitle = ""; 
            
            if (pageName == "HomePage")
            {
                actualTitle = _homePage.GetPageTitle();
            } else if (pageName == "LoginPage")
            {
                actualTitle = _loginPage.GetPageTitle();
            } else if (pageName == "SecurePage")
            {
                actualTitle = _securePage.GetPageTitle();
            } else if (pageName == "DragAndDropPage")
            {
                actualTitle = _dragAndDropPage.GetPageTitle();
            }
            else
            {
                throw new Exception($"The page name {pageName} does not exist");
            }
            
            Assert.That(expectedTitle, Is.EqualTo(actualTitle), "Page title does not match.");
            Assert
        }

        [When(@"I click on Login link")]
        public void ClickOnLoginLink()
        {
            _homePage.Login();
        }
        
        [When(@"I click on Drag and drop link")]
        public void ClickOnDragAndDropLink()
        {
            _homePage.ClickDragAndDrop();
        }
        
        [When(@"I enter username as ""(.*)""")]
        public void WhenIEnterUsernameAs(string userName)
        {
            _loginPage.EnterUsername(userName);
        }

        [When(@"I enter password as ""(.*)""")]
        public void WhenIEnterPasswordAs(string password)
        {
            _loginPage.EnterPassword(password);
        }
        
        [When(@"I drag and drop")]
        public void DragAndDrop(string password)
        {
            elementAText = _dragAndDropPage.GetElementAText();
            elementBText = _dragAndDropPage.GetElementBText();
            _dragAndDropPage.DragAndDrop();
        }

        [Then(@"texts of elements should change")]
        public void VerifyTestsAfterDragAndDrop()
        {
            string tempElementText = _dragAndDropPage.GetElementAText();
            Assert.That(elementBText, Is.EqualTo(tempElementText), "Text for element A does not change");
            tempElementText = _dragAndDropPage.GetElementBText();
            Assert.That(elementAText, Is.EqualTo(tempElementText), "Text for element A does not change");
        }

        [When(@"I click on Login Button")]
        public void ClickLogin()
        {
            _loginPage.ClickLogin();
        }
        
        [When(@"I click on Drag and Drop Button")]
        public void ClickDragDrop()
        {
            _homePage.ClickDragAndDrop();
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Quit();
        }
    }
}