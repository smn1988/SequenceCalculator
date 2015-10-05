using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;


namespace SequenceCalculatorCodeUI
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class SequenceCalcCodedUI
    {
        public SequenceCalcCodedUI()
        {
        }

        [TestMethod]
        public void CodedUITestMethod1()
        {
            var browser = BrowserWindow.Launch("http://localhost/SequenceCalculator");
            AddValueToTextBox(browser,20);
            ClickButton(browser);
            ClickTryAgainHyperLink(browser);
            AddValueToTextBox(browser, -20);
            ClickButton(browser);
            CheckValidation(browser);
            browser.CloseOnPlaybackCleanup = false;
        }

        private void ClickButton(UITestControl parent)
        {
            var button = new HtmlInputButton(parent);
            button.SearchProperties.Add(HtmlInputButton.PropertyNames.Id, "submit");
            Mouse.Click(button);
        }

        private void AddValueToTextBox(UITestControl parent,int value)
        {
            var edit = new HtmlEdit(parent);
            edit.SearchProperties.Add(HtmlEdit.PropertyNames.Id, "number");
            edit.Text = value.ToString();
        }

        private void ClickTryAgainHyperLink(BrowserWindow browser)
        {
            var hyperLink = new HtmlHyperlink(browser);
            hyperLink.SearchProperties.Add(HtmlHyperlink.PropertyNames.InnerText, "Try Again");
            Mouse.Click(hyperLink);
        }

        private void CheckValidation(BrowserWindow browser)
        {
            var label = new HtmlLabel();
            label.SearchProperties.Add(HtmlLabel.PropertyNames.InnerText, "Please enter positive number greater than 0");
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        ////Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        #endregion

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;
    }
}
