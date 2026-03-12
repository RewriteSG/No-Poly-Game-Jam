using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class ZombieUpdater : MonoBehaviour
{
    [SerializeField] private Zombie _zombie;
    [SerializeField] private Rigidbody2D _rb;

    private Draggable _draggable;

    //seperate later
    [SerializeField] private TMP_Text _text;

    public void SetZombie(Zombie zombie)
    {
        _zombie = zombie;
    }

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();

        _draggable = new Draggable();
    }

    public void Start()
    {
        _draggable.Init(1f);

        this.name = _zombie.ZombieDataSO.Type.ToString() + " zombie ";

        if (_zombie.ZombieDataSO.Traits.Count > 0)
        {
            this.name += " with ";
            foreach (ZombieTraitData trait in _zombie.ZombieDataSO.Traits)
            {
                this.name += trait.Name + " | ";
            }
        }

        _zombie.Start();
    }

    private void Update()
    {
        _draggable.Dragging(transform);

        if (_zombie == null)
            return;

        if (!_zombie.isAlive || !_zombie.isActive)
            return;

        if (_draggable.isDragged)
        {
            _zombie.SetTargetPosition(transform.position);
        }

        if(InputManager.Instance.IsMoveDown)
        {
            _zombie.SetTargetPosition(InputManager.Instance.PointerPos);
        }

        Vector3 dist = _zombie.TargetPosition - transform.position;

        if (Mathf.Abs(dist.magnitude) > 0.1f)
        {
            Vector3 velocity = dist.normalized * _zombie._speed;

            transform.position = Vector3.SmoothDamp(
                transform.position,
                _zombie.TargetPosition,
                ref velocity,
                _zombie._speed / 0.5f
            );

            if (Mathf.Abs(velocity.magnitude) < 0.1f)
            {
                velocity = Vector3.zero;
            }

            _rb.AddForce(velocity, ForceMode2D.Force);

        }

        //put below in seperate Zombie UI script
        if (InputManager.Instance.IsSelectDown)
        {
            _text.text = "";
            if (_text != null)
            {
                foreach (ZombieTraitData trait in _zombie.ZombieDataSO.Traits)
                {
                    _text.text += trait.Name;
                }
            }
        }
    }
}
