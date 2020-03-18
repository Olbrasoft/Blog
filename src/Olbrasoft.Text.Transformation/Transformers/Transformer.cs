using Olbrasoft.Text.Transformation.Markdown;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.Text.Transformation.Transformers
{
    public class Transformer : ITransformer
    {

        private readonly IMarkdownTransformer _markDownTransformer;

        public Transformer(IMarkdownTransformer markDownTransformer)
        {
            _markDownTransformer = markDownTransformer;
        }

        public string TransformMarkdownToHtml(string markdown)
        {
            return _markDownTransformer.TransformToHtml(markdown);
        }

        public string TransformMarkdownToPlainText(string markdown)
        {
            return _markDownTransformer.TransformToPlainText(markdown);
        }
    }
}
