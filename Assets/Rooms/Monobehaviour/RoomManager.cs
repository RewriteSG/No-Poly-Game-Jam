using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public struct RoomOccupant
    {
        Type type;
        object instance;
    }
    public struct Room
    {
        public int Pos_X;
        public int Pos_Y;
        public bool IsNull;
        public RoomData RoomData;
        public int CurrentCapacity;
        public List<RoomOccupant> Occupants;
    }
    public Room[][] Rooms = new Room[0][];
    private int _width;
    private int _height;
    public void InitRooms(int width, int height)
    {
        _height = height;
        _width = width;
        Rooms = new Room[_height][];
        for (int i = 0; i < _height; i++)
        {
            Rooms[i] = new Room[_width];
        }
    }
    public List<Coroutine> coroutines = new List<Coroutine>();
    IEnumerator MoveOccupant(RoomOccupant occupant, int newX, int newY, float duration)
    {
        yield return new WaitForSeconds(duration);
        AddOccupant(occupant, newX, newY);
    }
    public bool IsPositionValid(int x, int y)
    {
        if (x < 0 || y < 0 || Rooms == null || Rooms.Length <= y || Rooms[y].Length <= x) { return false; }
        return true;
    }
    public void AddOccupant(RoomOccupant occupant, int x, int y)
    {
        if (!IsPositionValid(x, y)) { return; }
        Rooms[y][x].Occupants.Add(occupant);
    }
    public Room[] GetNeighbors(int x, int y)
    {
        List<Room> neighbors = new List<Room>();
        for (int i = y - 1; i <= y + 1; i++)
        {
            for (int j = x - 1; j <= x + 1; j++)
            {
                if (i == x || j == y)
                    if (IsPositionValid(i, j))
                    {
                        if (Rooms[i][j].IsNull == false)
                        {
                            neighbors.Add(Rooms[i][j]);
                        }
                    }
            }
        }
        return neighbors.ToArray();
    }
}
