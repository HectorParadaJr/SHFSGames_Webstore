#pragma checksum "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e1c59efbb8eb09535c6186d78ae29975fba21b77"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Orders_SalesReport), @"mvc.1.0.view", @"/Views/Orders/SalesReport.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e1c59efbb8eb09535c6186d78ae29975fba21b77", @"/Views/Orders/SalesReport.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64da9af0443295e4453f5c515f88b13fbd066503", @"/Views/_ViewImports.cshtml")]
    public class Views_Orders_SalesReport : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SHFSGAMES.Models.Orders>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
  
    ViewData["Title"] = "Sales Report";

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
   
    double total = 0;
    int quantity = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<h1>Sales Report</h1>
<h5><a href=""javascript:window.print()"" class=""btn btn-dark no-print"">Print Report</a></h5>

<table class=""table"">
    <thead>
        <tr>
            <th>
                Order Date:
            </th>
            <th>
                Customer Name:
            </th>
            <th>
                Quantity:
            </th>
            <th>
                Shipped Status:
            </th>
            <th>
                Shipped Date:
            </th>
            <th>
                Total:
            </th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 39 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n");
#nullable restore
#line 43 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
                   
                    var orderDate = item.OrderDate;
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
#nullable restore
#line 46 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
           Write(orderDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 49 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
           Write(Html.DisplayFor(modelItem => item.Members.FirstName));

#line default
#line hidden
#nullable disable
            WriteLiteral(" ");
#nullable restore
#line 49 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
                                                                 Write(Html.DisplayFor(modelItem => item.Members.LastName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 52 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
                   quantity = 0;

#line default
#line hidden
#nullable disable
#nullable restore
#line 53 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
                 foreach (var order in item.OrderItems)
                {
                    quantity += order.Quantity;
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
#nullable restore
#line 57 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
           Write(quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 60 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
           Write(Html.DisplayFor(modelItem => item.Status));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 63 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
                   
                    var shipDate = item.ShippedDate;
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
#nullable restore
#line 66 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
           Write(shipDate.ToShortDateString());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 69 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
                  
                    var totalItem = item.Total;
                    total += item.Total;
                

#line default
#line hidden
#nullable disable
            WriteLiteral("                ");
#nullable restore
#line 73 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
           Write(totalItem.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 76 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td></td>\r\n            <td></td>\r\n            <td>Total Sales: ");
#nullable restore
#line 80 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\Orders\SalesReport.cshtml"
                        Write(total.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SHFSGAMES.Models.Orders>> Html { get; private set; }
    }
}
#pragma warning restore 1591
