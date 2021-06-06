using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    private CharacterAnimation _animation;
    private Transform _camera;

    [Header("Settings")]
    [SerializeField] private float _turnSmoothTime = 0.1f;
    //Set within the transformation container
    [HideInInspector] public float moveSpeed;

    [Header("Gravity Settings")]
    [SerializeField] private float _gravity = -9f;

    private Vector3 _velocity;

    [Header("Jump References")]
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    [Header("Jump Settings")]
    [SerializeField] private float _groundCheckRadius = 0.1f;
    //Set within the transformation container
    [HideInInspector]public float jumpHeight = 3f;

    private float _turnSmoothVelocity;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _animation = GetComponent<CharacterAnimation>();
        _camera = Camera.main.transform;
        Helper.LockCursor();
    }

    private void Update()
    {
        CheckForJump();
        DetectMovement();
        ApplyGravity();
    }

    private void DetectMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            //Movement
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + _camera.eulerAngles.y;
            float smoothAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,
                ref _turnSmoothVelocity, _turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, smoothAngle, 0);
            Vector3 moveDirection = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            _controller.Move(moveDirection.normalized * moveSpeed * Time.deltaTime);
        }
        //Add animation
        _animation.AnimateMovement(horizontal, vertical);
    }

    private void CheckForJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (IsGrounded())
            {
                _velocity.y = Mathf.Sqrt(jumpHeight * -2 * _gravity);
            }
        }
    }

    private bool IsGrounded()
    {
        if (Physics.CheckSphere(_groundCheck.position, _groundCheckRadius, _groundLayer))
            return true;
        else
            return false;
    }

    private void ApplyGravity()
    {
        if(IsGrounded() && _velocity.y < -2f)
        {
            _velocity.y = -2f;
        }

        _velocity.y += _gravity * Time.deltaTime;
        _controller.Move(_velocity * Time.deltaTime);
    }
}
