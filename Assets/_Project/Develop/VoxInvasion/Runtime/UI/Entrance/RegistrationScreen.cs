using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VoxInvasion.Runtime.Services;
using VoxInvasion.Runtime.Services.UI;

namespace VoxInvasion.Runtime.UI.Entrance
{
    public class RegistrationScreen : BaseScreen
    {
        [SerializeField] private TMP_InputField _emailField;
        [SerializeField] private TMP_InputField _usernameField;
        [SerializeField] private TMP_InputField _passwordField;
        [SerializeField] private Button _registerButton;
        [SerializeField] private Button _loginButton;
        private ScreenService _screenService;
        private AuthService _authService;

        [Inject]
        private void Construct(AuthService authService, ScreenService screenService)
        {
            _screenService = screenService;
            _authService = authService;
        }

        protected override void Initialize()
        {
            _loginButton.onClick.AddListener(SwitchToLoginScreen);
            _registerButton.onClick.AddListener(Register);
        }

        private void Register() =>
            _authService.Register(_emailField.text, _usernameField.text, _passwordField.text);

        private void SwitchToLoginScreen() =>
            _screenService.Show<LoginScreen>();
    }
}