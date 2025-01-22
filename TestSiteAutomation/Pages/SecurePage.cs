using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestSiteAutomation.Pages;

public class SecurePage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    public SecurePage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // Defaulting to 10 seconds
    }

    public string GetPageTitle()
    {
        return _driver.Title;
    }
}