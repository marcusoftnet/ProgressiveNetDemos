using SpecsAgainstGUI.Steps.Infrastructure;
using WatiN.Core;

namespace SpecsAgainstGUI.Steps.PageObjects
{
    public class ActivitiesPage : PageObjectBase
    {
        public ActivitiesPage() : base(WebBrowser.Current, "/Activities") { }

        
    }
}
