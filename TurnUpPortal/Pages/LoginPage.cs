using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortal.Pages
{
    public class LoginPage
    {
        //Functions that allow user to login to TurnUp portal
        public void LoginActions(IWebDriver driver)
        {
            //Login Functionality in TurnUp portal
            //Launch TurnUp portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");

            //Fit the chrome according to the screen resolution
            driver.Manage().Window.Maximize();

            //Identify the Username textbox and enter the username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            //Identify the Password textbox and enter the password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            //Identify the Login button and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
            loginButton.Click();

            //Sometimes the web driver is slower than the code, so we use thread
            Thread.Sleep(2000);

        }
    }
}
