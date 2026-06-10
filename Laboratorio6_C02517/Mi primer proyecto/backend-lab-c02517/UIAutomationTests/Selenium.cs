using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace UIAutomationTests
{
    public class Selenium
    {
        IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Enter_To_List_Of_Countries_Test()
        { 
            //Arrange
            //Abre una nueva ventana
            var URL = "http://localhost:8080/";

            //Maximiza la pantalla
            _driver.Manage().Window.Maximize();

            //Act
            //Navega a la pagina que se necesita probar
            _driver.Navigate().GoToUrl(URL);

            //Assert
            //Verifica que el titulo de la pagina sea el correcto
            Assert.That(_driver.Title, Is.EqualTo("frontend-lab"));
        }

        [Test]
        public void Create_Country_Test()
        {
            // Arrange
            var URL = "http://localhost:8080/";

            // Act
            _driver.Navigate().GoToUrl(URL);

            // Assert pagina inicial
            Assert.That(_driver.Title, Is.EqualTo("frontend-lab"));

            // Navegar al formulario
            IWebElement addButton =
                _driver.FindElement(By.XPath("//button[contains(text(),'Agregar país')]"));

            addButton.Click();

            // Verificar formulario
            IWebElement formTitle =
                _driver.FindElement(By.TagName("h3"));

            Assert.That(formTitle.Text,
                Is.EqualTo("Formulario de creación de países"));

            // Llenar formulario
            _driver.FindElement(By.Id("name"))
                .SendKeys("Paraguay");

            _driver.FindElement(By.Id("continente"))
                .SendKeys("América");

            _driver.FindElement(By.Id("idioma"))
                .SendKeys("Español");

            // Guardar
            _driver.FindElement(By.XPath("//button[@type='submit']"))
                .Click();

          
            Thread.Sleep(2000);
            // Mensaje de exito
            IWebElement successMessage = _driver.FindElement(By.Id("success-message"));

            Assert.That(successMessage.Text, Is.EqualTo("País creado correctamente"));

            // Redireccion
            Thread.Sleep(4000);
            IWebElement listTitle =
                _driver.FindElement(By.TagName("h1"));

            Assert.That(listTitle.Text,
                Is.EqualTo("Lista de países"));

            // Verificar que el país aparece
            Assert.That(
                _driver.PageSource.Contains("Paraguay"),
                Is.True
            );
        }

    }
}
