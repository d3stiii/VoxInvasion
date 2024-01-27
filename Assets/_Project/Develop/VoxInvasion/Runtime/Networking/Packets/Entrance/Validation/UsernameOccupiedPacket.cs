using ProtoBuf;
using VContainer;
using VoxInvasion.Runtime.Services.Entrance;

namespace VoxInvasion.Runtime.Networking.Packets.Entrance.Validation
{
    [ProtoContract]
    public class UsernameOccupiedPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.UsernameOccupied;
    }

    public class UsernameOccupiedHandler : IPacketHandler
    {
        private ValidationService _validationService;
        public PacketId Id { get; } = PacketId.UsernameOccupied;

        public void Execute(IPacket packet, Client client) =>
            _validationService.NotifyOccupiedUsername();

        [Inject]
        public void Construct(ValidationService validationService) =>
            _validationService = validationService;
    }
}