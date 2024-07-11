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
            // Click on Create Button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id='container']/p/a"));
            createNewButton.Click();

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
            IWebElement overlapTextbox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            overlapTextbox.Click();

            //Identifying the price web element
            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.SendKeys("100");

            //Click on Save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            //Click on Go to last Page button
            Thread.Sleep(5000);
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastPage.Click();

            //Exception handling for unable to locate exception
            Thread.Sleep(2000);

            //Check if a new Time module is created successfully
            IWebElement newTimeModule = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            if (newTimeModule.Text == "TimeModule")
            {
                Console.WriteLine("New Time module is created. Test is passed");
            }
            else
            {
                Console.WriteLine("New time module is not created. Test is failed");
            }

        }
        public void EditTimeRecord(IWebDriver driver)
        {
            Thread.Sleep(5000);
            //Click on Edit Button
            IWebElement editButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();

            //Edit the TypeCode
            IWebElement editedTypecode = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[1]"));
            editedTypecode.Click();
            Thread.Sleep(3000);
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

            IWebElement editedOverlapTextbox = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            editedOverlapTextbox.Click();
            IWebElement editedpriceTextbox = driver.FindElement(By.Id("Price"));
            editedpriceTextbox.Clear();
            editedOverlapTextbox.Click();
            editedpriceTextbox.SendKeys("200");

            //Click on the Save button
            IWebElement editedSaveButton = driver.FindElement(By.Id("SaveButton"));
            editedSaveButton.Click();
            Thread.Sleep(5000);
            //Click on Go To Last Page Button
            IWebElement goToLastPage1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPage1.Click();

            //Check if time module is edited either by code, description or price per unit
            IWebElement editedTimeModuleCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedTimeModuleDescription = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedTimeModulePrice = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[4]"));
            IWebElement editedTimeModuleType = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[2]"));
            if (editedTimeModuleCode.Text == "EditedTimeModule" | editedTimeModuleDescription.Text == "Time Module is edited" | editedTimeModulePrice.Text == "200" | editedTimeModuleType.Text == "M")
            {
                Console.WriteLine("New Time module is edited. Test is passed");
            }
            else
            {
                Console.WriteLine("New time module is not edited. Test is failed");
            }

        }
        public void DeleteTimeRecord(IWebDriver driver)
        {
            //Delete newly created time module 
            Thread.Sleep(5000);
            //Click on the delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();
            Thread.Sleep(3000);
            //Handle pop up dialog box
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(3000);
            //Check if the time module is deleted
            IWebElement lastTimeModule = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (lastTimeModule.Text != "EditedTimeModule")
            {
                Console.WriteLine("New Time module is deleted. Test is passed");
            }
            else
            {
                Console.WriteLine("New time module is not deleted. Test is failed");
            }
        }
    }
}
