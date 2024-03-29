﻿using ProtoBuf;
using UnityEngine;
using VoxInvasion.Backend.Connection;
using VoxInvasion.Backend.ServerCommunication;

namespace VoxInvasion.Runtime.Battle.Ping
{
    [ProtoContract]
    public class PingResultPacket : IPacket
    {
        [ProtoMember(1)] public PacketId Id { get; } = PacketId.PingResult;
        [ProtoMember(2)] public int Ping { get; set; }
    }

    public class PingResultHandler : IPacketHandler
    {
        public PacketId Id { get; } = PacketId.PingResult;
        public void Execute(IPacket packet, Client client)
        {
            var resultPacket = (PingResultPacket)packet;
            Debug.Log($"Network latency: {resultPacket.Ping} ms");
        }
    }
}