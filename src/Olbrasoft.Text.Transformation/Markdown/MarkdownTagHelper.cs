using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace Olbrasoft.Text.Transformation.Markdown
{
    [HtmlTargetElement("markdown")]
    public class MarkdownTagHelper : TagHelper
    {
        private readonly IMarkdownTransformer _transformer;

        [HtmlAttributeName("to")]
        public TextType To { get; set; }

        public MarkdownTagHelper(IMarkdownTransformer transformer)
        {
            _transformer = transformer;
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;

            var content = (await output.GetChildContentAsync()).GetContent();

            switch (To)
            {
                case TextType.Html:
                    content = _transformer.TransformToHtml(content);
                    break;

                case TextType.Markdown:
                    break;

                default:
                    content = _transformer.TransformToPlainText(content);
                    break;
            }

            output.Content.SetHtmlContent(content);
        }
    }
}