using System.Text.RegularExpressions;

namespace netCoreApi.Extensions
{
    public class KebabCasePluralParameterTransformer : IOutboundParameterTransformer
    {
        public string? TransformOutbound(object? value)
        {
            if (value == null) return null;
            var kebab = Regex.Replace(value.ToString(), "([a-z])([A-Z])", "$1-$2").ToLower();
            kebab = kebab.Replace("-controller", "");
            if (!kebab.EndsWith("s"))
                kebab += "s";

            return kebab;
        }
    }
}
