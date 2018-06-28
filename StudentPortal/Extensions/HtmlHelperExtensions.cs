using System.Linq.Expressions;

namespace System.Web.Mvc.Html
{
    //Label For Extension To Append Asterix on Required Field
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString CustomLabelFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var resolvedLabelText = metadata.DisplayName ?? metadata.PropertyName;
            if (metadata.IsRequired)
            {
                resolvedLabelText += "*";
            }
            return LabelExtensions.LabelFor<TModel, TValue>(html, expression, resolvedLabelText, htmlAttributes);
        }
    }
}