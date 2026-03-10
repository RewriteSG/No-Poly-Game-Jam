using UnityEngine;

[System.Serializable]
public class RoomData
{
    public string Name;
    public string Description;
    public Texture2D Texture;
    public int MaxCapacity;
    public RoomEffect[] Effects = new RoomEffect[0];
}
