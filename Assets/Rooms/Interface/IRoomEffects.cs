using UnityEngine;

public interface IRoomEffect
{
    public void OnEntered(object entity);
    public void OnExited(object entity);
    public void OnStay(object entity);
}
