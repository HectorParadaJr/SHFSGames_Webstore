#pragma checksum "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\MemberFriendsFamilyLists\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b774a45a869a169427787172b5ea4c04b24a3de1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MemberFriendsFamilyLists_Index), @"mvc.1.0.view", @"/Views/MemberFriendsFamilyLists/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b774a45a869a169427787172b5ea4c04b24a3de1", @"/Views/MemberFriendsFamilyLists/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"64da9af0443295e4453f5c515f88b13fbd066503", @"/Views/_ViewImports.cshtml")]
    public class Views_MemberFriendsFamilyLists_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SHFSGAMES.Models.MemberFriendsFamilyLists>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "AddMember", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "DeleteFromList", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\MemberFriendsFamilyLists\Index.cshtml"
  
    ViewData["Title"] = "Friends & Family List";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Members in Your Friends and Family List</h1>\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b774a45a869a169427787172b5ea4c04b24a3de14398", async() => {
                WriteLiteral("Add Member to List");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\MemberFriendsFamilyLists\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 21 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\MemberFriendsFamilyLists\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 25 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\MemberFriendsFamilyLists\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b774a45a869a169427787172b5ea4c04b24a3de16902", async() => {
                WriteLiteral("Remove");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\MemberFriendsFamilyLists\Index.cshtml"
                                                     WriteLiteral(item.FriendsFamilyListId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\MemberFriendsFamilyLists\Index.cshtml"
                                                                                                    WriteLiteral(item.Username);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-username", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["username"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#nullable restore
#line 28 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\MemberFriendsFamilyLists\Index.cshtml"
                                                                                                                                        WriteLiteral(item.MemberId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["memberId"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-memberId", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["memberId"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                    ");
#nullable restore
#line 29 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\MemberFriendsFamilyLists\Index.cshtml"
               Write(ViewBag.error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 32 "C:\Users\latin\Documents\Conestoga College\PROG3050-Programming Microsoft Enterprise Applications\SHFSGAMES\SHFSGAMES\Views\MemberFriendsFamilyLists\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SHFSGAMES.Models.MemberFriendsFamilyLists>> Html { get; private set; }
    }
}
#pragma warning restore 1591
