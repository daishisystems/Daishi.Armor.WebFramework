#region Includes

using System.Net.Http.Headers;

#endregion

namespace Daishi.Armor.WebFramework {
    public class WebApiHttpRequestArmorHeaderParserFactory :
        HttpRequestArmorHeaderParserFactory {
        private readonly HttpRequestHeaders headers;

        public WebApiHttpRequestArmorHeaderParserFactory(
            HttpRequestHeaders headers) {
            this.headers = headers;
        }

        public override HttpRequestArmorHeaderParser Create() {
            return new WebApiHttpRequestArmorHeaderParser(headers);
        }
    }
}