namespace VoxInvasion.Backend.ServerCommunication
{
    public enum PacketId
    {
        Welcome,
        Ping,
        LoginRequest,
        RegisterRequest,
        RegistrationFailed,
        LoginSuccess,
        LoginFailed,
        Pong,
        PingResult,
        CheckEmail,
        EmailInvalid,
        EmailValid,
        EmailOccupied,
        CheckUsername,
        UsernameOccupied,
        UsernameValid
    }
}