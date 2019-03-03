using Source.Runtime.Core;
using UnityEngine;

namespace Source.Runtime.Examples
{
    /// <summary>
    /// Example class to demonstrate how <see cref="Source.Runtime.Core.ButtonAttribute"> are used
    /// </summary>
    [CreateAssetMenu(menuName = "Create Player Data")]
    public sealed class PlayerData : ScriptableObject
    {
        [SerializeField, RequiredField(RequiredFieldType.Mandatory)]
        private Player _player = null;

        [Button]
        private void CreatePlayer()
        {
            var existingPlayer = GameObject.FindGameObjectWithTag("Player");

            if (_player != null && existingPlayer == null) {
                var playerInstance = Instantiate(_player);
        
                playerInstance.ResetPlayer();
                playerInstance.name = "Player";
            }
        }
    }
}