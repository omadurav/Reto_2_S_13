using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody _rbPlayer;

    private float _rotationSpeed = 180f;
    private Animator _animator;


    private void Start()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rbPlayer = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 movementInput = _playerInput.actions["Move"].ReadValue<Vector2>();
        float moveH = movementInput.x * _rotationSpeed;
        float moveV = movementInput.y;

        //Movimiento y rotacion del player
        MovePlayer(moveV);
        Vector3 rotation = Vector3.up * moveH;
        Quaternion angleRot = Quaternion.Euler(rotation * Time.fixedDeltaTime);
        _rbPlayer.MoveRotation(_rbPlayer.rotation * angleRot);
    }

    private void MovePlayer(float moveVertical)
    {
        float _moveSpeed = 8.0f;

        if (moveVertical > 0)
        {
            _rbPlayer.MovePosition(this.transform.position + this.transform.forward * moveVertical * _moveSpeed * Time.fixedDeltaTime);
            _animator.SetBool("isWalking", true);

        }
        else if (moveVertical < 0)
        {
            _moveSpeed = 2.6f;
            _rbPlayer.MovePosition(this.transform.position + this.transform.forward * moveVertical * _moveSpeed * Time.fixedDeltaTime);
            _animator.SetBool("isWalkingBack", true);
        }
        else
        {
            _animator.SetBool("isWalking", false);
            _animator.SetBool("isWalkingBack", false);
        }
    }
}
