namespace Daishi.Armor.WebFramework {
    public abstract class HttpRequestArmorHeaderParser {
        public abstract bool TryParse(out ArmorTokenHeader armorTokenHeader);
    }
}