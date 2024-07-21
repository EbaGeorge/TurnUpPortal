using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Pages
{
    public class TimeAndMaterialPage : Wait
    {
        private readonly By createNewButtonLocator = By.XPath("//*[@id='container']/p/a");
        IWebElement createNewButton;
        private readonly By typeCodeButtonLocator = By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span");
        IWebElement typeCodeButton;
        private readonly By timeOptionLocator = By.XPath("//*[@id='TypeCode_listbox']/li[2]");
        IWebElement timeOption;
        private readonly By codeTextboxLocator = By.Id("Code");
        IWebElement codeTextbox;
        private readonly By descriptionTextboxLocator = By.Id("Description");
        IWebElement descriptionTextbox;
        private readonly By overlapTextboxLocator = By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]");
        IWebElement overlapTextbox;
        private readonly By priceTextboxLocator = By.Id("Price");
        IWebElement priceTextbox;
        private readonly By fileInputLocator = By.Id("files");
        IWebElement fileInput;
        private readonly By saveButtonLocator = By.Id("SaveButton");
        IWebElement saveButton;
        private readonly By goToLastPageLocator = By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span");
        IWebElement goToLastPage;
        private readonly By lastCodeLocator = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");
        IWebElement lastCode;
        private readonly By editButtonLocator = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]");
        IWebElement editButton;
        private readonly By materialOptionLocator = By.XPath("//*[@id='TypeCode_listbox']/li[1]");
        IWebElement materialOption;
        private readonly By deleteButtonLocator = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]");
        IWebElement deleteButton;

        //Method To Create Time Record
        public void CreateNewTimeRecord(IWebDriver driver)
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='container']/p/a",6);
                // Click on Create Button
                createNewButton = driver.FindElement(createNewButtonLocator);
                createNewButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Create New Button is not selectable" + ex.Message);
            }

            //Select Time from the TypeCode dropdown
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span", 6);
            typeCodeButton = driver.FindElement(typeCodeButtonLocator);
            typeCodeButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 6);
            timeOption = driver.FindElement(timeOptionLocator);
            timeOption.Click();

            //Enter Code into Code text box
            codeTextbox = driver.FindElement(codeTextboxLocator);
            codeTextbox.SendKeys("TimeModule");

            //Enter Description into Description text box
            descriptionTextbox = driver.FindElement(descriptionTextboxLocator);
            descriptionTextbox.SendKeys("New Time Module");

            //Enter Price per unit into Price text box
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 6);
           
            //Identify overlapping element        
            overlapTextbox = driver.FindElement(overlapTextboxLocator);
            overlapTextbox.Click();

            //Identifying the price web element
            priceTextbox = driver.FindElement(priceTextboxLocator);
            priceTextbox.SendKeys("100");
            
            //File Upload
            fileInput = driver.FindElement(fileInputLocator);
            fileInput.SendKeys(@"D:\Eba\Industry Connect\DemoImage.jpg");
            
            //Explicit Wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(saveButtonLocator));

            //Click on Save button
            saveButton = driver.FindElement(saveButtonLocator);
            saveButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            Thread.Sleep(1000);
            //Click on Go to last Page button
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                goToLastPage = driver.FindElement(goToLastPageLocator);
                goToLastPage.Click();
            }
            catch (Exception ex)
            { 
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }
            Assert.That(GetCode(driver) == "TimeModule", "Actual Code and Expected code does not match");
            }

        public string GetCode(IWebDriver driver)
        {
            IWebElement newTimeModule = driver.FindElement(lastCodeLocator);
            return newTimeModule.Text;
        }

        //Method To Edit Time Record
        public void EditTimeRecord(IWebDriver driver)
        {
            Thread.Sleep(1000);
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            try
            {
                //Go To Last Page Button
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                goToLastPage = driver.FindElement(goToLastPageLocator);
                goToLastPage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

           //Click on Edit Button
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 5);
            editButton = driver.FindElement(editButtonLocator);
            editButton.Click();

            //Edit the TypeCode
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span", 7);
            typeCodeButton = driver.FindElement(typeCodeButtonLocator);
            typeCodeButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TypeCode_listbox']/li[1]", 7);
            materialOption = driver.FindElement(materialOptionLocator);
            materialOption.Click();

            //Edit the Code
            codeTextbox = driver.FindElement(codeTextboxLocator);
            codeTextbox.Clear();
            codeTextbox.SendKeys("EditedTimeModule");

            //Edit Description
            descriptionTextbox = driver.FindElement(descriptionTextboxLocator);
            descriptionTextbox.Clear();
            descriptionTextbox.SendKeys("Time Module is edited");
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 5);
            
            //Edit Price
            try
            {
                overlapTextbox = driver.FindElement(overlapTextboxLocator);
                overlapTextbox.Click();
                Wait.WaitToBeVisible(driver, "Id", "Price", 5);
                priceTextbox = driver.FindElement(priceTextboxLocator);
                priceTextbox.Clear();
                overlapTextbox.Click();
                priceTextbox.SendKeys("200");
            }
            catch (ElementNotInteractableException ex)
            {
                Assert.Fail("Price textbox is not interactable" + ex.Message);
            }
           
            //File Upload
            fileInput = driver.FindElement(fileInputLocator);
            fileInput.SendKeys(@"D:\Eba\Industry Connect\Demo2.jpg");

            Wait.WaitToBeVisible(driver, "Id", "SaveButton", 5);
            //Click on the Save button
            saveButton = driver.FindElement(saveButtonLocator);
            saveButton.Click();
            Thread.Sleep(1000);
           // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            try
            {
                //Go To Last Page
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
               
                goToLastPage = driver.FindElement(goToLastPageLocator);
              
                goToLastPage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

            Assert.That(GetCode(driver) == "EditedTimeModule", "Actual Code and Expected Code does not match");
           
        }

        //Method To Delete Time Record
        public void DeleteTimeRecord(IWebDriver driver)
        {
            Thread.Sleep(1000);
            //Delete newly created time module 
            try
            {
                //Go To Last Page Button
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                goToLastPage = driver.FindElement(goToLastPageLocator);
                goToLastPage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

            //Click on the delete button
            deleteButton = driver.FindElement(deleteButtonLocator);
            deleteButton.Click();

            //Handle pop up dialog box
            driver.SwitchTo().Alert().Accept();
            driver.Navigate().Refresh();

            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                goToLastPage = driver.FindElement(goToLastPageLocator);
                goToLastPage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPageButton is not selectable" + ex.Message);
            }

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);

            //Check if the time module is deleted
            Assert.That(GetCode(driver) != "EditedTimeModule", "Time record is not deleted");

        }
    }
}
