using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float _jumpPower;
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    private bool _isGrounded;
    private Vector2 _moveDirection;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _isGrounded = true;
        _moveDirection = Vector2.zero;
    }

    private void FixedUpdate()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    public void Move(float input)
    {
        if (input == 0)
        {
            _moveDirection.x = 0;
        }
        else
        {
            _moveDirection.x = input > 0 ? 1 : -1;
        }
    }

    public void Jump()
    {
        if(_isGrounded)
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);

            _isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        _isGrounded = true;
    }
}
