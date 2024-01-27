using ProtoBuf;
using VContainer;
using VoxInvasion.Runtime.Services.Entrance;

namespace VoxInvasion.Runtime.Networking.Packets.Entrance.Validation
{
    [ProtoContract]
    public class EmailInvalidPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.EmailInvalid;
    }

    public class EmailInvalidHandler : IPacketHandler
    {
        private ValidationService _validationService;
        public PacketId Id { get; } = PacketId.EmailInvalid;

        public void Execute(IPacket packet, Client client) =>
            _validationService.NotifyInvalidEmail();

        [Inject]
        public void Construct(ValidationService validationService)
        {
            _validationService = validationService;
        }
    }
}