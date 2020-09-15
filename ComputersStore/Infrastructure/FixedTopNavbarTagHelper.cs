using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputersStore.WebUI.Infrastructure
{
    [HtmlTargetElement("nav", Attributes = "fixed-top-nav")]
    public class FixedTopNavbarTagHelper : TagHelper
    {
        /// <summary>
        /// Gets or sets the <see cref="T:Microsoft.AspNetCore.Mvc.Rendering.ViewContext" /> for the current request.
        /// </summary>
        [HtmlAttributeNotBound]
        [ViewContext]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            base.Process(context, output);

            if (ShouldBeActive())
            {
                MakeFixedTop(output);
            }

            output.Attributes.RemoveAll("fixed-top-nav");
        }

        private bool ShouldBeActive()
        {
            string currentController = ViewContext.RouteData.Values["Controller"].ToString();
            string currentAction = ViewContext.RouteData.Values["Action"].ToString();

            if (!string.IsNullOrWhiteSpace(currentController) 
                && currentController.ToLower() == "account" 
                && !string.IsNullOrWhiteSpace(currentAction) 
                && (currentAction.ToLower() == "login" || currentAction.ToLower() == "register"))
            { 
                return false;
            }
            else
            {
                return true;
            }
        }

        private void MakeFixedTop(TagHelperOutput output)
        {
            var classAttr = output.Attributes.FirstOrDefault(a => a.Name == "class");
            if (classAttr == null)
            {
                classAttr = new TagHelperAttribute("class", "fixed-top");
                output.Attributes.Add(classAttr);
            }
            else if (classAttr.Value == null || classAttr.Value.ToString().IndexOf("active") < 0)
            {
                output.Attributes.SetAttribute("class", classAttr.Value == null
                    ? "fixed-top"
                    : classAttr.Value.ToString() + " fixed-top");
            }
        }
    }
}
