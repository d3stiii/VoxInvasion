using ProtoBuf;
using VContainer;
using VoxInvasion.Backend.Connection;
using VoxInvasion.Backend.ServerCommunication;

namespace VoxInvasion.Runtime.Entrance.Validation
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