using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace TestSiteAutomation.Pages;

public class DragAndDropPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;
    private IWebElement _elementA => _driver.FindElement(By.Id("column-a"));
    private IWebElement _elementB => _driver.FindElement(By.Id("column-b"));

    public DragAndDropPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // Defaulting to 10 seconds
    }

    public string GetElementAText()
    {
        return _elementA.Text;
    }
    
    public string GetElementBText()
    {
        return _elementB.Text;
    }

    public void DragAndDrop()
    {
        Actions action = new Actions(_driver);
        action.DragAndDrop(_elementA, _elementB).Perform();
    }
    
    public string GetPageTitle()
    {
        return _driver.Title;
    }
}