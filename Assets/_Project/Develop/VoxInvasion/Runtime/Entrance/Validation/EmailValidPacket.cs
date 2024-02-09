using ProtoBuf;
using VContainer;
using VoxInvasion.Backend.Connection;
using VoxInvasion.Backend.ServerCommunication;

namespace VoxInvasion.Runtime.Entrance.Validation
{
    [ProtoContract]
    public class EmailValidPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.EmailValid;
    }

    public class EmailValidHandler : IPacketHandler
    {
        private ValidationService _validationService;
        public PacketId Id { get; } = PacketId.EmailValid;

        public void Execute(IPacket packet, Client client) =>
            _validationService.NotifyValidEmail();

        [Inject]
        public void Construct(ValidationService validationService) =>
            _validationService = validationService;
    }
}