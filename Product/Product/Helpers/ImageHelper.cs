using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Product.Helpers
{
    public static class ImageHelper
    {
        public static MvcHtmlString Image(this HtmlHelper html, string id, string name, string src, string altText, int height, int width)

        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", src);
            builder.MergeAttribute("alt", altText);
            builder.MergeAttribute("height", height.ToString());
            builder.MergeAttribute("width", width.ToString());
            builder.MergeAttribute("name", name);
            builder.MergeAttribute("id", id);

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString ImageFor<TModel, TValue>(this HtmlHelper<TModel> html, Expression<Func<TModel, TValue>> expression, string altText, int height, int width)
        {
            var name = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(ExpressionHelper.GetExpressionText(expression));
            var id = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldId(ExpressionHelper.GetExpressionText(expression));
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            var base64_src = "data:image/png;base64, " + Convert.ToBase64String((byte[])metadata.Model);

            return Image(html, id, name, base64_src, altText, height, width);
        }
    }
}