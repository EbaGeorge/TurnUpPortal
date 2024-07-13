using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortal.Pages
{
    public class TimeAndMaterialPage
    {
       
        public void CreateNewTimeRecord(IWebDriver driver)
        {
            try
            {
                // Click on Create Button
                IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
                createNewButton.Click();
            }
            catch(ElementNotSelectableException ex)
            {
                Assert.Fail("Create New Button is not selectable"+ex.Message);
            }
           
            //Select Time from the TypeCode dropdown
            IWebElement typeCodeButton = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span"));
            typeCodeButton.Click();
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            timeOption.Click();

            //Enter Code into Code text box
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("TimeModule");

            //Enter Description intp Description text box
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("New Time Module");

            //Enter Price per unit into Price text box
            //Identify overlapping element
            try
            {
                IWebElement overlapTextbox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
                overlapTextbox.Click();

                //Identifying the price web element
                IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
                priceTextbox.SendKeys("100");
            }
            catch (ElementNotInteractableException ex)
            {
                Assert.Fail("Price textbox is not interactable" + ex.Message);
            }
            
            //File Upload
            IWebElement fileInput = driver.FindElement(By.Id("files"));
            fileInput.SendKeys(@"D:\Eba\Industry Connect\DemoImage.jpg");
            Thread.Sleep(5000);
            
            //Click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            driver.Navigate().Refresh();
            //Click on Go to last Page button
            Thread.Sleep(5000);
            try 
            {
                IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                goToLastPage.Click();
            }
            catch(ElementNotSelectableException ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

            //Exception handling for unable to locate exception
            Thread.Sleep(2000);
            try
            {
                //Check if a new Time module is created successfully
                IWebElement newTimeModule = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.That(newTimeModule.Text == "TimeModule", "New Time module is created. Test is passed");

            }
            catch(ElementNotSelectableException ex)
            {
                Assert.Fail("New Time Record is not selectable"+ex.Message);
            }
        }
        public void EditTimeRecord(IWebDriver driver)
        {
            Thread.Sleep(5000);
            try
            {
                //Go To Last Page Button
                IWebElement editedLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                editedLastPageButton.Click();
            }
            catch (ElementNotSelectableException ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

            //Click on Edit Button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //Edit the TypeCode
            IWebElement editedTypecode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            editedTypecode.Click();
            Thread.Sleep(2000);
            IWebElement editedOptions = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[1]"));
            editedOptions.Click();

            //Edit the Code
            IWebElement editedCode = driver.FindElement(By.Id("Code"));
            editedCode.Clear();
            editedCode.SendKeys("EditedTimeModule");

            //Edit Description
            IWebElement editedDescription = driver.FindElement(By.Id("Description"));
            editedDescription.Clear();
            editedDescription.SendKeys("Time Module is edited");

            //Edit Price
            try
            {
                IWebElement editedOverlapTextbox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
                editedOverlapTextbox.Click();
                IWebElement editedpriceTextbox = driver.FindElement(By.Id("Price"));
                editedpriceTextbox.Clear();
                editedOverlapTextbox.Click();
                editedpriceTextbox.SendKeys("200");
            }
            catch (ElementNotInteractableException ex)
            {
                Assert.Fail("Price textbox is not interactable" + ex.Message);
            }
            //File Upload
            IWebElement fileInput = driver.FindElement(By.Id("files"));
            fileInput.SendKeys(@"D:\Eba\Industry Connect\Demo2.jpg");
            Thread.Sleep(5000);

            //Click on the Save button
            IWebElement editedSaveButton = driver.FindElement(By.Id("SaveButton"));
            editedSaveButton.Click();
            Thread.Sleep(5000);
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
            try
            {
                //Go To Last Page
                IWebElement editedlastpage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                editedlastpage.Click();

            }
            catch (ElementNotSelectableException ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable" + ex.Message);
            }

            Thread.Sleep(2000);
            try
            {
                //Check if time module is edited
                IWebElement editedTimeModuleCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.That(editedTimeModuleCode.Text == "EditedTimeModule", "New time module is not edited. Test is failed");
            }
            catch (ElementNotSelectableException ex)
            {
                Assert.Fail("Edited Time record is not visible" + ex.Message);
            }

        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Delete newly created time module 
            Thread.Sleep(5000);
            try
            {
                //Go To Last Page Button
                IWebElement deleteLastPageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                deleteLastPageButton.Click();
            }catch(ElementNotSelectableException ex)
            {
                Assert.Fail("GoToLastPage Button is not selectable"+ex.Message);
            }
            
            Thread.Sleep(3000);

            //Click on the delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(3000);

            //Handle pop up dialog box
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(3000);
            driver.Navigate().Refresh();
            Thread.Sleep(2000);
            try
            {
                //Go To Last Page
                IWebElement deleteLastPageButtonAfter = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
                deleteLastPageButtonAfter.Click();
            }
            catch (ElementNotSelectableException ex)
            {
                Assert.Fail("GoToLastPageButton is not selectable" + ex.Message);
            }
            Thread.Sleep(3000);
            try
            {
                //Check if the time module is deleted
                IWebElement lastTimeModule = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
                Assert.That(lastTimeModule.Text != "EditedTimeModule", "New time module is not deleted. Test is failed");
            }
            catch(ElementNotSelectableException ex)
            {
                Assert.Fail("Not able to locate the last row" + ex.Message);
            }
        }
         
    }
}