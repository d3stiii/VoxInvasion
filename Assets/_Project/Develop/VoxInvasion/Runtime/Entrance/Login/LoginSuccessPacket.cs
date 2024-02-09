using ProtoBuf;
using VContainer;
using VoxInvasion.Backend.Connection;
using VoxInvasion.Backend.ServerCommunication;
using VoxInvasion.Runtime.Utilities;

namespace VoxInvasion.Runtime.Entrance.Login
{
    [ProtoContract]
    public class LoginSuccessPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.LoginSuccess;
    }

    public class LoginSuccessHandler : IPacketHandler
    {
        private SceneLoader _sceneLoader;
        public PacketId Id { get; } = PacketId.LoginSuccess;

        public void Execute(IPacket packet, Client client)
        {
            _sceneLoader.Load("SampleScene");
        }

        [Inject]
        public void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }
    }
}