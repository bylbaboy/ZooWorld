using TMPro;
using UnityEngine;

namespace Tools
{
    /// <summary>
    ///     Allows to modify text component content
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public sealed class TextModificationComponent : MonoBehaviour
    {
        private TMP_Text _text;

        public void UpdateText(string newValue)
        {
            _text.text = newValue;
        }

        private void Start()
        {
            _text = GetComponent<TMP_Text>();
        }
    }
}