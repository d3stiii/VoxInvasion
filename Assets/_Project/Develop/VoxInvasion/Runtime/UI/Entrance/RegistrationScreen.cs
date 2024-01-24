using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VoxInvasion.Runtime.UI.Entrance
{
    public class RegistrationScreen : BaseScreen
    {
        [SerializeField] private TMP_InputField _emailField;
        [SerializeField] private TMP_InputField _usernameField;
        [SerializeField] private TMP_InputField _passwordField;
        [SerializeField] private Button _registerButton;
        [SerializeField] private Button _loginButton;

        protected override void Initialize()
        {
            
        }
    }
}