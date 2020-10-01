using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Extensions.Localization;
using Olbrasoft.Blog.AspNetCore.Mvc.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;

namespace Olbrasoft.Blog.AspNetCore.Mvc
{
    public class SharedLocalizer : IHtmlLocalizer
    {
        private readonly IHtmlLocalizer _localizer;

        public SharedLocalizer(IHtmlLocalizerFactory factory)
        {
            var type = typeof(Shared);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("Shared", assemblyName.Name);
        }

        public LocalizedHtmlString this[string name] => Text(name);

        public LocalizedHtmlString this[string name, params object[] arguments] => Text(name, arguments);

        public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
        {
            throw new NotImplementedException();
        }

        public LocalizedString GetString(string name)
        {
            return _localizer.GetString(name);
        }

        public LocalizedString GetString(string name, params object[] arguments)
        {
            return _localizer.GetString(name, arguments);
        }

        // if we have formatted string we can provide arguments
        // e.g.: @Localizer.Text("Hello {0}", User.Name)
        public LocalizedHtmlString Text(string key, params object[] arguments)
        {
            return arguments == null
                ? _localizer[key]
                : _localizer[key, arguments];
        }

        public IHtmlLocalizer WithCulture(CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}