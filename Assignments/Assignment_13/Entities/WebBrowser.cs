using Assignment_13.Enums;

namespace Assignment_13.Entities
{
    public class WebBrowser
    {
        public BrowserName Name { get; set; }
        public int MajorVersion { get; set; }

        public WebBrowser(string name, int majorVersion)
        {
            Name = TranslateStringToBrowserName(name);
            MajorVersion = majorVersion;
        }

        public static BrowserName TranslateStringToBrowserName(string name)
        {
            foreach (var mapping in BrowserMappings)
            {
                if (name.Contains(mapping.Key, StringComparison.OrdinalIgnoreCase))
                    return mapping.Value;
            }

            return BrowserName.Unknown;
        }

        private static readonly Dictionary<string, BrowserName> BrowserMappings = new(StringComparer.OrdinalIgnoreCase)
        {
            { "Internet Explorer", BrowserName.InternetExplorer },
            { "Firefox", BrowserName.Firefox },
            { "Chrome", BrowserName.Chrome },
            { "Opera", BrowserName.Opera },
            { "Safari", BrowserName.Safari },
            { "Dolphin", BrowserName.Dolphin },
            { "Konqueror", BrowserName.Konqueror },
            { "Linx", BrowserName.Linx }
        };
    }
}

