#pragma checksum "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\ChangeTemp.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a01cf8fddd80e2d51175d29ea9de17a0bce05e5c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TrainProjectWorkWebApp.Pages.Pages_ChangeTemp), @"mvc.1.0.razor-page", @"/Pages/ChangeTemp.cshtml")]
namespace TrainProjectWorkWebApp.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\_ViewImports.cshtml"
using TrainProjectWorkWebApp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a01cf8fddd80e2d51175d29ea9de17a0bce05e5c", @"/Pages/ChangeTemp.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85f3be937833141555859fddc90cb7cc24394204", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ChangeTemp : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\ChangeTemp.cshtml"
  
    ViewData["Title"] = "Change Temperature Values";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>TrainProjectWork</h1>\r\n<h4>Train: ");
#nullable restore
#line 8 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\ChangeTemp.cshtml"
      Write(Model.nrTrain);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n<h4>Change Temperature Values</h4>\r\n<button type=\"button\" class=\"logout right\">Logout</button>\r\n<br /><br />\r\n\r\n<label class=\"errorToSee\">");
#nullable restore
#line 13 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\ChangeTemp.cshtml"
                     Write(Model.ErrorToSee);

#line default
#line hidden
#nullable disable
            WriteLiteral("</label>\r\n<br />\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a01cf8fddd80e2d51175d29ea9de17a0bce05e5c4738", async() => {
                WriteLiteral("\r\n    <table class=\"center\">\r\n        <tr>\r\n                    <td>\r\n                        <label for=\"newTemp\">New Temperature Values:</label>\r\n                    </td>\r\n                    <td>\r\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("label", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a01cf8fddd80e2d51175d29ea9de17a0bce05e5c5235", async() => {
                    WriteLiteral("\r\n                            <input type=\"number\"  id=\"newTemp\" name=\"newTemp\" step=\"0.10\" min=10.00 max=30.00 value=20.0>\r\n                        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.LabelTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper);
#nullable restore
#line 23 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\ChangeTemp.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.newTemp);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_LabelTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n    </table>\r\n    <br />\r\n    <input type=\"submit\" value=\"Submit\">\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TrainProjectWorkWebApp.Pages.ChangeTempModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TrainProjectWorkWebApp.Pages.ChangeTempModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TrainProjectWorkWebApp.Pages.ChangeTempModel>)PageContext?.ViewData;
        public TrainProjectWorkWebApp.Pages.ChangeTempModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
