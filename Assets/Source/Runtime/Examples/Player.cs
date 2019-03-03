using System;
using Source.Runtime.Core;
using UnityEngine;

namespace Source.Runtime.Examples
{
    /// <summary>
    /// Example class to demonstrate how <see cref="Source.Runtime.Core.ButtonAttribute"> 
    /// and <see cref="Source.Runtime.Core.RequiredFieldAttribute"> are used
    /// </summary>
    public sealed class Player : MonoBehaviour
    {
        [SerializeField, RequiredField(RequiredFieldType.Mandatory)]
        private Gun _gun = null;

        [SerializeField, RequiredField(RequiredFieldType.Suggestion, "It would be nice to have a second gun!")]
        private Gun _secondaryGun = null;

        [Button]
        public void ResetPlayer()
        {
            transform.localPosition = Vector3.zero;
            transform.localScale = Vector3.one;
            transform.localRotation = Quaternion.identity;

            if (_gun != null){
                _gun.transform.localScale = Vector3.one;
                _gun.transform.localRotation = Quaternion.identity;
            }
            
            if (_secondaryGun != null){
                _secondaryGun.transform.localScale = Vector3.one;
                _secondaryGun.transform.localRotation = Quaternion.identity;
            }
        }

        [Button("Remove Children")]
        private void RemoveChildren()
        {
            var childCount = transform.childCount;

            for(int i = childCount - 1; i >= 0; --i) {
                var child = transform.GetChild(i);

                DestroyImmediate(child.gameObject, true);
            }
        }
    }
}