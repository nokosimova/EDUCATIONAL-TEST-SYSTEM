#pragma checksum "C:\final\test\Views\Teacher\ChangeQuestion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aebc1ae4a047675168e50ac8290febc8e193541d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Teacher_ChangeQuestion), @"mvc.1.0.view", @"/Views/Teacher/ChangeQuestion.cshtml")]
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
#line 1 "C:\final\test\Views\_ViewImports.cshtml"
using TestSystem;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\final\test\Views\_ViewImports.cshtml"
using TestSystem.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aebc1ae4a047675168e50ac8290febc8e193541d", @"/Views/Teacher/ChangeQuestion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"695bc706f3d1ddd8eec5a67426576255df862a9f", @"/Views/_ViewImports.cshtml")]
    public class Views_Teacher_ChangeQuestion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<TestSystem.Models.QuestionWithAns>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link text-dark"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_8 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Teacher/EditTest"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("<!doctype html>\r\n<html lang=\"en\">\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aebc1ae4a047675168e50ac8290febc8e193541d6928", async() => {
                WriteLiteral("\r\n    <meta charset=\"utf-8\" />\r\n    <meta name=\"viewport\" content=\"width=device-width, initial-scale=1.0\" />\r\n    <title>");
#nullable restore
#line 10 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - TestSystem</title>\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aebc1ae4a047675168e50ac8290febc8e193541d7543", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "aebc1ae4a047675168e50ac8290febc8e193541d8721", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aebc1ae4a047675168e50ac8290febc8e193541d10603", async() => {
                WriteLiteral(@"

    <table style=""width: 1150px;border:0px;"">
        <tr>
            <td colspan=""2"" style=""background-color:#47C607;"">
                <h3 style=""color: white;"">Тесты</h3>
            </td>
        </tr>
        <tr style=""vertical-align: top;"">
            <td style=""background-color:#CCFF83;width:180px;text-align:top;"">
               <h4 class=""nav-item"">
                    ");
#nullable restore
#line 25 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
               Write(Html.ActionLink(linkText: "Главная", actionName: "Index",
                     controllerName: "Teacher",routeValues: new {TeacherId = @Model.test.IdTeacher},
                     htmlAttributes: null));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </h4>\r\n                <h4 >\r\n                     ");
#nullable restore
#line 30 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
                Write(Html.ActionLink(linkText: "Создать тест", actionName: "CreateTest",
                     controllerName: "Teacher",routeValues: new {TeacherId = @Model.test.IdTeacher},
                     htmlAttributes: null));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </h4>\r\n                <h4 class=\"nav-item\">\r\n                    ");
#nullable restore
#line 35 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
               Write(Html.ActionLink(linkText: "Список тестов", actionName: "TestList",
                     controllerName: "Teacher",routeValues: new {TeacherId = @Model.test.IdTeacher},
                     htmlAttributes: null));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                </h4>\r\n                <h5 class=\"nav-item\">\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aebc1ae4a047675168e50ac8290febc8e193541d12731", async() => {
                    WriteLiteral("Выход из системы");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_4.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_5.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_6.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                </h5>\r\n            </td>\r\n            <td style=\"background-color:#FFFFFF;height:800px;text-align:top;\"> \r\n                ");
#nullable restore
#line 44 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
           Write(Html.ValidationSummary(false, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                <h4>Тест: ");
#nullable restore
#line 45 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
                     Write(Model.test.TestName);

#line default
#line hidden
#nullable disable
                WriteLiteral(" <br /> Новый вопрос: </h4>\r\n                <br></br>\r\n                 ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aebc1ae4a047675168e50ac8290febc8e193541d15192", async() => {
                    WriteLiteral("\r\n                        <table>\r\n                            <tr>\r\n                                <td>Текст вопроса:</td>\r\n                                <td><textarea name=\"QText\" rows=\"5\" cols=\"50\"  required>");
#nullable restore
#line 51 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
                                                                                   Write(Model.question.QuestionText);

#line default
#line hidden
#nullable disable
                    WriteLiteral("</textarea>\r\n                            </tr>\r\n                            <tr>\r\n                                <td>Балл (от 1 до 5 баллов):\r\n                                <input type=\"number\" name=\"Point\"");
                    BeginWriteAttribute("value", " value=\"", 2588, "\"", 2617, 1);
#nullable restore
#line 55 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
WriteAttributeValue("", 2596, Model.question.Point, 2596, 21, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(@" required pattern=""[0-9]"" /> </td>
                            </tr>
                            <tr>
                                <td style=""color: green;""> Верный ответ:
                                <input type=""text"" name=""CorrAns"" aria-colcount=""50""");
                    BeginWriteAttribute("value", " value=\"", 2881, "\"", 2914, 1);
#nullable restore
#line 59 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
WriteAttributeValue("", 2889, Model.corrAns.AnswerText, 2889, 25, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" required /> </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td style=\"color: red;\">Неверный ответ 1:\r\n                                <input type=\"text\" name=\"WrgAns1\" aria-colcount=\"50\"");
                    BeginWriteAttribute("value", " value=\"", 3163, "\"", 3196, 1);
#nullable restore
#line 63 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
WriteAttributeValue("", 3171, Model.wrgAns1.AnswerText, 3171, 25, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" required /> </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td style=\"color: red;\">Неверный ответ 2:\r\n                                <input type=\"text\" name=\"WrgAns2\" aria-colcount=\"50\"");
                    BeginWriteAttribute("value", " value=\"", 3445, "\"", 3478, 1);
#nullable restore
#line 67 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
WriteAttributeValue("", 3453, Model.wrgAns2.AnswerText, 3453, 25, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" required /> </td>\r\n                            </tr>\r\n                            <tr>\r\n                                <td style=\"color: red;\">Неверный ответ 3:\r\n                                <input type=\"text\" name=\"WrgAns3\" aria-colcount=\"50\"");
                    BeginWriteAttribute("value", "value=\"", 3727, "\"", 3759, 1);
#nullable restore
#line 71 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
WriteAttributeValue("", 3734, Model.wrgAns3.AnswerText, 3734, 25, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" required /> </td>\r\n                            </tr>\r\n                        </table>   \r\n                        <input type=\"hidden\" name=\"QuestionId\"");
                    BeginWriteAttribute("value", " value=\"", 3914, "\"", 3948, 1);
#nullable restore
#line 74 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
WriteAttributeValue("", 3922, Model.question.QuestionId, 3922, 26, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"id1\"");
                    BeginWriteAttribute("value", " value=\"", 4009, "\"", 4040, 1);
#nullable restore
#line 75 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
WriteAttributeValue("", 4017, Model.wrgAns1.AnswerId, 4017, 23, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"id2\"");
                    BeginWriteAttribute("value", " value=\"", 4101, "\"", 4132, 1);
#nullable restore
#line 76 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
WriteAttributeValue("", 4109, Model.wrgAns2.AnswerId, 4109, 23, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" />\r\n                        <input type=\"hidden\" name=\"id3\"");
                    BeginWriteAttribute("value", " value=\"", 4193, "\"", 4224, 1);
#nullable restore
#line 77 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
WriteAttributeValue("", 4201, Model.wrgAns3.AnswerId, 4201, 23, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" /> \r\n                    <br><br>\r\n                    <table>\r\n                    <input type=\"submit\" value=\"Сохранить изменения\">\r\n                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_7.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_7);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n                    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aebc1ae4a047675168e50ac8290febc8e193541d22381", async() => {
                    WriteLiteral("\r\n                      <input type=\"hidden\" name=\"TestId\"");
                    BeginWriteAttribute("value", " value=\"", 4498, "\"", 4524, 1);
#nullable restore
#line 83 "C:\final\test\Views\Teacher\ChangeQuestion.cshtml"
WriteAttributeValue("", 4506, Model.test.TestId, 4506, 18, false);

#line default
#line hidden
#nullable disable
                    EndWriteAttribute();
                    WriteLiteral(" /> \r\n                      <input type=\"submit\" value=\"Назад\">\r\n                    ");
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_8);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("  \r\n                    </table>\r\n            </td>\r\n        </tr>\r\n        <tr></tr>\r\n    </table>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html> ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TestSystem.Models.QuestionWithAns> Html { get; private set; }
    }
}
#pragma warning restore 1591
