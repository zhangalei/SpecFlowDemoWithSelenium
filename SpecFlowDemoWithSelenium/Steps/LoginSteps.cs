using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using TechTalk.SpecFlow;

namespace SpecFlowDemo.Steps
{
    [Binding]
    public class LogIn_Steps
    {
        public IWebDriver driver;
        public string baseURL;

        [Given(@"User is at the Home Page")]
        public void GivenUserIsAtTheHomePage()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            baseURL = "http://opensource.demo.orangehrmlive.com";
            driver.Navigate().GoToUrl(baseURL + "/");
        }

        [Given(@"Navigate to LogIn Page")]
        public void GivenNavigateToLogInPage()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"User enter '(.*)' and '(.*)'")]
        public void WhenUserEnterAnd(string username, string password)
        {
            driver.FindElement(By.Id("txtUsername")).Clear();
            driver.FindElement(By.Id("txtUsername")).SendKeys(username);
            driver.FindElement(By.Id("txtPassword")).Clear();
            driver.FindElement(By.Id("txtPassword")).SendKeys(password);
        }

        [When(@"Click on the LogIn button")]
        public void WhenClickOnTheLogInButton()
        {
            driver.FindElement(By.Id("btnLogin")).Click();
        }

        [Given(@"User is logged in")]
        public void GivenUserIsLoggedIn()
        {
            driver = new ChromeDriver();
            //driver = new FirefoxDriver();
            baseURL = "http://opensource.demo.orangehrmlive.com";
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.Id("txtUsername")).Clear();
            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");
            driver.FindElement(By.Id("txtPassword")).Clear();
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin");
            driver.FindElement(By.Id("btnLogin")).Click();
        }


        [When(@"User LogOut from the Application")]
        public void WhenUserLogOutFromTheApplication()
        {
            driver.FindElement(By.Id("welcome")).Click();
            //for (int second = 0; ; second++)
            //{
            //    if (second >= 60) Assert.True(false, "timeout");
            //    try
            //    {
            //        if (IsElementPresent(By.LinkText("Logout"))) break;
            //    }
            //    catch (Exception)
            //    { }
            Thread.Sleep(1000);
            //}
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        [Then(@"Successful LogIN message should display")]
        public void ThenSuccessfulLogINMessageShouldDisplay()
        {
            //This Checks that if the LogOut button is displayed
            true.Equals(driver.FindElement(By.XPath(".//*[@id='welcome']")).Displayed);
            driver.Quit();
        }

        [Then(@"Successful LogOut message should display")]
        public void ThenSuccessfulLogOutMessageShouldDisplay()
        {
            true.Equals(driver.FindElement(By.XPath("//*[@id='logInPanelHeading']")).Displayed);
            driver.Quit();
        }
    }
}
