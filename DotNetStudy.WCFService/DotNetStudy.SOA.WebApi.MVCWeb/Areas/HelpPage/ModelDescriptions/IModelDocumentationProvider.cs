using System;
using System.Reflection;

namespace DotNetStudy.SOA.WebApi.MVCWeb.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}