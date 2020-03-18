using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.AspNetCore.Mvc.TagHelpers
{
    [HtmlTargetElement("raw")]
    public class RawTagHelper : TagHelper
    {
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            output.Content.SetContent((await output.GetChildContentAsync()).GetContent());
        }
    }
}