using Source.Runtime.Core;
using System;
using UnityEngine;

namespace Source.Runtime.Examples
{
    [Flags]
    public enum CharacterType : sbyte
    {
        Human = 1,
        Robot = 2,
        Cyborg = 4,
    }

    [CreateAssetMenu(menuName = "Create Super Secret")]
    public class SuperSecret : ScriptableObject
    {
        [SerializeField]
        private string _userName = "xXSuperManxX420NoScope";

        [ReadOnly, SerializeField]
        private string _password = "AllYourPasswordsBelongToUs";

        [EnumFlag, SerializeField]
        private CharacterType _characterType = CharacterType.Human;

        public string UserName => _userName;
        public string Password => _password;
        public CharacterType CharacterType => _characterType;
    }
}