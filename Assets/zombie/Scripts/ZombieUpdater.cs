using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.GraphicsBuffer;

public class ZombieUpdater : MonoBehaviour
{
    [SerializeField] private Zombie _zombie;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private TMP_Text _text;
    public Zombie Zombie => _zombie;

    public Vector3 TargetPosition { get; private set; }

    public void SetZombie(Zombie zombie)
    {
        _zombie = zombie;
    }

    public void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Start()
    {
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
        if (_zombie == null)
            return;

        Vector3 dist = TargetPosition - transform.position;

        TargetPosition = new Vector3(10f, 10f, 0f);

        if (Mathf.Abs(dist.magnitude) > 0.1f)
        {
            Vector3 velocity = dist.normalized * _zombie._speed;

            transform.position = Vector3.SmoothDamp(
                transform.position,
                TargetPosition,
                ref velocity,
                _zombie._speed / 0.5f
            );

            if (Mathf.Abs(velocity.magnitude) < 0.1f)
            {
                velocity = Vector3.zero;
            }

            _rb.AddForce(velocity, ForceMode2D.Force);

        }

        if (_text != null)
        {
            _text.text = "Dist : " + dist.ToString() + "\n"
                + "Speed : " + _zombie._speed.ToString() + "\n";
        }
    }
}
