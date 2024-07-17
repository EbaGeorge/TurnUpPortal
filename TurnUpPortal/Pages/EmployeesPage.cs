using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Pages
{
    public class EmployeesPage
    {
        private readonly By createEmployeeButtonLocator= By.XPath("//*[@id='container']/p/a");
        private readonly By employeeNameLocator = By.Id("Name");
        private readonly By userNameLocator = By.Id("Username");
        private readonly By contactDisplayLocator = By.Id("ContactDisplay");
        private readonly By passwordLocator = By.Id("Password");
        private readonly By retypePasswordLocator = By.Id("RetypePassword");
        private readonly By isAdminLocator = By.Id("IsAdmin");
        private readonly By vehicleEmployeeLocator = By.XPath("//*[@id='UserEditForm']/div/div[7]/div/span[1]/span/input");
        private readonly By groupEmployeeLocator = By.XPath("//*[@id='UserEditForm']/div/div[8]/div/div/div[1]");
        private readonly By groupEmployeeOptionLocator=By.XPath("//*[@id='groupList_listbox']/li[2]");
        private readonly By saveButtonLocator = By.Id("SaveButton");
        private readonly By backToListLocator = By.XPath("//*[@id='container']/div/a");
        private readonly By goToLastPageLocator = By.XPath("//*[@id='usersGrid']/div[4]/a[4]/span");
        private readonly By employeeNameCheckLocator = By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]");
        private readonly By editButtonLocator = By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]");
        private readonly By deleteButtonLocator = By.XPath("//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[2]");
        public void CreateNewEmployee(IWebDriver driver)
        {
            try
            {
                
                //Click on Create Button
                IWebElement createEmployee = driver.FindElement(createEmployeeButtonLocator);
                createEmployee.Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail("Create Button is not able to locate" + ex.Message);
                
            }

            //Enter the Employee Name
            IWebElement employeeName = driver.FindElement(employeeNameLocator);
            employeeName.SendKeys("TestEmployee");

            //Enter the UserName
            IWebElement userNameEmployee = driver.FindElement(userNameLocator);
            userNameEmployee.SendKeys("TestUserName");

            //Enter the Contact Details
            IWebElement contactDetails = driver.FindElement(contactDisplayLocator);
            contactDetails.SendKeys("ABC");

            //Enter the Password
            IWebElement passwordEmployee=driver.FindElement(passwordLocator);
            passwordEmployee.SendKeys("Password@12");

            //ReType Password
            IWebElement retypePassword = driver.FindElement(retypePasswordLocator);
            retypePassword.SendKeys("Password@12");

            //Click IsAdmin
            IWebElement isAdminCheckbox = driver.FindElement(isAdminLocator);
            isAdminCheckbox.Click();

            //Enter the Vehicle
            IWebElement vehicleEmployee = driver.FindElement(vehicleEmployeeLocator);
            vehicleEmployee.SendKeys("QWE");

            //Select Group
            IWebElement groupEmployee = driver.FindElement(groupEmployeeLocator);
            groupEmployee.Click();
            
            //Select the second option
            IWebElement groupEmployeeOption = driver.FindElement(groupEmployeeOptionLocator);
            groupEmployeeOption.Click();
            Wait.WaitToBeClickable(driver, "Id","SaveButton",10);
            //Thread.Sleep(5000);
            //Enter the Save Button
            IWebElement saveButton = driver.FindElement(saveButtonLocator);
            saveButton.Click();
            
            //Click on Back To List
            IWebElement backToList = driver.FindElement(backToListLocator);
            backToList.Click();

            //Refresh page
            driver.Navigate().Refresh();
            //Thread.Sleep(4000);
            Wait.WaitToBeClickable(driver,"XPath","//*[@id='usersGrid']/div[4]/a[4]/span", 10);
            try
            {
                //GoToLast Page
                IWebElement goToLastPage = driver.FindElement(goToLastPageLocator);
                goToLastPage.Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail("GoToLastPage button is not selectable"+ex.Message);
            }
            Wait.WaitToBeVisible(driver,"XPath","//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]",10);
            //Thread.Sleep(2000);
            try
            {
                //Check if new Employee module is created
                IWebElement newEmployee = driver.FindElement(employeeNameCheckLocator);
                Assert.That(newEmployee.Text == "TestEmployee", "New Employee is not created");
            }
            catch(NoSuchElementException ex)
            {
                Assert.Fail("Newly Created Employee is not found" + ex.Message);
            }
        }

        //Edit newly created employee
        public void EditNewEmployee(IWebDriver driver)
        {
            //Thread.Sleep(3000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='usersGrid']/div[4]/a[4]/span", 10);
            //Click on Go To Lat Page Button
            IWebElement goToLastPageEdit = driver.FindElement(goToLastPageLocator);
            goToLastPageEdit.Click();
            //Thread.Sleep(2000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[3]/a[1]", 10);
            try
            {
                //Click on Edit Button
                IWebElement editButton = driver.FindElement(editButtonLocator);
                editButton.Click();
            }
            catch(Exception ex)
            {
                Assert.Fail("Edit button is unable to locate" + ex.Message);
            }

            //Edit the Name field
            IWebElement nameEmployeeEdit = driver.FindElement(employeeNameLocator);
            nameEmployeeEdit.Clear();
            nameEmployeeEdit.SendKeys("EditedTestEmployee");

            //Edit the Username Field
            IWebElement editedUsername = driver.FindElement(userNameLocator);
            editedUsername.Clear();
            editedUsername.SendKeys("EditedUsername");
            
            //Thread.Sleep(2000);
            //Edit the contact details
            //Click on Edit Button
            //IWebElement editContact = driver.FindElement(By.Id("EditContactButton"));
            //editContact.Click();
            //Thread.Sleep(5000);
            //try
            //{
            //    //Enter the First Name
            //IWebElement firstName = driver.FindElement(By.XPath("/html/body/div[1]/form/div/div[1]/table/tbody/tr[1]/td[1]/div/input"));
                //firstName.Click();
                //firstName.SendKeys("Tom");
            //}
            //catch (NoSuchElementException ex)
            //{
            //    Assert.Fail("Edit Contact Page is not loaded" + ex.Message);
            //}

            ////Enter the Last Name
            //IWebElement lastName = driver.FindElement(By.Id("LastName"));
            //lastName.SendKeys("Mot");

            ////Enter the Preferred Name
            //IWebElement preferedName = driver.FindElement(By.Id("PreferedName"));
            //preferedName.SendKeys("Tomy");

            ////Enter the Phone
            //IWebElement phone = driver.FindElement(By.Id("Phone"));
            //phone.SendKeys("123456");

            ////Enter the Mobile
            //IWebElement mobile = driver.FindElement(By.Id("Mobile"));
            //mobile.SendKeys("34567");

            ////Enter the Email
            //IWebElement email = driver.FindElement(By.Id("email"));
            //email.SendKeys("abc@gmail.com");

            ////Enter the Fax
            //IWebElement fax = driver.FindElement(By.Id("email"));
            //fax.SendKeys("abcfax");

            ////Enter the Address
            //IWebElement address = driver.FindElement(By.Id("autocomplete"));
            //address.SendKeys("ABC Street");

            ////Enter the Street
            //IWebElement street = driver.FindElement(By.Id("Street"));
            //street.SendKeys("Street1");

            ////Enter the City
            //IWebElement city = driver.FindElement(By.Id("City"));
            //city.SendKeys("City1");

            ////Enter the PostCode
            //IWebElement postcode = driver.FindElement(By.Id("Postcode"));
            //postcode.SendKeys("1232");

            ////Enter the country
            //IWebElement country = driver.FindElement(By.Id("Country"));
            //country.SendKeys("New Zealand");

            ////Click on SaveContact Button
            //IWebElement saveBtn = driver.FindElement(By.Id("submitButton"));
            //saveBtn.Click();

            //Enter the Password
            IWebElement passwordEmployee = driver.FindElement(passwordLocator);
            passwordEmployee.Clear();
            passwordEmployee.SendKeys("Password@13");

            //ReType Password
            IWebElement retypePassword = driver.FindElement(retypePasswordLocator);
            retypePassword.Clear();
            retypePassword.SendKeys("Password@13");

            //Enter the Vehicle
            IWebElement vehicleEmployee = driver.FindElement(vehicleEmployeeLocator);
            vehicleEmployee.Clear();
            vehicleEmployee.SendKeys("Vehicle");

            //Select Group
            IWebElement groupEmployee = driver.FindElement(groupEmployeeLocator);
            groupEmployee.Click();
            //Thread.Sleep(2000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='groupList_listbox']/li[12]", 10);
            //Select the another option
            IWebElement groupEmployeeOption = driver.FindElement(By.XPath("//*[@id='groupList_listbox']/li[12]"));
            groupEmployeeOption.Click();
            //Thread.Sleep(3000);
            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 10);
            //Enter the Save Button
            IWebElement saveButton = driver.FindElement(saveButtonLocator);
            saveButton.Click();
            //Thread.Sleep(3000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='container']/div/a", 10);
            //Click on Back To List
            IWebElement backToList = driver.FindElement(backToListLocator);
            backToList.Click();

            //Refresh page
            driver.Navigate().Refresh();
            //Thread.Sleep(4000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='usersGrid']/div[4]/a[4]/span", 10);
            try
            {
                //GoToLast Page
                IWebElement goToLastPage = driver.FindElement(goToLastPageLocator);
                goToLastPage.Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail("GoToLastPage button is not selectable" + ex.Message);
            }
            //Thread.Sleep(2000);
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='usersGrid']/div[3]/table/tbody/tr[last()]/td[1]", 10);
            try
            {
                //Check if new Employee module is created
                IWebElement newEmployee = driver.FindElement(employeeNameCheckLocator);
                Assert.That(newEmployee.Text == "EditedTestEmployee", "Employee details are edited");
            }
            catch (NoSuchElementException ex)
            {
                Assert.Fail("Edited Employee is not found" + ex.Message);
            }
        }
        public void DeleteEmployee(IWebDriver driver)
        {
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='usersGrid']/div[4]/a[4]/span", 30);
            //Thread.Sleep(3000);
            //GoToLastPage Button
            IWebElement goToLastPageDelete = driver.FindElement(goToLastPageLocator);
            goToLastPageDelete.Click();

            //Click on Delete Button
            IWebElement deleteButton = driver.FindElement(deleteButtonLocator);
            deleteButton.Click();

            //Handling the Pop Up
            driver.SwitchTo().Alert().Accept();

            //Refresh the page
            driver.Navigate().Refresh();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='usersGrid']/div[4]/a[4]/span", 30);
            //Thread.Sleep(2000);
            //Navigate to Last Page
            IWebElement goToLastPageAfterDelete = driver.FindElement(goToLastPageLocator);
            goToLastPageAfterDelete.Click();

            //Check if the employee detail is deleted
            IWebElement lastrow = driver.FindElement(employeeNameCheckLocator);
            Assert.That(lastrow.Text != "EditedTestEmployee", "Employee Detail is not deleted");
        }
    }
 }
