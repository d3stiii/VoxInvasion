using System;
using System.Text.RegularExpressions;
using VoxInvasion.Runtime.Networking;
using VoxInvasion.Runtime.Networking.Packets.Entrance.Validation;

namespace VoxInvasion.Runtime.Services.Entrance
{
    public class ValidationService
    {
        private readonly Client _client;
        private bool _usernameValidated;
        private bool _emailValidated;
        public event Action ValidEmail;
        public event Action InvalidEmail;
        public event Action OccupiedEmail;
        public event Action ValidUsername;
        public event Action InvalidUsername;
        public event Action OccupiedUsername;
        public bool AllValidated => _usernameValidated && _emailValidated;

        public ValidationService(Client client) =>
            _client = client;

        public void ValidateEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                _emailValidated = false;
                return;
            }

            _client.SendAsync(new CheckEmailPacket { Email = email });
        }

        public void ValidateUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                _usernameValidated = false;
                return;
            }

            var regex = new Regex("^[a-zA-Z0-9]+$");
            if (!regex.IsMatch(username))
            {
                InvalidUsername?.Invoke();
                _usernameValidated = false;
                return;
            }

            _client.SendAsync(new CheckUsernamePacket { Username = username });
        }

        public void NotifyValidEmail()
        {
            _emailValidated = true;
            ValidEmail?.Invoke();
        }

        public void NotifyInvalidEmail()
        {
            _emailValidated = false;
            InvalidEmail?.Invoke();
        }

        public void NotifyOccupiedEmail()
        {
            _emailValidated = false;
            OccupiedEmail?.Invoke();
        }

        public void NotifyOccupiedUsername()
        {
            _usernameValidated = false;
            OccupiedUsername?.Invoke();
        }

        public void NotifyValidUsername()
        {
            _usernameValidated = true;
            ValidUsername?.Invoke();
        }
    }
}