#pragma checksum "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4d2bbe55b4f6a1a30603f81963982400029fb50b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CartItems_Index), @"mvc.1.0.view", @"/Views/CartItems/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4d2bbe55b4f6a1a30603f81963982400029fb50b", @"/Views/CartItems/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64da9af0443295e4453f5c515f88b13fbd066503", @"/Views/_ViewImports.cshtml")]
    public class Views_CartItems_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SHFSGAMES.Models.CartItems>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Games", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MemberDetails", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "EmptyCart", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "PlaceOrder", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
  
    ViewData["Title"] = "Cart";
    double cartTotal = 0;
    int items = 0;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Your Cart</h1>\r\n<p>NOTE: PC version = Digital Version</p>\r\n<div class=\"text-success\">\r\n    ");
#nullable restore
#line 12 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
Write(ViewBag.cart);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div id=\"orderMsg\" class=\"text-success\">\r\n    ");
#nullable restore
#line 15 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
Write(TempData["order"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n<div class=\"text-danger\">");
#nullable restore
#line 17 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
                    Write(ViewBag.order);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n<div class=\"text-danger\">");
#nullable restore
#line 18 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
                    Write(ViewBag.msg);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Games));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                Platform\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 33 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 39 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
         foreach (var item in Model)
        {
            items++;

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d2bbe55b4f6a1a30603f81963982400029fb50b9003", async() => {
                WriteLiteral("\r\n                        ");
#nullable restore
#line 45 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Games.GameName));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 44 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
                                                                           WriteLiteral(item.GameId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 49 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Platforms.PlatformName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 52 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Quantity));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 55 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Price));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 56 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
                      
                        var quantity = item.Quantity;
                        var price = item.Price;

                        cartTotal += quantity * price;
                    

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d2bbe55b4f6a1a30603f81963982400029fb50b13599", async() => {
                WriteLiteral("Edit Quantity");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 64 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
                                           WriteLiteral(item.CartItemId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d2bbe55b4f6a1a30603f81963982400029fb50b15857", async() => {
                WriteLiteral("Delete");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 65 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
                                             WriteLiteral(item.CartItemId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 68 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<div>\r\n    <p>Cart Total: ");
#nullable restore
#line 72 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
              Write(cartTotal.ToString("C"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p> <br />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d2bbe55b4f6a1a30603f81963982400029fb50b18785", async() => {
                WriteLiteral("Empty Cart");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>\r\n<br />\r\n");
#nullable restore
#line 76 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
 if (items > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d2bbe55b4f6a1a30603f81963982400029fb50b20248", async() => {
                WriteLiteral("Check Out");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 79 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\CartItems\Index.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SHFSGAMES.Models.CartItems>> Html { get; private set; }
    }
}
#pragma warning restore 1591