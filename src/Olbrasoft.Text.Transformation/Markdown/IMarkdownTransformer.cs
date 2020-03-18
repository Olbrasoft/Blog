namespace Olbrasoft.Text.Transformation.Markdown
{
    public interface IMarkdownTransformer
    {
        public string TransformToHtml(string markdown);

        public string TransformToPlainText(string markdown);
    }
}