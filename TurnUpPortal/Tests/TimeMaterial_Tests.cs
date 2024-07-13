using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal.Pages;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Tests
{
    [TestFixture]
    public class TimeMaterial_Tests:CommonDriver
    {
        [SetUp]
        public void SetUpSteps()
        {
            driver=new ChromeDriver();
            //Login Page Object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //Home Page Object initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.UserVerification(driver);
            homePageObj.NavigationToTimeAndMaterialPage(driver);
        }
        [Test,Order(1)]
        public void CreateTimeModule()
        {
            //Time and Material Page Object initialization and definiton
            TimeAndMaterialPage timeMaterialObj = new TimeAndMaterialPage();
            //Create Time Record
            timeMaterialObj.CreateNewTimeRecord(driver);
        }
        [Test,Order(2)]
        public void EditTimeModule()
        {
            //Edit Time Record
            TimeAndMaterialPage timeMaterialObj = new TimeAndMaterialPage();
            timeMaterialObj.EditTimeRecord(driver);
        }
        [Test,Order(3)]
        public void DeleteTimeModule()
        {
            //Delete Time Record
            TimeAndMaterialPage timeMaterialObj = new TimeAndMaterialPage();
            timeMaterialObj.DeleteTimeRecord(driver);

        }
        [TearDown]
        public  void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
