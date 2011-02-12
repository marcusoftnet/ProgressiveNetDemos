using TechTalk.SpecFlow;
using WatiN.Core;

namespace SpecsAgainstGUI.Steps.Infrastructure
{
    [Binding]
    public class WebBrowser
    {
        private const string BROWSER_KEY = "browser";

        public static Browser Current
        {
            get
            {
                if (!ScenarioContext.Current.ContainsKey(BROWSER_KEY))
                    ScenarioContext.Current[BROWSER_KEY] = new IE();
                return (Browser)ScenarioContext.Current[BROWSER_KEY];
            }
        }

        [AfterScenario]
        public static void Close()
        {
            if (ScenarioContext.Current.ContainsKey(BROWSER_KEY))
                Current.Close();
        }
    }
}
