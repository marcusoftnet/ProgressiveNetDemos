using System;
using System.Configuration;
using WatiN.Core;

namespace SpecsAgainstGUI.Steps.PageObjects
{
    public abstract class PageObjectBase
    {
        protected readonly Browser Browser;
        private readonly string relativeUrl;

        protected PageObjectBase(Browser browser, string relativeUrl)
        {
            Browser = browser;
            this.relativeUrl = relativeUrl;
        }

        public void Visit()
        {
            var rootUrl = new Uri(ConfigurationManager.AppSettings["RootUrl"]);
            var absoluteUrl = new Uri(rootUrl, relativeUrl);
            Browser.GoTo(absoluteUrl);
        }

        protected void ClickLink(string linkText)
        {
            Browser.Link(x => x.Text == linkText).Click();
        }

        public string Title
        {
            get { return Browser.Title; }
        }
    }
}