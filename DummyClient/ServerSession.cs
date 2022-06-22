using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ServerCore;

namespace DummyClient
{
	class Packet
	{
		public ushort size;
		public ushort packetId;
	}

	class PlayerInfoReq : Packet
	{
		public long playerId;
	}

	class PlayerInfoOk : Packet
	{
		public int hp;
		public int attack;
	}

	public enum PacketID
	{
		PlayerInfoReq = 1,
		PlayerInfoOk = 2,
	}

	class ServerSession : Session
	{
		public override void OnConnected(EndPoint endPoint)
		{
			Console.WriteLine($"OnConnected : {endPoint}");

			PlayerInfoReq packet = new PlayerInfoReq() { size = 4, packetId = (ushort)PacketID.PlayerInfoReq, playerId = 1001 };


			// 보낸다
			for (int i = 0; i < 5; i++)
			{
				ArraySegment<byte> s = SendBufferHelper.Open(4096);
				//byte[] size = BitConverter.GetBytes(packet.size);
				//byte[] packetId = BitConverter.GetBytes(packet.packetId);
				//byte[] playerId = BitConverter.GetBytes(packet.playerId);

				ushort size = 0;
				bool success = true;

				size += 2;
				success &= BitConverter.TryWriteBytes(new Span<byte>(s.Array, s.Offset + size, s.Count - size), packet.packetId);
				size += 2;
				success &= BitConverter.TryWriteBytes(new Span<byte>(s.Array, s.Offset + size, s.Count - size), packet.playerId);
				size += 8;
				success &= BitConverter.TryWriteBytes(new Span<byte>(s.Array, s.Offset, s.Count), size);

				ArraySegment<byte> sendBuff = SendBufferHelper.Close(size);

				if (success)
					Send(sendBuff);
			}
		}

        public override void OnDisconnected(EndPoint endPoint)
        {
            throw new NotImplementedException();
        }

        public override int OnRecv(ArraySegment<byte> buffer)
        {
            throw new NotImplementedException();
        }

        public override void OnSend(int numOfBytes)
        {
            throw new NotImplementedException();
        }
    }
}