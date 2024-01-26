using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VoxInvasion.Runtime.Services.Entrance;
using VoxInvasion.Runtime.Services.UI;
using VoxInvasion.Runtime.UI.Entrance.Elements;

namespace VoxInvasion.Runtime.UI.Entrance
{
    public class RegistrationScreen : BaseScreen
    {
        [SerializeField] private ValidationInputField _emailField;
        [SerializeField] private ValidationInputField _usernameField;
        [SerializeField] private ValidationInputField _passwordField;
        [SerializeField] private Button _registerButton;
        [SerializeField] private Button _loginButton;
        private ScreenService _screenService;
        private AuthService _authService;
        private ValidationService _validationService;
        private bool _usernameValidated;
        private bool _emailValidated;

        [Inject]
        private void Construct(AuthService authService, ScreenService screenService,
            ValidationService validationService)
        {
            _validationService = validationService;
            _screenService = screenService;
            _authService = authService;
        }

        protected override void Initialize()
        {
            _emailField.ValidationStatusImage.color = Color.clear;
            _validationService.InvalidEmail += ShowEmailInvalidError;
            _validationService.OccupiedEmail += ShowEmailOccupiedError;
            _validationService.ValidEmail += ShowValidEmailInfo;
            _emailField.InputField.onValueChanged.AddListener(ValidateEmail);
            _loginButton.onClick.AddListener(SwitchToLoginScreen);
            _registerButton.onClick.AddListener(Register);
        }

        protected override void Cleanup()
        {
            _validationService.InvalidEmail -= ShowEmailInvalidError;
            _validationService.OccupiedEmail -= ShowEmailOccupiedError;
            _validationService.ValidEmail -= ShowValidEmailInfo;
            _loginButton.onClick.RemoveListener(SwitchToLoginScreen);
            _registerButton.onClick.RemoveListener(Register);
            _emailField.InputField.onValueChanged.RemoveListener(ValidateEmail);
        }

        private void ValidateEmail(string email)
        {
            ResetEmailValidation();
            UpdateRegisterButton();

            if (!string.IsNullOrEmpty(email))
            {
                _validationService.ValidateEmail(email);
            }
        }

        private void Register() =>
            _authService.Register(_emailField.InputField.text, _usernameField.InputField.text,
                _passwordField.InputField.text);

        private void SwitchToLoginScreen() =>
            _screenService.Show<LoginScreen>();

        private void ShowEmailValidationError(string reason)
        {
            _emailField.ValidationStatusImage.color = Color.red;
            _emailField.ValidationInfoText.text = reason;
            _emailValidated = false;
            UpdateRegisterButton();
        }

        private void ShowEmailInvalidError() =>
            ShowEmailValidationError("This email is invalid.");

        private void ShowEmailOccupiedError() =>
            ShowEmailValidationError("This email is already registered.");

        private void ShowValidEmailInfo()
        {
            _emailField.ValidationStatusImage.color = Color.green;
            _emailValidated = true;
            UpdateRegisterButton();
        }

        private void ResetEmailValidation()
        {
            _emailField.ValidationStatusImage.color = Color.clear;
            _emailField.ValidationInfoText.text = string.Empty;
            _emailValidated = false;
        }

        private void UpdateRegisterButton() =>
            _registerButton.interactable = _emailValidated;
    }
}