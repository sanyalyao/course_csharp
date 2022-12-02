using OpenQA.Selenium;
using System;
using OpenQA.Selenium.Firefox;
using System.Threading;

namespace mantis_tests
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;
        private RegistrationHelper registration;
        private FtpHelper ftp;
        private NavigationHelper navigation;
        private LoginHelper auth;
        private ProjectHelper project;
        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.25.4/login_page.php";
            registration = new RegistrationHelper(this);
            ftp = new FtpHelper(this);
            navigation = new NavigationHelper(this, baseURL);
            auth = new LoginHelper(this);
            project = new ProjectHelper(this);
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.Navigation.OpenMainPage();
                app.Value = newInstance;
            }
            return app.Value;
        }
        public IWebDriver Driver
        {
            get { return driver; }
        }

        public RegistrationHelper Registration 
        { 
            get 
            {
                return registration; 
            } 
        }
        public FtpHelper Ftp 
        { 
            get
            {
                return ftp;
            }
        }
        public NavigationHelper Navigation 
        { 
            get
            {
                return navigation;
            }
        }
        public LoginHelper Auth 
        { 
            get
            {
                return auth;
            }
        }

        public ProjectHelper Project
        {
            get
            {
                return project;
            }
        }
    }
}
