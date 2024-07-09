using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class Program
{
    private static void Main(string[] args)
    {
        //Login Functionality in TurnUp portal

        //Open Chrome Browser
        IWebDriver driver = new ChromeDriver();

        //Launch TurnUp portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");

        //Fit the chrome according to the screen resolution
        driver.Manage().Window.Maximize();

        //Identify the Username textbox and enter the username
        IWebElement username = driver.FindElement(By.Id("UserName"));
        username.SendKeys("hari");

        //Identify the Password textbox and enter the password
        IWebElement password = driver.FindElement(By.Id("Password"));
        password.SendKeys("123123");

        //Identify the Login button and click on it
        IWebElement loginbtn = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]\r\n"));
        loginbtn.Click();

        //Check if the user has logged in successfully
        IWebElement hellohari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        //Check if the text of the web element is "Hello hari"
        if (hellohari.Text == "Hello hari!")
        {
            Console.WriteLine("User has logged in successfully. Test is passed");
        }
        else
        {
            Console.WriteLine("User has not logged in successfully. Test is failed");
        }
    }
}