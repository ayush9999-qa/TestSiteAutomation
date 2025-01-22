using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;
using TestSiteAutomation.Pages;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace TestSiteAutomation.Hooks;

[Binding]
public sealed class TestHooks
{
    private static IWebDriver _driver;
    public static HomePage HomePage { get; private set; }
    

    [BeforeScenario]
    public void BeforeScenario()
    {
        // new DriverManager().SetUpDriver(new ChromeConfig());
        // _driver = new ChromeDriver();
        // HomePage = new HomePage(_driver);
        // _driver.Manage().Window.Maximize();
    }

    [AfterScenario]
    public void AfterScenario()
    {
        // _driver.Quit();
    }
}