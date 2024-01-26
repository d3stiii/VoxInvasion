using System;
using VoxInvasion.Runtime.Networking;
using VoxInvasion.Runtime.Networking.Packets.Entrance.Validation;

namespace VoxInvasion.Runtime.Services.Entrance
{
    public class ValidationService
    {
        private readonly Client _client;
        public event Action ValidEmail;
        public event Action InvalidEmail;
        public event Action OccupiedEmail;

        public ValidationService(Client client)
        {
            _client = client;
        }

        public void ValidateEmail(string email)
        {
            _client.SendAsync(new CheckEmailPacket { Email = email });
        }

        public void ValidateUsername(string username)
        {
        }

        public void NotifyValidEmail() => ValidEmail?.Invoke();

        public void NotifyInvalidEmail() => InvalidEmail?.Invoke();

        public void NotifyOccupiedEmail() => OccupiedEmail?.Invoke();
    }
}