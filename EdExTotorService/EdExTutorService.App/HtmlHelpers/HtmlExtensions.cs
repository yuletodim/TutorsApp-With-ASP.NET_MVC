namespace EdExTutorService.App.HtmlHelpers
{
    using System.Collections.Generic;
    using System.Web.Mvc;


    public static class HtmlExtensions
    {
        public static MvcHtmlString Email(this HtmlHelper htmlHelper, object htmlAttributes = null)
        {
            TagBuilder emailBuilder = new TagBuilder("input");
            emailBuilder.Attributes.Add("type", "email");

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;
            emailBuilder.MergeAttributes(attributes);

            return new MvcHtmlString(emailBuilder.ToString());
        }

        public static MvcHtmlString Tel(this HtmlHelper htmlHelper, object htmlAttributes = null)
        {
            TagBuilder telBuilder = new TagBuilder("input");
            telBuilder.Attributes.Add("type", "tel");

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;
            // IDictionary<string, object> attr = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);
            telBuilder.MergeAttributes(attributes);

            return new MvcHtmlString(telBuilder.ToString());
        }

        public static MvcHtmlString Submit(this HtmlHelper htmlHelper, object htmlAttributes = null)
        {
            TagBuilder submitBuilder = new TagBuilder("input");
            submitBuilder.MergeAttribute("type", "submit");
            submitBuilder.MergeAttribute("value", "Submit");

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;
            submitBuilder.MergeAttributes(attributes);

            return new MvcHtmlString(submitBuilder.ToString());
        }

        public static MvcHtmlString Image(this HtmlHelper htmlHelper, string imgUrl, object htmlAttributes = null)
        {
            TagBuilder imageBuilder = new TagBuilder("img");
            imageBuilder.MergeAttribute("src", "imgUrl");

            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;
            imageBuilder.MergeAttributes(attributes);

            return new MvcHtmlString(imageBuilder.ToString());
        }
    }
}