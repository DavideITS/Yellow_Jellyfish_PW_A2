#pragma checksum "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\ConfermDataSend.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5526a8cdab85c391ea3d831b003a50ae073bb61a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TrainProjectWorkWebApp.Pages.Pages_ConfermDataSend), @"mvc.1.0.razor-page", @"/Pages/ConfermDataSend.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5526a8cdab85c391ea3d831b003a50ae073bb61a", @"/Pages/ConfermDataSend.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85f3be937833141555859fddc90cb7cc24394204", @"/Pages/_ViewImports.cshtml")]
    public class Pages_ConfermDataSend : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\ConfermDataSend.cshtml"
  
    ViewData["Title"] = "Conferm Data Send";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>TrainProjectWork</h1>\r\n<h3>");
#nullable restore
#line 8 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\ConfermDataSend.cshtml"
Write(Model.ResultStr);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h3>

<br />
<button type=""button"" class=""home"">Home</button>
<br /><br />
<button type=""button"" class=""logout"">Logout</button>

<script type=""text/javascript"">
    //Logout
    var logoutList = document.getElementsByClassName(""logout"");
    logoutList[0].addEventListener(""click"", function() {
            window.location.href = ""https://localhost:44305/Index?handler=Logout""
        });

        //Home
    var homeList = document.getElementsByClassName(""home"");
    homeList[0].addEventListener(""click"", function() {
            window.location.href = ""https://localhost:44305/Index"";
        });
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TrainProjectWorkWebApp.Pages.ConfermDataSendModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TrainProjectWorkWebApp.Pages.ConfermDataSendModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TrainProjectWorkWebApp.Pages.ConfermDataSendModel>)PageContext?.ViewData;
        public TrainProjectWorkWebApp.Pages.ConfermDataSendModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
