using OpenQA.Selenium;

namespace TestSiteAutomation.Pages;

public class HomePage
{
    private readonly IWebDriver _driver;
    private readonly string _url = "https://practice.expandtesting.com/";
    
    // Web elements
    public IWebElement LoginButton => _driver.FindElement(By.XPath("//*[@id=\"examples\"]/div[1]/div[2]/div/div/h3/a"));

    public HomePage(IWebDriver driver)
    {
        _driver = driver;
    }

    public void NavigateTo()
    {
        _driver.Navigate().GoToUrl(_url);
    }

    public string GetPageTitle()
    {
        return _driver.Title;
    }
}
