using UnityEngine;

public class Draggable
{
    public bool isDragged;
    public float SelectionRadius;

    public bool canDrag;

    public void Init(float radius)
    {
        isDragged = false;

        SelectionRadius = radius;        

        canDrag = true;
    }

    public void Dragging(Transform transform)
    {
        if (!canDrag)
            return;

        bool inRange = (InputManager.Instance.PointerPos - (Vector2)transform.position).magnitude < SelectionRadius;

        if (inRange)
        {
            if (InputManager.Instance.WasSelectPressed)
            {
                isDragged = true;
            }

            if (InputManager.Instance.WasSelectReleased)
            {
                isDragged = false;
            }


        }
        else
        {
            if (isDragged && InputManager.Instance.IsSelectDown)
            {
                isDragged = true;
            }
            else
            {
                isDragged = false;
            }
        }

        if (isDragged)
        {
            transform.position = InputManager.Instance.PointerPos;
        }
    }   
}
