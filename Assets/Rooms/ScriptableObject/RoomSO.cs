using System;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomSO", menuName = "Scriptable Objects/RoomSO")]
public class RoomSO : ScriptableObject
{
    public RoomData RoomData;
    public void EnteredRoom(object entity)
    {
        IterateRoomEffects(effect => effect.OnEntered(entity));
    }
    public void ExitedRoom(object entity)
    {
        IterateRoomEffects(effect => effect.OnExited(entity));
    }
    public void StayInRoom(object entity)
    {
        IterateRoomEffects(effect => effect.OnStay(entity));
    }
    void IterateRoomEffects(Action<RoomEffect> action)
    {
        foreach (RoomEffect effect in RoomData.Effects)
        {
            action(effect);
        }
    }
}
