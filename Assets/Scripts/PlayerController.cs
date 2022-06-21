using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    Vector2 rawInput;
    Shooter shooter;

    float xMin;
    float xMax;
    float yMin;
    float yMax;
    float xPadding = 0.5f;
    float yPadding = 0.3f;


    void Awake()
    {
        shooter = GetComponent<Shooter>();
    }
    void Start()
    {
        SetUpMoveBoundaries();
    }

    void OnMove(InputValue value)
    {
        rawInput = value.Get<Vector2>();
        Debug.Log(rawInput);
    }

    void OnFire(InputValue value)
    {
        Debug.Log("OnFire Pressed");
        if (shooter != null)
        {
            Debug.Log("Firing: " + value.isPressed);
            shooter.isFiring = value.isPressed;
        }
    }

    private void SetUpMoveBoundaries()
    {
        var gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + xPadding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - xPadding;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + yPadding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - yPadding;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector3 delta = rawInput;

        //var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var deltaX = delta.x * Time.deltaTime * speed;
        var deltaY = delta.y * Time.deltaTime * speed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);

        transform.position = new Vector2(newXPos, newYPos);
    }
}
