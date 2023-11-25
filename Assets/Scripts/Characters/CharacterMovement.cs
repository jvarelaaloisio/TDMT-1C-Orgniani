using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4f;
    [SerializeField] private float maxSpeed = 8f;
    public Vector2 direction;
    public Vector2 lastDirection;

    public Vector2 currentPosition;

    [SerializeField] private CharacterShooting attack;

    [SerializeField] private SpeedHandler speedHandler;

    public SpeedHandler SpeedHandler
    {
        get
        {
            return speedHandler;
        }

        set
        {
            speedHandler = value;
        }
    }

    private void Start()
    {

        lastDirection.Set(-1, 0);
    }


    private void Update()
    {
        if (attack == null)
            Debug.LogError($"{name}: CharacterShooting in CharacterMovement is null.");

        if (attack.canShoot)
        {
            transform.position = transform.position + speed * Time.deltaTime * new Vector3(direction.x, direction.y);
            currentPosition = transform.position;
        }

    }

    public void SetDirection(Vector2 direction)
    {
        if (!enabled) return;

        speed = speedHandler.HandleSpeed(speed, maxSpeed);

        this.direction = direction;

        if(direction != Vector2.zero)
        {
            lastDirection = direction;
        }
    }
}