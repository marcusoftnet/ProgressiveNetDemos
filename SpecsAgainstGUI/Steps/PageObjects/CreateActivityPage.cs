using SpecsAgainstGUI.Steps.Infrastructure;

namespace SpecsAgainstGUI.Steps.PageObjects
{
    public class CreateActivityPage : PageObjectBase
    {
        public CreateActivityPage() : base(WebBrowser.Current, "/Activities/Create") { }
    }
}