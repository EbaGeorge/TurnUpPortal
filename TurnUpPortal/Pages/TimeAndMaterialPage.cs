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
        private readonly By typeCodeButtonLocator = By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span");
        private readonly By timeOptionLocator = By.XPath("//*[@id='TypeCode_listbox']/li[2]");
        private readonly By codeTextboxLocator = By.Id("Code");
        private readonly By descriptionTextboxLocator = By.Id("Description");
        private readonly By overlapTextboxLocator = By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]");
        private readonly By priceTextboxLocator = By.Id("Price");
        private readonly By fileInputLocator = By.Id("files");
        private readonly By saveButtonLocator = By.Id("SaveButton");
        private readonly By goToLastPageLocator = By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span");
        private readonly By codeLocator = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]");
        private readonly By editButtonLocator = By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]");
        private readonly By materialOptionLocator = By.XPath("//*[@id='TypeCode_listbox']/li[1]");
        private readonly By deleteButtonLocator = By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span");

        //Method To Create Time Record
        public void CreateNewTimeRecord(IWebDriver driver)
        {
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='container']/p/a",6);

                // Click on Create Button
                IWebElement createNewButton = driver.FindElement(createNewButtonLocator);
                createNewButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("Create New Button is not selectable" + ex.Message);
            }

            //Select Time from the TypeCode dropdown
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span", 6);
            IWebElement typeCodeButton = driver.FindElement(typeCodeButtonLocator);
            typeCodeButton.Click();
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TypeCode_listbox']/li[2]", 6);
            IWebElement timeOption = driver.FindElement(timeOptionLocator);
            timeOption.Click();

            //Enter Code into Code text box
            IWebElement codeTextbox = driver.FindElement(codeTextboxLocator);
            codeTextbox.SendKeys("TimeModule");

            //Enter Description into Description text box
            IWebElement descriptionTextbox = driver.FindElement(descriptionTextboxLocator);
            descriptionTextbox.SendKeys("New Time Module");

            //Enter Price per unit into Price text box
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 6);
           
            //Identify overlapping element        
            IWebElement overlapTextbox = driver.FindElement(overlapTextboxLocator);
            overlapTextbox.Click();

            //Identifying the price web element
            IWebElement priceTextbox = driver.FindElement(priceTextboxLocator);
            priceTextbox.SendKeys("100");
            
            //File Upload
            IWebElement fileInput = driver.FindElement(fileInputLocator);
            fileInput.SendKeys(@"D:\Eba\Industry Connect\DemoImage.jpg");
            
            //Explicit Wait
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(saveButtonLocator));

            //Click on Save button
            IWebElement saveButton = driver.FindElement(saveButtonLocator);
            saveButton.Click();
            //Thread.Sleep(1000);
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            //Click on Go to last Page button
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                IWebElement goToLastPage = driver.FindElement(goToLastPageLocator);
                goToLastPage.Click();
            }
            catch (Exception ex)
            { 
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

            try
            {
                //Check if a new Time module is created successfully
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 6);
                IWebElement newTimeModule = driver.FindElement(codeLocator);
            }
            catch (Exception ex)
            {
                Assert.Fail("New Time Record is not selectable" + ex.Message);
            }
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
                IWebElement editedLastPageButton = driver.FindElement(goToLastPageLocator);
                editedLastPageButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

           //Click on Edit Button
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 5);
            IWebElement editButton = driver.FindElement(editButtonLocator);
            editButton.Click();

            //Edit the TypeCode
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span", 7);
            IWebElement editedTypecode = driver.FindElement(typeCodeButtonLocator);
            editedTypecode.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id='TypeCode_listbox']/li[1]", 7);
            IWebElement editedOptions = driver.FindElement(materialOptionLocator);
            editedOptions.Click();

            //Edit the Code
            IWebElement editedCode = driver.FindElement(codeTextboxLocator);
            editedCode.Clear();
            editedCode.SendKeys("EditedTimeModule");

            //Edit Description
            IWebElement editedDescription = driver.FindElement(descriptionTextboxLocator);
            editedDescription.Clear();
            editedDescription.SendKeys("Time Module is edited");
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 5);
            
            //Edit Price
            try
            {
                IWebElement editedOverlapTextbox = driver.FindElement(overlapTextboxLocator);
                editedOverlapTextbox.Click();
                Wait.WaitToBeVisible(driver, "Id", "Price", 5);
                IWebElement editedpriceTextbox = driver.FindElement(priceTextboxLocator);
                editedpriceTextbox.Clear();
                editedOverlapTextbox.Click();
                editedpriceTextbox.SendKeys("200");
            }
            catch (ElementNotInteractableException ex)
            {
                Assert.Fail("Price textbox is not interactable" + ex.Message);
            }
           
            //File Upload
            IWebElement fileInput = driver.FindElement(fileInputLocator);
            fileInput.SendKeys(@"D:\Eba\Industry Connect\Demo2.jpg");

            Wait.WaitToBeVisible(driver, "Id", "SaveButton", 5);
            //Click on the Save button
            IWebElement editedSaveButton = driver.FindElement(saveButtonLocator);
            editedSaveButton.Click();
            Thread.Sleep(1000);
           // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            try
            {
                //Go To Last Page
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
               
                IWebElement editedlastpage = driver.FindElement(goToLastPageLocator);
              
                editedlastpage.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);
            try
            {
                //Check if time module is edited
                IWebElement editedTimeModuleCode = driver.FindElement(codeLocator);
            }
            catch (Exception ex)
            {
                Assert.Fail("Edited Time record is not visible" + ex.Message);
            }

        }

        //Method To Delete Time Record
        public void DeleteTimeRecord(IWebDriver driver)
        {
            Thread.Sleep(1000);
            //Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            //Delete newly created time module 
            try
            {
                //Go To Last Page Button
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                IWebElement deleteLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                deleteLastPageButton.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

           
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[2]", 5);
            //Click on the delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            
            //Handle pop up dialog box
            driver.SwitchTo().Alert().Accept();
          
            driver.Navigate().Refresh();
            Thread.Sleep(1000);
           // Wait.WaitToBeVisible(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]", 6);
            try
            {
                Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[4]/a[4]/span", 6);
                //Go To Last Page
                IWebElement deleteLastPageButtonAfter = driver.FindElement(deleteButtonLocator);
                
                deleteLastPageButtonAfter.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail("GoToLastPageButton is not selectable" + ex.Message);
            }
          
            Wait.WaitToBeVisible(driver, "XPath", "//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]", 5);
            try
            {
                //Check if the time module is deleted
                IWebElement lastTimeModule = driver.FindElement(codeLocator);
                
            }
            catch (Exception ex)
            {
                Assert.Fail("Not able to locate the last row" + ex.Message);
            }
        }

    }
}
