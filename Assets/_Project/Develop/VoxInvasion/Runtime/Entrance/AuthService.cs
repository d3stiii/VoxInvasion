﻿using VoxInvasion.Backend.Connection;
using VoxInvasion.Runtime.Entrance.Login;
using VoxInvasion.Runtime.Entrance.Registration;

namespace VoxInvasion.Runtime.Entrance
{
    public class AuthService
    {
        private readonly Client _client;

        public AuthService(Client client)
        {
            _client = client;
        }

        public void Login(string username, string password) =>
            _client.SendAsync(new LoginRequestPacket { Username = username, Password = password });

        public void Register(string email, string username, string password) =>
            _client.SendAsync(new RegisterRequestPacket { Email = email, Username = username, Password = password });
    }
}