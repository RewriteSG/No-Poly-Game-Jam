using UnityEngine;

public class RoomsBuildRegistry : ScriptableObject
{
    public RoomBuildData[] Rooms = new RoomBuildData[0];
    float _totalWeight;
    public struct BuildData
    {
        public RoomSO Room;
        public float Weight;
    }
    BuildData[] _buildDatas = new BuildData[0];
    void OnEnable()
    {
        _totalWeight = 0f;
        _buildDatas = new BuildData[Rooms.Length];
        int index = 0;
        foreach (RoomBuildData buildData in Rooms)
        {
            _totalWeight += buildData.Weight;
            _buildDatas[index] = new BuildData()
            {
                Room = buildData.Room,
                Weight = _totalWeight
            };
            index++;
        }
    }
    public RoomSO GetRandomRoom()
    {
        float random = Random.Range(0f, _totalWeight);
        foreach (BuildData buildData in _buildDatas)
        {
            if (random < buildData.Weight)
            {
                return buildData.Room;
            }
        }
        return null;
    }
}