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
    public class Employees_Test:CommonDriver
    {
        [SetUp]
        public void SetUpActions()
        {
            driver = new ChromeDriver();

            //Login Page Initialization and definiton
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginActions(driver);

            //HomePage initialization and definition
            HomePage homePageObj = new HomePage();
            homePageObj.UserVerification(driver);
            homePageObj.NavigationToEmployeesPage(driver);

        }
        [Test,Order(1)]
        public void CreateEmployee()
        {
            //EmployeePage object initialization and definition
            EmployeesPage employeesPageObj = new EmployeesPage();
            employeesPageObj.CreateNewEmployee(driver);
        }
        [Test,Order(2)]
        public void EditEmployeeDetails()
        {
            EmployeesPage employeesPage = new EmployeesPage();
            employeesPage.EditNewEmployee(driver);
        }
        [Test,Order(3)]
        public void DeleteEmployee()
        {
            EmployeesPage employeesPage=new EmployeesPage();
            employeesPage.DeleteEmployee(driver);
        }
        [TearDown]
        public void TearDownActions()
        {
            driver.Quit();
        }
    }
}
