using UnityEngine;
public abstract class RoomEffect : ScriptableObject, IRoomEffect
{
    public string EffectName;
    public abstract void OnEntered(object entity);
    public abstract void OnExited(object entity);
    public abstract void OnStay(object entity);
}