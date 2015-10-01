#region Includes

using System;

#endregion

namespace Daishi.Armor.WebFramework {
    public class GenerateSecureArmorToken {
        private readonly ArmorTokenConstructor armorTokenConstructor;
        private readonly SecureArmorTokenBuilder secureArmorTokenBuilder;

        public object Result {
            get { return SecureArmorToken; }
        }
        public string SecureArmorToken { get; private set; }

        public GenerateSecureArmorToken(
            ArmorTokenConstructor armorTokenConstructor,
            SecureArmorTokenBuilder secureArmorTokenBuilder) {
            this.armorTokenConstructor = armorTokenConstructor;
            this.secureArmorTokenBuilder = secureArmorTokenBuilder;
        }

        public void Execute() {
            armorTokenConstructor.Construct(secureArmorTokenBuilder);
            SecureArmorToken = secureArmorTokenBuilder.SecureArmorToken;
        }

        public void Undo() {
            throw new NotImplementedException();
        }
    }
}