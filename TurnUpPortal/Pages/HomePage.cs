using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortal.Pages
{
    public class HomePage
    {
        public void NavigationToTimeAndMaterialPage(IWebDriver driver)
        {
            // Navigate to Time and Material Page
            IWebElement administartionTab = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            administartionTab.Click();
            IWebElement timeAndMaterialModule = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeAndMaterialModule.Click();
        }
        public void UserVerification(IWebDriver driver)
        {
            //Check if the user has logged in successfully
            IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

            //Check if the text of the web element is "Hello hari"
            if (helloHari.Text == "Hello hari!")
            {
                Console.WriteLine("User has logged in successfully. Test is passed");
            }
            else
            {
                Console.WriteLine("User has not logged in successfully. Test is failed");
            }

        }
    }
}
