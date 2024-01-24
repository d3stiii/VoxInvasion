using System.IO;
using ProtoBuf;

namespace VoxInvasion.Runtime.Networking.Packets
{
    public static class PacketExtensions
    {
        public static byte[] Serialize(this IPacket packet)
        {
            using var stream = new MemoryStream();
            Serializer.Serialize(stream, packet);
            return stream.ToArray();
        }

        public static IPacket Deserialize(this byte[] buffer, long offset, long size)
        {
            using var stream = new MemoryStream(buffer, (int)offset, (int)size);
            return Serializer.Deserialize<IPacket>(stream);
        }
    }
}