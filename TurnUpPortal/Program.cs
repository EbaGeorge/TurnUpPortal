using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpPortal.Pages;

public class Program
{
    private static void Main(string[] args)
    {
        //Open Chrome Browser
        IWebDriver driver = new ChromeDriver();
        
        //Login Page initialization and definition
        LoginPage loginPage= new LoginPage();
        loginPage.LoginActions(driver);

        //Home page initialization and definition
        HomePage homePage = new HomePage();
        homePage.UserVerification(driver);

        homePage.NavigationToTimeAndMaterialPage(driver);

        //Time and Material Page initialization and definiton
        TimeAndMaterialPage timeMaterial=new TimeAndMaterialPage();
        timeMaterial.CreateNewTimeRecord(driver);
        timeMaterial.EditTimeRecord(driver);
        timeMaterial.DeleteTimeRecord(driver);

    }
}