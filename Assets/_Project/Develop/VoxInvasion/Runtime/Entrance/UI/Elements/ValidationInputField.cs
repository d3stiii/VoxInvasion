using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VoxInvasion.Runtime.Entrance.UI.Elements
{
    public class ValidationInputField : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _inputField;
        [SerializeField] private Image _validationStatusImage;
        [SerializeField] private TMP_Text _validationInfoText;

        public TMP_InputField InputField => _inputField;
        public Image ValidationStatusImage => _validationStatusImage;

        public TMP_Text ValidationInfoText => _validationInfoText;
    }
}