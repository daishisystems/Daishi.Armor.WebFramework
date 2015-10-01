#region Includes

using System.Collections.Specialized;
using System.Linq;

#endregion

namespace Daishi.Armor.WebFramework {
    public class MvcHttpRequestArmorHeaderParser : HttpRequestArmorHeaderParser {
        private readonly NameValueCollection headers;

        public MvcHttpRequestArmorHeaderParser(NameValueCollection headers) {
            this.headers = headers;
        }

        public override bool TryParse(out ArmorTokenHeader armorTokenHeader) {
            armorTokenHeader = new ArmorTokenHeader();

            var authHeaders = headers.GetValues("Authorization");
            if (authHeaders == null) return false;

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