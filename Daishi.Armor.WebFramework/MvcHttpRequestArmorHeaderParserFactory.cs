#region Includes

using System.Collections.Specialized;

#endregion

namespace Daishi.Armor.WebFramework {
    public class MvcHttpRequestArmorHeaderParserFactory :
        HttpRequestArmorHeaderParserFactory {
        private readonly NameValueCollection headers;

        public MvcHttpRequestArmorHeaderParserFactory(
            NameValueCollection headers) {
            this.headers = headers;
        }

        public override HttpRequestArmorHeaderParser Create() {
            return new MvcHttpRequestArmorHeaderParser(headers);
        }
    }
}