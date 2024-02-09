using UnityEngine;
using UnityEngine.UI;
using VContainer;
using VoxInvasion.Runtime.Entrance.UI.Elements;
using VoxInvasion.Runtime.Utilities.UI;

namespace VoxInvasion.Runtime.Entrance.UI
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
            ResetValidationField(_emailField);
            ResetValidationField(_usernameField);
            ResetValidationField(_passwordField);
            InitializeEmailField();
            InitializeUsernameField();
            InitializePasswordField();
            InitializeButtons();
        }

        protected override void Cleanup()
        {
            CleanupEmailField();
            CleanupUsernameField();
            CleanupPasswordField();
            CleanupButtons();
        }

        private void Register() =>
            _authService.Register(_emailField.InputField.text, _usernameField.InputField.text,
                _passwordField.InputField.text);

        private void SwitchToLoginScreen() =>
            _screenService.Show<LoginScreen>();

        private void InitializeButtons()
        {
            _loginButton.onClick.AddListener(SwitchToLoginScreen);
            _registerButton.onClick.AddListener(Register);
        }

        private void InitializeUsernameField()
        {
            _validationService.OccupiedUsername += ShowUsernameOccupiedError;
            _validationService.ValidUsername += ShowValidUsernameInfo;
            _validationService.InvalidUsername += ShowInvalidEmailInfo;
            _usernameField.InputField.onValueChanged.AddListener(ValidateUsername);
        }

        private void InitializeEmailField()
        {
            _validationService.InvalidEmail += ShowEmailInvalidError;
            _validationService.OccupiedEmail += ShowEmailOccupiedError;
            _validationService.ValidEmail += ShowValidEmailInfo;
            _emailField.InputField.onValueChanged.AddListener(ValidateEmail);
        }

        private void InitializePasswordField()
        {
            _validationService.PasswordTooShort += ShowPasswordTooShortError;
            _validationService.ValidPassword += ShowValidPasswordInfo;
            _passwordField.InputField.onValueChanged.AddListener(ValidatePassword);
        }

        private void CleanupButtons()
        {
            _loginButton.onClick.RemoveListener(SwitchToLoginScreen);
            _registerButton.onClick.RemoveListener(Register);
        }

        private void CleanupPasswordField()
        {
            _validationService.PasswordTooShort -= ShowPasswordTooShortError;
            _validationService.ValidPassword -= ShowValidPasswordInfo;
            _passwordField.InputField.onValueChanged.RemoveListener(ValidatePassword);
        }

        private void CleanupUsernameField()
        {
            _validationService.OccupiedUsername -= ShowUsernameOccupiedError;
            _validationService.ValidUsername -= ShowValidUsernameInfo;
            _usernameField.InputField.onValueChanged.RemoveListener(ValidateUsername);
        }

        private void CleanupEmailField()
        {
            _validationService.InvalidEmail -= ShowEmailInvalidError;
            _validationService.OccupiedEmail -= ShowEmailOccupiedError;
            _validationService.ValidEmail -= ShowValidEmailInfo;
            _emailField.InputField.onValueChanged.RemoveListener(ValidateEmail);
        }

        private void ValidateEmail(string email)
        {
            ResetValidationField(_emailField);
            _validationService.ValidateEmail(email);
            UpdateRegisterButton();
        }

        private void ValidateUsername(string username)
        {
            ResetValidationField(_usernameField);
            _validationService.ValidateUsername(username);
            UpdateRegisterButton();
        }

        private void ValidatePassword(string password)
        {
            ResetValidationField(_passwordField);
            _validationService.ValidatePassword(password);
            UpdateRegisterButton();
        }

        private void UpdateRegisterButton() =>
            _registerButton.interactable = _validationService.AllValidated;

        private void ResetValidationField(ValidationInputField field)
        {
            field.ValidationStatusImage.color = Color.clear;
            field.ValidationInfoText.text = string.Empty;
        }

        private void ShowValidUsernameInfo()
        {
            _usernameField.ValidationStatusImage.color = Color.green;
            UpdateRegisterButton();
        }

        private void ShowValidEmailInfo()
        {
            _emailField.ValidationStatusImage.color = Color.green;
            UpdateRegisterButton();
        }

        private void ShowValidPasswordInfo()
        {
            _passwordField.ValidationStatusImage.color = Color.green;
            UpdateRegisterButton();
        }

        private void ShowValidationError(ValidationInputField field, string reason)
        {
            field.ValidationStatusImage.color = Color.red;
            field.ValidationInfoText.text = reason;
            UpdateRegisterButton();
        }

        private void ShowPasswordTooShortError() =>
            ShowValidationError(_passwordField, "This password is too short");

        private void ShowUsernameOccupiedError() =>
            ShowValidationError(_usernameField, "This username is already registered.");

        private void ShowInvalidEmailInfo() =>
            ShowValidationError(_usernameField, "This username is invalid.");

        private void ShowEmailInvalidError() =>
            ShowValidationError(_emailField, "This email is invalid.");

        private void ShowEmailOccupiedError() =>
            ShowValidationError(_emailField, "This email is already registered.");
    }
}