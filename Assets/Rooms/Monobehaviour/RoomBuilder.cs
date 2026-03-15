using System.Collections.Generic;
using UnityEngine;

public class RoomBuilder : MonoBehaviour
{
    public RoomsBuildRegistry RoomsBuildRegistry;
    void OnEnable()
    {
        RoomManager rm = RoomManager.instance;
        rm.Rooms = GenerateRooms();
    }
    Room[][] GenerateRooms()
    {
        Room[][] Rooms = new Room[RoomsBuildRegistry.Height][];
        for (int y = 0; y < RoomsBuildRegistry.Height; y++)
        {
            Rooms[y] = new Room[RoomsBuildRegistry.Width];
            for (int x = 0; x < RoomsBuildRegistry.Width; x++)
            {
                RoomSO roomData = RoomsBuildRegistry.GetRandomRoom();
                Rooms[y][x] = new Room
                {
                    Pos_X = x,
                    Pos_Y = y,
                    IsNull = roomData == null,
                    RoomData = roomData == null ? null : roomData.RoomData,
                    CurrentCapacity = 0,
                    Occupants = new List<RoomOccupant>(),
                };
            }
        }
        return Rooms;
    }
}