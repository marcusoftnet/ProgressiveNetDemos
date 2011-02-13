using System.Linq;
using TechTalk.SpecFlow;

namespace SpecsAgainstController.Steps.Helpers
{
    public static class TableExtensions
    {
        public static string GetValueForField(this Table table, string fieldName)
        {
            var row = table.Rows.Single(x => x["Field"] == fieldName);
            return row["Value"];
        }
    }
}
