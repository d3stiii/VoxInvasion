using ProtoBuf;
using VContainer;
using VoxInvasion.Runtime.Services.Entrance;

namespace VoxInvasion.Runtime.Networking.Packets.Entrance.Validation
{
    [ProtoContract]
    public class UsernameValidPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.UsernameValid;
    }

    public class UsernameValidHandler : IPacketHandler
    {
        private ValidationService _validationService;
        public PacketId Id { get; } = PacketId.UsernameValid;

        public void Execute(IPacket packet, Client client) =>
            _validationService.NotifyValidUsername();

        [Inject]
        public void Construct(ValidationService validationService) =>
            _validationService = validationService;
    }
}