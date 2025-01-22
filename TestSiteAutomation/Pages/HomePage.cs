using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestSiteAutomation.Pages;

public class HomePage
{
    private readonly IWebDriver _driver;
    private readonly string _url = "https://practice.expandtesting.com/";
    
    // Web elements
    private IWebElement LoginButton => _driver.FindElement(By.XPath("//*[@id=\"examples\"]/div[1]/div[2]/div/div/h3/a"));
    private IWebElement DragDropButton => _driver.FindElement(By.XPath("//*[@id=\"examples\"]/div[3]/div[3]/div/div/h3/a"));
    // private IWebElement element => _driver.FindElement(By.XPath("/html/body/ins[2]/div[1]//ins/span/svg/g/line[2]"));

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

    public void Login()
    {
        LoginButton.Click();
    }

    public void ClickDragAndDrop()
    {
        WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        Thread.Sleep(5000);
        // IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        // js.ExecuteScript("arguments[0].scrollIntoView(false);", DragDropButton);
        
        Actions actions = new Actions(_driver);
        actions.MoveToElement(DragDropButton).Perform();
        IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        js.ExecuteScript("window.scrollBy(0, -100);");
        // try
        // {
        //     if (element.Displayed)
        //     {
        //         element.Click();
        //     }
        // }
        // catch (NoSuchElementException e)
        // {
        //     Console.WriteLine(e);
        // }
        
        wait.Until(ExpectedConditions.ElementToBeClickable(DragDropButton));
        DragDropButton.Click();
    }
}
