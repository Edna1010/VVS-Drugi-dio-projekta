using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

[TestFixture]
public class SigurnostplaanjTest
{
	private IWebDriver driver;
	private IJavaScriptExecutor js;
	public IDictionary<string, object> vars { get; private set; }

	[SetUp]
	public void SetUp()
	{
		driver = new ChromeDriver();
		js = (IJavaScriptExecutor)driver;
		vars = new Dictionary<string, object>();
	}

	[TearDown]
	protected void TearDown()
	{
		driver.Quit();
	}

	[Test]
	public void sigurnostplacanja()
	{
		driver.Navigate().GoToUrl("https://buybook.ba/");
		driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
		driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
		IWebElement sigurnostLink = driver.FindElement(By.LinkText("Sigurnost Plaćanja Karticama"));
		((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", sigurnostLink);
		System.Threading.Thread.Sleep(1000);
		sigurnostLink.Click();
		NUnit.Framework.Assert.That(driver.Url, Is.EqualTo("https://buybook.ba/sigurnost-placanja-karticama"));
	}
}
