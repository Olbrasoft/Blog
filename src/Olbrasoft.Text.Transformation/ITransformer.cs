using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.Text.Transformation
{
    public interface ITransformer
    {
        public string TransformMarkdownToHtml(string markdown);

        public string TransformMarkdownToPlainText(string markdown);
    }
}
