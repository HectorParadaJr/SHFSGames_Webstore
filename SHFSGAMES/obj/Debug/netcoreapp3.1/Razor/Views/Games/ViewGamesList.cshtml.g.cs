#pragma checksum "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Games\ViewGamesList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c7e719be9360d9783f745660532bdc493ec3bc4c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Games_ViewGamesList), @"mvc.1.0.view", @"/Views/Games/ViewGamesList.cshtml")]
namespace AspNetCore
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
#line 1 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\_ViewImports.cshtml"
using SHFSGAMES;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\_ViewImports.cshtml"
using SHFSGAMES.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c7e719be9360d9783f745660532bdc493ec3bc4c", @"/Views/Games/ViewGamesList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64da9af0443295e4453f5c515f88b13fbd066503", @"/Views/_ViewImports.cshtml")]
    public class Views_Games_ViewGamesList : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SHFSGAMES.Models.Games>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Games\ViewGamesList.cshtml"
  
    ViewData["Title"] = "Games List Report";
    var i = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>List of Games</h1>\r\n<h5><a href=\"javascript:window.print()\" class=\"btn btn-dark no-print\">Print Report</a></h5>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>#</th>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Games\ViewGamesList.cshtml"
           Write(Html.DisplayNameFor(model => model.GameName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Games\ViewGamesList.cshtml"
           Write(Html.DisplayNameFor(model => model.ReleaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 23 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Games\ViewGamesList.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 27 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Games\ViewGamesList.cshtml"
           Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 28 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Games\ViewGamesList.cshtml"
                   
                    i++;
                

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 33 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Games\ViewGamesList.cshtml"
           Write(Html.DisplayFor(modelItem => item.GameName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 36 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Games\ViewGamesList.cshtml"
           Write(Html.DisplayFor(modelItem => item.ReleaseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 39 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Games\ViewGamesList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SHFSGAMES.Models.Games>> Html { get; private set; }
    }
}
#pragma warning restore 1591
