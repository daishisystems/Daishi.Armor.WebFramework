#region Includes

using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

#endregion

namespace Daishi.Armor.WebFramework {
    public class WebApiHttpRequestArmorHeaderParser :
        HttpRequestArmorHeaderParser {
        private readonly HttpRequestHeaders headers;

        public WebApiHttpRequestArmorHeaderParser(HttpRequestHeaders headers) {
            this.headers = headers;
        }

        public override bool TryParse(out ArmorTokenHeader armorTokenHeader) {
            armorTokenHeader = new ArmorTokenHeader();
            IEnumerable<string> authHeaders;

            var hasAuthHeader = headers.TryGetValues("Authorization",
                out authHeaders);
            if (!hasAuthHeader) return false;

            var armorHeader =
                authHeaders.SingleOrDefault(header => header.StartsWith("ARMOR"));
            if (armorHeader == null) return false;

            armorTokenHeader.IsValid = true;
            armorTokenHeader.ArmorToken = armorHeader.Replace("ARMOR ",
                string.Empty);

            return true;
        }
    }
}