
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _speedRotation;
    [SerializeField] Joystick _joystick;
    Rigidbody2D _rb;
    Quaternion _rotation;
    Vector3 _moveVector;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (GameManager.Single.GameActive)
        {
            transform.Translate(_speed * Time.deltaTime * Vector2.up);
            if (_joystick.Horizontal != 0 || _joystick.Vertical != 0)
            {
                _moveVector = (Vector3.up * _joystick.Vertical + Vector3.right * _joystick.Horizontal);
                _rotation = Quaternion.LookRotation(Vector3.forward, _moveVector);
                transform.rotation = Quaternion.Lerp(transform.rotation, _rotation, _speedRotation * Time.deltaTime);
            }
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.x > GameManager.Single.RightUpperCorner.x + 0.5f)
        {
            transform.position = new Vector3(-GameManager.Single.RightUpperCorner.x, transform.position.y, 0);
            return;
        }

        if (transform.position.x < -GameManager.Single.RightUpperCorner.x - 0.5f)
        {
            transform.position = new Vector3(GameManager.Single.RightUpperCorner.x, transform.position.y, 0);
            return;
        }
        if (transform.position.y > GameManager.Single.RightUpperCorner.y + 0.5f)
        {
            transform.position = new Vector3(transform.position.x, -GameManager.Single.RightUpperCorner.y, 0);
            return;
        }
        if (transform.position.y < -GameManager.Single.RightUpperCorner.y - 0.5f)
        {
            transform.position = new Vector3(transform.position.x, GameManager.Single.RightUpperCorner.y, 0);
            return;
        }
    }
}
