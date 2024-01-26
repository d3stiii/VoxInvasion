using ProtoBuf;
using VContainer;
using VoxInvasion.Runtime.Services.Entrance;

namespace VoxInvasion.Runtime.Networking.Packets.Entrance.Validation
{
    [ProtoContract]
    public class EmailOccupiedPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.EmailOccupied;
    }

    public class EmailOccupiedHandler : IPacketHandler
    {
        private ValidationService _validationService;
        public PacketId Id { get; } = PacketId.EmailOccupied;

        public void Execute(IPacket packet, Client client) =>
            _validationService.NotifyOccupiedEmail();

        [Inject]
        public void Construct(ValidationService validationService) =>
            _validationService = validationService;
    }
}