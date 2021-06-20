using System.Linq;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;
    public Transform cam;

    [SerializeField] private float speed = 6f;
    [SerializeField] private float turnSmoothTime = 0.1f;
    private float turnSmoothVelolicty;

    public float gravity;
    public float currentGravity;
    public float constantGravity = -9.81f;
    public float maxGravity;
    Vector3 gravityDirection;
    Vector3 gravityMovement;

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        gravityDirection = Vector3.down;
    }

    void FixedUpdate()
    {
        CalculateGravity();
        float _horizontal = Input.GetAxisRaw("Horizontal");
        float _vertical = Input.GetAxisRaw("Vertical");
        Vector3 _direction = new Vector3(_horizontal, 0f, _vertical).normalized;

        if (_direction.magnitude >= 0.1f)
        {
            float _targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float _angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetAngle, ref turnSmoothVelolicty, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, _angle, 0f);

            Vector3 _moveDir = Quaternion.Euler(0f, _targetAngle, 0f) * Vector3.forward;
            characterController.Move((_moveDir.normalized * speed * Time.deltaTime) + gravityMovement);
        }
    }

    public void CalculateGravity()
    {
        if (IsGrounded())
        {
            currentGravity = constantGravity;
        }
        else
        {
            if(currentGravity > maxGravity)
            {
                currentGravity -= gravity * Time.deltaTime;
            }
        }

        gravityMovement = gravityDirection * -currentGravity * Time.deltaTime;
    }

    public bool IsGrounded()
    {
        return characterController.isGrounded;
    }

}
