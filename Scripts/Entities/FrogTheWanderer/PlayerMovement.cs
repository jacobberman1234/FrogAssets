using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private CharacterController _controller;
    //MOVE TO SEPARATE ANIMATION COMPONENT
    private Animator _anim;

    [Header("Settings")]
    [SerializeField] private float _moveSpeed = 3f;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _anim = GetComponentInChildren<Animator>();
        Helper.LockCursor();
    }

    private void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(x, 0, z);

        _controller.Move(movement * _moveSpeed * Time.deltaTime);

        //DELETE AFTER ANIM TEST
         bool isMoving = z != 0;
        _anim.SetBool("isMoving", isMoving);

    }
}
