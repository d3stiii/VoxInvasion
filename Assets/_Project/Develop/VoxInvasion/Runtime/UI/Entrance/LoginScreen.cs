using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VoxInvasion.Runtime.Services;
using VoxInvasion.Runtime.Services.UI;

namespace VoxInvasion.Runtime.UI.Entrance
{
    public class LoginScreen : BaseScreen
    {
        [SerializeField] private TMP_InputField _usernameField;
        [SerializeField] private TMP_InputField _passwordField;
        [SerializeField] private Button _loginButton;
        [SerializeField] private Button _registerButton;
        private AuthService _authService;
        private ScreenService _screenService;

        [Inject]
        private void Construct(AuthService authService, ScreenService screenService)
        {
            _screenService = screenService;
            _authService = authService;
        }

        protected override void Initialize()
        {
            _loginButton.onClick.AddListener(Login);
            _registerButton.onClick.AddListener(SwitchToRegistrationScreen);
        }

        private void Login() =>
            _authService.Login(_usernameField.text, _passwordField.text);

        private void SwitchToRegistrationScreen() =>
            _screenService.Show<RegistrationScreen>();
    }
}