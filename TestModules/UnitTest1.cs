using AutoDemoRefactor.BaseHooks;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace AutoDemoRefactor.TestModules
{
    public class Tests
    {
        string email(int rand) => $"AwesomeGod{rand}@hotmail.com";
        Random randomGenerator = new Random();
        int randomInt;
        WebDriverWait? wait;

        [Test]
        public void SignUp()
        {
            BasePage basePage = new BasePage();
            basePage.Start();
            wait = new WebDriverWait(basePage.browser, TimeSpan.FromSeconds(20));

            Actions action = new Actions(basePage.browser);
            var signUp = basePage.browser.FindElement(By.XPath("//*[@class='fa fa-lock']"));
            action.Click(signUp).Build().Perform();

            var inputElements = basePage.browser.FindElements(By.XPath("//input"));
            action.Click(inputElements[4]).SendKeys("Jennifer").Perform();

            randomInt = randomGenerator.Next(1, 1000);
            //action.Click(inputElements[5]).SendKeys(email(randomInt)).Perform();
            basePage.browser.FindElement(By.CssSelector("input[data-qa='signup-email']")).SendKeys(email(randomInt));

            var submitBttn = basePage.browser.FindElement(By.XPath("//*[@data-qa='signup-button']"));
            submitBttn?.Click();

            var title = basePage.browser.FindElement(By.CssSelector("*[id='id_gender1']"));
            action.Click(title).Perform();

            var pasword = basePage.browser.FindElement(By.XPath("//*[@id='password']"));
            pasword?.SendKeys("Justice1212");

            var dayofBirth = basePage.browser.FindElement(By.XPath("//*[@data-qa='days']"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-qa='days']")));
            SelectElement element1 = new SelectElement(dayofBirth);
            element1.SelectByValue("9");

            var monthofBirth = basePage.browser.FindElement(By.XPath("//*[@data-qa='months']"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-qa='months']")));

            SelectElement element2 = new SelectElement(monthofBirth);
            element2.SelectByText("October");

            var yearofBirth = basePage.browser.FindElement(By.XPath("//*[@data-qa='years']"));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@data-qa='years']")));
            SelectElement element3 = new SelectElement(yearofBirth);
            element3.SelectByValue("2021");

            var fName = basePage.browser.FindElement(By.XPath("//*[@data-qa='first_name']"));
            fName?.SendKeys("Jennifer");

            var lName = basePage.browser.FindElement(By.XPath("//*[@data-qa='last_name']"));
            lName?.SendKeys("David");

            var address = basePage.browser.FindElement(By.CssSelector("*[id='address1']"));
            address?.SendKeys("13314 Sharpbill Dr.");

            var country = basePage.browser.FindElement(By.Name("country"));
            SelectElement element4 = new SelectElement(country);
            element4.SelectByValue("United States");

            var inputFields = basePage.browser.FindElements(By.XPath("//input"));
            action.Click(inputFields![14]).SendKeys("Texas").Build().Perform();
            action.Click(inputFields[15]).SendKeys("Houston").Build().Perform();
            action.Click(inputFields[16]).SendKeys("TX 77083").Build().Perform();
            action.Click(inputFields[17]).SendKeys("+1800-799-0622").Build().Perform();

            var createAcct = basePage.browser.FindElement(By.XPath("//*[@data-qa='create-account']"));
            createAcct?.Click();

            //Assert.That(basePage.browser.Url.Contains(
            //"https://www.automationexercise.com/account_created"));
            Assert.IsTrue(basePage.browser.PageSource.Contains("Account Created"));
            //Assert.That(basePage.browser.Title, Is.EqualTo("Automation Exercise"));

            basePage.End();
        }

        [Test]
        public void Login()
        {
            BasePage basePage = new BasePage();
            basePage.Start();

            Actions action = new Actions(basePage.browser);
            var login = basePage.browser.FindElement(By.XPath("//*[@class='fa fa-lock']"));
            action.Click(login).Perform();

            var inputElements = basePage.browser.FindElements(By.XPath("//input"));
            action.Click(inputElements![1]).SendKeys("AwesomeGod900@hotmail.com").Perform();
            action.Click(inputElements[2]).SendKeys("Justice1212").Perform();

            var loginBttn = basePage.browser.FindElement(By.CssSelector("*[data-qa='login-button']"));
            action.Click(loginBttn).Perform();

            Thread.Sleep(5000);

            //Assertion
            Assert.That(basePage.browser.Title, Is.EqualTo("Automation Exercise"));
            bool _result = basePage.browser.Title != "Automation Exercise"
                ? true
                : false;

            if (basePage.browser.Title == "Automation Exercise")
            {
                Console.WriteLine("Test has passed");
            }
            else
            {
                Assert.Fail();
            }

            //inverted statement
            //if (basePage.browser.Title != "Automation Exercise")
            //{
            //    Assert.Fail();
            //}
            //else
            //{
            //    Console.WriteLine("Test has passed");
            //}

            Thread.Sleep(2000);

            basePage.End();
        }

        [Test]
        public void EndToEnd()
        {
            BasePage basePage = new BasePage();
            basePage.Start();

            Actions action = new Actions(basePage.browser);
            var signUp = basePage.browser.FindElement(By.XPath("//*[@class='fa fa-lock']"));
            action.Click(signUp).Build().Perform();

            var inputElements = basePage.browser.FindElements(By.XPath("//input"));
            action.Click(inputElements![4]).SendKeys("Jennifer").Perform();

            randomInt = randomGenerator.Next(1, 1000);
            action.Click(inputElements[5]).SendKeys(email(randomInt)).Perform();

            var submitBttn = basePage.browser.FindElement(By.XPath("//*[@data-qa='signup-button']"));
            submitBttn?.Click();

            var title = basePage.browser.FindElement(By.CssSelector("*[id='id_gender1']"));
            action.Click(title).Perform();

            var pasword = basePage.browser.FindElement(By.XPath("//*[@id='password']"));
            pasword?.SendKeys("Justice1212");

            var dayofBirth = basePage.browser.FindElement(By.XPath("//*[@data-qa='days']"));
            SelectElement element1 = new SelectElement(dayofBirth);
            element1.SelectByValue("10");
            Thread.Sleep(2000);

            var monthofBirth = basePage.browser.FindElement(By.XPath("//*[@data-qa='months']"));
            SelectElement element2 = new SelectElement(monthofBirth);
            element2.SelectByText("October");
            Thread.Sleep(2000);

            var yearofBirth = basePage.browser.FindElement(By.XPath("//*[@data-qa='years']"));
            SelectElement element3 = new SelectElement(yearofBirth);
            element3.SelectByValue("2021");
            Thread.Sleep(2000);

            var fName = basePage.browser.FindElement(By.XPath("//*[@data-qa='first_name']"));
            fName?.SendKeys("Jennifer");

            var lName = basePage.browser.FindElement(By.XPath("//*[@data-qa='last_name']"));
            lName?.SendKeys("David");

            var address = basePage.browser.FindElement(By.CssSelector("*[id='address1']"));
            address?.SendKeys("13314 Sharpbill Dr.");

            var country = basePage.browser.FindElement(By.Name("country"));
            SelectElement element4 = new SelectElement(country);
            element4.SelectByValue("United States");
            Thread.Sleep(2000);

            var inputFields = basePage.browser.FindElements(By.XPath("//input"));
            action.Click(inputFields[14]).SendKeys("Texas").Build().Perform();
            action.Click(inputFields[15]).SendKeys("Houston").Build().Perform();
            action.Click(inputFields[16]).SendKeys("TX 77083").Build().Perform();
            action.Click(inputFields[17]).SendKeys("+1800-799-0622").Build().Perform();

            Thread.Sleep(5000);
            var createAcct = basePage.browser.FindElement(By.XPath("//*[@data-qa='create-account']"));
            createAcct?.Click();

            basePage.browser.FindElement(By.CssSelector("[data-qa='continue-button']")).Click();

            bool _result = basePage.browser.Title.Contains("Automation Exercise")
                ? true
                : throw new Exception("Not contained in the title");

            Assert.True(basePage.browser.Title.Contains("Automation Exercise"));
            Console.WriteLine(_result);

            basePage.End();
        }
    }
}
