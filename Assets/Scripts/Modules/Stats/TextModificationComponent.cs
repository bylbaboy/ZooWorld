using System;
using TMPro;
using UnityEngine;

namespace Modules.Stats
{
    [RequireComponent(typeof(TMP_Text))]
    public sealed class TextModificationComponent : MonoBehaviour
    {
        private TMP_Text _text;
        
        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }

        public void UpdateText(string newValue)
        {
            _text.text = newValue;
        }
    }
}