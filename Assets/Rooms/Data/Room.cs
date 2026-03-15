using System.Collections.Generic;
public struct Room
{
    public int Pos_X;
    public int Pos_Y;
    public bool IsNull;
    public RoomData RoomData;
    public int CurrentCapacity;
    public List<RoomOccupant> Occupants;
}