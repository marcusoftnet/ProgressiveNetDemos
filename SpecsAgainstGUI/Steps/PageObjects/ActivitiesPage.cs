using System.Collections.Generic;
using System.Linq;
using SpecsAgainstGUI.Steps.Infrastructure;

namespace SpecsAgainstGUI.Steps.PageObjects
{
    public class ActivitiesPage : PageObjectBase
    {
        public ActivitiesPage() : base(WebBrowser.Current, "/Activities") { }

        public IEnumerable<string> ActitvityTable_Who
        {
            get
            {
                return (from cell in Browser.TableCells.Filter(x => x.Id == "who")
                        select cell.Text.Trim()).ToList();
            }
        }

        public void NavigateToCreateNew()
        {
            ClickLink("Create New");
        }
    }
}
