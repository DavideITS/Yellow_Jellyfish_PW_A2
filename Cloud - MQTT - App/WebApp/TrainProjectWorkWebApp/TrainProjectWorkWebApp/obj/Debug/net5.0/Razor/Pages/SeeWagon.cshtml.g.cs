#pragma checksum "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ff2dea31bbc2fb0fa08ef3cc2e0802873ca238fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TrainProjectWorkWebApp.Pages.Pages_SeeWagon), @"mvc.1.0.razor-page", @"/Pages/SeeWagon.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ff2dea31bbc2fb0fa08ef3cc2e0802873ca238fd", @"/Pages/SeeWagon.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"85f3be937833141555859fddc90cb7cc24394204", @"/Pages/_ViewImports.cshtml")]
    public class Pages_SeeWagon : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
  
    ViewData["Title"] = "See Wagon";

#line default
#line hidden
#nullable disable
            WriteLiteral("<h1>TrainProjectWork</h1>\r\n        <h3>See Wagon</h3>\r\n        <button type=\"button\" class=\"logout right\">Logout</button>\r\n        <button type=\"button\" class=\"update left\">Update</button>\r\n        <label class=\"center\">Train Nr?? ");
#nullable restore
#line 10 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                                   Write(Model.nrTrain);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</label>
        <br /><br />

<table class=""tableBackColor"">
    <tr>
    <th class=""center width10 cursorDefault"">Nr?? Wagon</th>
    <th class=""center cursorDefault"">Temperature</th>
    <th class=""center cursorDefault"">Humidity</th>
    <th class=""center cursorDefault"">Smoke</th>
    <th class=""width10 center cursorDefault"">Toilette</th>
    <th class=""width10 center cursorDefault"">Port 1</th>
    <th class=""width10 center cursorDefault"">Port 2</th>
    <th class=""width10 center cursorDefault"">Port 3</th>
    <th class=""width10 center cursorDefault"">Port 4</th>
    <th class=""center cursorDefault"">Date (UTC)</th>
  </tr>
");
#nullable restore
#line 26 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
 for(var i = 0; i < @Model.nrWagon ; i++)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n\r\n    <td class=\"center tableLeft cursorDefault\">");
