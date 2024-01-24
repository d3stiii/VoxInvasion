using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace VoxInvasion.Runtime.UI.Entrance
{
    public class LoginScreen : BaseScreen
    {
        [SerializeField] private TMP_InputField _usernameField;
        [SerializeField] private TMP_InputField _passwordField;
        [SerializeField] private Button _loginButton;
        [SerializeField] private Button _registerButton;

        protected override void Initialize()
        {
            
        }
    }
}