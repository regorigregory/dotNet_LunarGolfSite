#pragma checksum "C:\Users\Madero\source\repos\LunarSports\Views\Default\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bb939c45e88cd6a01da08bf724ecba2c98a259a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(LunarSports.Default.Views_Default_Index), @"mvc.1.0.view", @"/Views/Default/Index.cshtml")]
namespace LunarSports.Default
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 3 "C:\Users\Madero\source\repos\LunarSports\_ViewImports.cshtml"
using LunarSports.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\Madero\source\repos\LunarSports\Views\_ViewImports.cshtml"
using LunarSports;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Madero\source\repos\LunarSports\Views\_ViewImports.cshtml"
using LunarSports.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Madero\source\repos\LunarSports\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Madero\source\repos\LunarSports\Views\_ViewImports.cshtml"
using System.Linq;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bb939c45e88cd6a01da08bf724ecba2c98a259a", @"/Views/Default/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b4f4a0c3237e9bc8afc6c45da77233d9554c0bb1", @"/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c5abc0aafb5206fbeb2f5cea989ab873e75f4476", @"/Views/_ViewImports.cshtml")]
    public class Views_Default_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Madero\source\repos\LunarSports\Views\Default\Index.cshtml"
 if (ViewBag.Page != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2> ");
#nullable restore
#line 3 "C:\Users\Madero\source\repos\LunarSports\Views\Default\Index.cshtml"
    Write(ViewBag.Page.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h2>\r\n    <div class=\"metaData\">\r\n\r\n    </div>\r\n    <div>\r\n        ");
#nullable restore
#line 8 "C:\Users\Madero\source\repos\LunarSports\Views\Default\Index.cshtml"
   Write(Html.Raw(ViewBag.Page.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </div>\r\n    <div class=\"metaData\">\r\n      <dl>\r\n          <dt>\r\n              Published\r\n          </dt>\r\n          <dd>\r\n              ");
#nullable restore
#line 16 "C:\Users\Madero\source\repos\LunarSports\Views\Default\Index.cshtml"
         Write(ViewBag.Page.DatePublished);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n          </dd>\r\n          <dt>\r\n             Updated\r\n          </dt>\r\n          <dd>\r\n              ");
#nullable restore
#line 22 "C:\Users\Madero\source\repos\LunarSports\Views\Default\Index.cshtml"
         Write(ViewBag.Page.DateModified);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n          </dd>\r\n      </dl>\r\n    </div>\r\n");
#nullable restore
#line 27 "C:\Users\Madero\source\repos\LunarSports\Views\Default\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2> Site is under construction</h2>\r\n    <div class=\"metaData\">\r\n        Please come back later.\r\n        This page is either under maintenance or construction. We are working really hard to be able to deliver the page you requested.\r\n\r\n    </div>\r\n");
#nullable restore
#line 36 "C:\Users\Madero\source\repos\LunarSports\Views\Default\Index.cshtml"
   
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<hr/>\r\n<iframe width=\"560\" height=\"315\" src=\"https://www.youtube.com/embed/t_jYOubJmfM\" frameborder=\"0\" allow=\"accelerometer; autoplay; encrypted-media; gyroscope; picture-in-picture\" allowfullscreen></iframe>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
