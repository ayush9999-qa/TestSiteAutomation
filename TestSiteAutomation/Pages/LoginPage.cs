using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestSiteAutomation.Pages;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private IWebElement UsernameField => _driver.FindElement(By.Id("username"));
    private IWebElement PasswordField => _driver.FindElement(By.Id("password"));
    private IWebElement LoginButton => _driver.FindElement(By.XPath("//*[@id=\"login\"]/button"));

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // Defaulting to 10 seconds
    }

    public string GetPageTitle()
    {
        return _driver.Title;
    }

    public void ClickLogin()
    {
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        _wait.Until(ExpectedConditions.ElementToBeClickable(LoginButton));
        js.ExecuteScript("arguments[0].scrollIntoView(false);", LoginButton);
        LoginButton.Click();
    }

    public void EnterUsername(string username)
    {
        UsernameField.SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        PasswordField.SendKeys(password);
    }
}