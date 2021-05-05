using System;
using NUnit.Framework;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DotNet_Web_primeiros_passos
{
    class Program
    {
        static void Main()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            var chrome = new ChromeDriver();
            chrome.Navigate().GoToUrl("https://secure.kanui.com.br/customer/account/login/");
            var titulo = chrome.Title.ToString();
            Assert.AreEqual("Cadastre-se ou entre em sua conta para finalizar a compra", titulo);
            chrome.FindElementById("LoginForm_email").SendKeys("qualquertexto");
            chrome.FindElementById("LoginForm_password").SendKeys("qualquerSenha");
            chrome.FindElementByCssSelector("#wrapper > div.l-full-content.l-container > div > div.auth-forms.no-social-interface.col-md-5 > ul > li:nth-child(2) > label > h2").Click();
            chrome.FindElementByXPath("//*[@id='RegistrationForm_customer_personality']/label[1]").Click();
            chrome.FindElementById("RegistrationForm_first_name").SendKeys("qualquerNome");
            chrome.FindElementById("RegistrationForm_last_name").SendKeys("qualquerSobrenome");
            chrome.FindElementById("RegistrationForm_email").SendKeys("qualquerEmail");
            chrome.FindElementByXPath("//*[contains(RegistrationForm)]/option[2]").Click();
            chrome.FindElementById("RegistrationForm_tax_identification").SendKeys("12345678900");
            //chrome.FindElementById("RegistrationForm_day").SendKeys("25");
            var nascimento = chrome.FindElementByXPath("//*[@id='login-account-create']/div[8]/label").Text;
            Assert.AreEqual("Nascimento", nascimento);
            chrome.FindElementByXPath("//*[@id=\"RegistrationForm_day\"]/option[25]").Click();
            chrome.FindElementById("RegistrationForm_month").SendKeys("02");
            chrome.FindElementById("RegistrationForm_year").SendKeys("1986");
            chrome.FindElementById("form-customer-account-password").SendKeys("senha");
            chrome.FindElementById("RegistrationForm_password2").SendKeys("confirmarSenha");
            chrome.FindElementById("RegistrationForm_password2").Submit();
            

            //chrome.Close();
            //chrome.Quit();
        }
    }
}