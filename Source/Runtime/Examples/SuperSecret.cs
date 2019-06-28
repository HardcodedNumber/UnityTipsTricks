using Source.Runtime.Core;
using System;
using System.Collections.Generic;
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

    [Serializable]
    public class HealthPacks
    {
        [SerializeField]
        private string _name;

        [SerializeField]
        private int _amount;

        public string Name => _name;
        public int Amount => _amount;

        public HealthPacks(string name, int amount)
        {
            _name = name;
            _amount = amount;
        }
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

        [SerializeField, ReadOnly]
        private List<HealthPacks> _healthPacks = null;

        public string UserName => _userName;
        public string Password => _password;
        public CharacterType CharacterType => _characterType;
        public List<HealthPacks> HealthPacks => _healthPacks;

        [Button]
        private void CreateHealthPacks()
        {
            _healthPacks = new List<HealthPacks>() {
                 new HealthPacks("Small", 20),
                 new HealthPacks("Medium", 60),
                 new HealthPacks("Large", 80)
            };
        }
    }
}