#nullable restore
#line 30 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                                          Write(Model.trainLiveDataFilterList[i]["nrWagon"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n     </td>\r\n    <td class=\"sendTemp center tableLeft cursorPointer\">");
#nullable restore
#line 32 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                                                   Write(Model.trainLiveDataFilterList[i]["Temp"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ??C</td>\r\n    <td class=\"center tableLeft cursorDefault\">");
#nullable restore
#line 33 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                                          Write(Model.trainLiveDataFilterList[i]["Hum"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("%</td>\r\n");
#nullable restore
#line 34 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
      bool smoke=bool.Parse(@Model.trainLiveDataFilterList[i]["Smoke"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"sendSmoke center tableLeft cursorDefault\">\r\n");
#nullable restore
#line 36 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                 if(smoke == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/true.png\" alt=\"True Img\">\r\n");
#nullable restore
#line 39 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/false.png\" alt=\"False Img\">\r\n");
#nullable restore
#line 43 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n");
#nullable restore
#line 45 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
      bool toilette=bool.Parse(@Model.trainLiveDataFilterList[i]["Toilette"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"sendToilette center tableLeft cursorPointer\">\r\n");
#nullable restore
#line 47 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                 if(toilette == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/open.png\" alt=\"Open Img\">\r\n");
#nullable restore
#line 50 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/lock.png\" alt=\"Lock Img\">\r\n");
#nullable restore
#line 54 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n");
#nullable restore
#line 56 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                  bool port1=bool.Parse(@Model.trainLiveDataFilterList[i]["Port1"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"sendPort1 center tableLeft cursorPointer\">\r\n");
#nullable restore
#line 58 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                 if(port1 == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/open.png\" alt=\"Open Img\">\r\n");
#nullable restore
#line 61 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/lock.png\" alt=\"Lock Img\">\r\n");
#nullable restore
#line 65 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n");
#nullable restore
#line 67 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                  bool port2=bool.Parse(@Model.trainLiveDataFilterList[i]["Port2"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"sendPort2 center tableLeft cursorPointer\">\r\n");
#nullable restore
#line 69 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                 if(port2 == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/open.png\" alt=\"Open Img\">\r\n");
#nullable restore
#line 72 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/lock.png\" alt=\"Lock Img\">\r\n");
#nullable restore
#line 76 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n");
#nullable restore
#line 78 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                  bool port3=bool.Parse(@Model.trainLiveDataFilterList[i]["Port3"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"sendPort3 center tableLeft cursorPointer\">\r\n");
#nullable restore
#line 80 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                 if(port3 == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/open.png\" alt=\"Open Img\">\r\n");
#nullable restore
#line 83 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/lock.png\" alt=\"Lock Img\">\r\n");
#nullable restore
#line 87 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n");
#nullable restore
#line 89 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                  bool port4=bool.Parse(@Model.trainLiveDataFilterList[i]["Port4"].ToString());

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td class=\"sendPort4 center tableLeft cursorPointer\">\r\n");
#nullable restore
#line 91 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                 if(port4 == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/open.png\" alt=\"Open Img\">\r\n");
#nullable restore
#line 94 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <img class=\"tableImg\" src=\"img/lock.png\" alt=\"Lock Img\">\r\n");
#nullable restore
#line 98 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n    <td class=\"center cursorDefault\">");
#nullable restore
#line 100 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                                Write(Model.trainLiveDataFilterList[i]["date"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 102 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
    
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\r\n\r\n<script type=\"text/javascript\">\r\n\r\n    setTimeout(function(){ \r\n\t    window.location.href = \"https://localhost:44305/SeeWagon?handler=\" + ");
#nullable restore
#line 109 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                                                                        Write(Model.nrTrain);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    }, 5000);

    var docSendTempList = document.getElementsByClassName(""sendTemp"");
    var docSendToiletteList = document.getElementsByClassName(""sendToilette"");
    var docSendPort1List = document.getElementsByClassName(""sendPort1"");
    var docSendPort2List = document.getElementsByClassName(""sendPort2"");
    var docSendPort3List = document.getElementsByClassName(""sendPort3"");
    var docSendPort4List = document.getElementsByClassName(""sendPort4"");


    for (let i = 0; i < docSendTempList.length; i++) {
	    var docSendTemp = docSendTempList[i];
        var docSendToilette = docSendToiletteList[i];
        var docSendPort1 = docSendPort1List[i];
        var docSendPort2 = docSendPort2List[i];
        var docSendPort3 = docSendPort3List[i];
        var docSendPort4 = docSendPort4List[i];

        docSendTemp.addEventListener(""click"", function() {
            changeData(""1-"" + (i+1) + ""-Temp"");
        });

        docSendToilette.addEventListener(""click"", function() {
            ");
            WriteLiteral("changeData(");
#nullable restore
#line 133 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                  Write(Model.nrTrain);

#line default
#line hidden
#nullable disable
            WriteLiteral(" + \"-\" + (i+1) + \"-Toilette\");\r\n        });\r\n\r\n        docSendPort1.addEventListener(\"click\", function() {\r\n            changeData(");
#nullable restore
#line 137 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                  Write(Model.nrTrain);

#line default
#line hidden
#nullable disable
            WriteLiteral(" + \"-\" + (i+1) + \"-Port1\");\r\n        });\r\n\r\n        docSendPort2.addEventListener(\"click\", function() {\r\n            changeData(");
#nullable restore
#line 141 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                  Write(Model.nrTrain);

#line default
#line hidden
#nullable disable
            WriteLiteral(" + \"-\" + (i+1) + \"-Port2\");\r\n        });\r\n\r\n        docSendPort3.addEventListener(\"click\", function() {\r\n            changeData(");
#nullable restore
#line 145 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                  Write(Model.nrTrain);

#line default
#line hidden
#nullable disable
            WriteLiteral(" + \"-\" + (i+1) + \"-Port3\");\r\n        });\r\n\r\n        docSendPort4.addEventListener(\"click\", function() {\r\n            changeData(");
#nullable restore
#line 149 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                  Write(Model.nrTrain);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" + ""-"" + (i+1) + ""-Port4"");
        });
    }

	function changeData(y){
        console.log(window.location.href)
	    console.log(y)

        var windowsLocArr = window.location.href
        var windowsLoc = windowsLocArr.split('SeeWagon')[0]
        console.log(windowsLoc)

        dataSplit = y.split(""-"");

        //Cosa si vuole cambiare
        console.log(dataSplit[2])

        //Nr vagone
        console.log(dataSplit[1])

        //Nr treno
        console.log(dataSplit[0])

        if(dataSplit[2] === ""Temp""){
            window.location.href = windowsLoc + ""ChangeTemp?handler="" + dataSplit[0] + ""-"" + dataSplit[1]
            //window.location.href = ""https://localhost:44305/ChangeTemp?handler="" + dataSplit[0] + ""-"" + dataSplit[1]
        }else if(dataSplit[2].startsWith(""Port"") || dataSplit[2] === ""Toilette""){
            window.location.href = windowsLoc + ""ChangePort?handler="" + y
            //window.location.href = ""https://localhost:44305/ChangePort?handler="" + y
 ");
            WriteLiteral(@"       }else{

        }
    }

    //Logout
    var logoutList = document.getElementsByClassName(""logout"");
    logoutList[0].addEventListener(""click"", function() {

        var windowsLocArr = window.location.href
        var windowsLoc = windowsLocArr.split('SeeWagon')[0]
        console.log(windowsLoc)

        window.location.href = windowsLoc + ""Index?handler=Logout""
        //window.location.href = ""https://localhost:44305/Index?handler=Logout""
    });

    //Update Page
    var updateList = document.getElementsByClassName(""update"");
    updateList[0].addEventListener(""click"", function() {

        var windowsLocArr = window.location.href
        var windowsLoc = windowsLocArr.split('SeeWagon')[0]
        console.log(windowsLoc)

        window.location.href = windowsLoc + ""SeeWagon?handler="" + ");
#nullable restore
#line 203 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                                                             Write(Model.nrTrain);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n        //window.location.href = \"https://localhost:44305/SeeWagon?handler=\" + ");
#nullable restore
#line 204 "C:\DIQU\Anno 2\Project Work\Yellow_Jellyfish_PW_A2\Cloud - MQTT - App\WebApp\TrainProjectWorkWebApp\TrainProjectWorkWebApp\Pages\SeeWagon.cshtml"
                                                                          Write(Model.nrTrain);

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n    });\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TrainProjectWorkWebApp.Pages.SeeWagonModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TrainProjectWorkWebApp.Pages.SeeWagonModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TrainProjectWorkWebApp.Pages.SeeWagonModel>)PageContext?.ViewData;
        public TrainProjectWorkWebApp.Pages.SeeWagonModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
