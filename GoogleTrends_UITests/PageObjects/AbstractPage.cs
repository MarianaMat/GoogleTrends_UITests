using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleTrends_UITests.PageObjects

{
    public abstract class AbstractPage
    {
        public IWebDriver driver;
        protected static ILog log;
        public AbstractPage(IWebDriver driver)
        {
            this.driver = driver;
            log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

    }
}
