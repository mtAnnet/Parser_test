using System.Collections.Generic;
using System.Linq;
using AngleSharp.Html.Dom;

namespace Parser.Core.Inspections
{
    class InspectionsParser : IParser<string[]>
    {
        public string[] Parse(IHtmlDocument document)
        {
            
            var list = new List<string>();
            var items = document.QuerySelectorAll("a").Where(item => item.ClassName != null && item.ClassName.Contains("table_action_btn icon-details"));

            foreach (var item in items)
            {
                list.Add(item.GetAttribute("href"));
            
            }
            
            return list.ToArray();
        }
    }
}
