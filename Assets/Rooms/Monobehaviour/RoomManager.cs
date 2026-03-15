using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DefaultExecutionOrder(-1)]
public class RoomManager : MonoBehaviour
{
    public static RoomManager instance;
    void OnEnable()
    {
        instance = this;
    }
    public Room[][] Rooms = new Room[0][];
    public List<Coroutine> coroutines = new List<Coroutine>();
    public IEnumerator MoveOccupant(RoomOccupant occupant, int newX, int newY, float duration)
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
