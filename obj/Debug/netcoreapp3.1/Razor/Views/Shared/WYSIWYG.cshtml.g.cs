#pragma checksum "C:\Users\Madero\source\repos\LunarSports\Views\Shared\WYSIWYG.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "659ae6131b7c790b3dee622b7eb77e34c5e7df7b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(LunarSports.Shared.Views_Shared_WYSIWYG), @"mvc.1.0.view", @"/Views/Shared/WYSIWYG.cshtml")]
namespace LunarSports.Shared
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"659ae6131b7c790b3dee622b7eb77e34c5e7df7b", @"/Views/Shared/WYSIWYG.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c11e871220730c15051a83fcf7c04d017db1389", @"/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9c11e871220730c15051a83fcf7c04d017db1389", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_WYSIWYG : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<script src=""https://cdn.ckeditor.com/ckeditor5/17.0.0/classic/ckeditor.js""></script>

<script>
    var editorInstance = ClassicEditor
        .create(document.querySelector('#Description'))
        .catch(error => {
            console.error(error);
        });
    editorInstance.config.height = '75%';
</script>

<style>
    .ck-editor__editable_inline {
        min-height: 400px;
    }
</style>
");
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
