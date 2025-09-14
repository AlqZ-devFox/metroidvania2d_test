using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    /*
     * TODO:
     *  - Player able to move left and right
     *  - Player able to jump
     *  - Player rotates accordingly to wherever they're looking
     */
    
    #region Global Attributes
    [SerializeField] [Range(0.1f, 100)] private float jumpForce;
    [SerializeField] [Range(0.1f, 100)] private float walkSpeed;
    
    [SerializeField] [Range(-100, 0)] private float gravity = -9.8f;
    [SerializeField] [Range(0.1f, 1)] private float airborneDrag = 1;
    //public float speedBoostSpeed; //Leaving this here now, but you do NOT want to tackle with this at the moment, future Alyx will take care of it

    private CharacterController _charController;
    private Vector2 _inputWalk;
    private Vector3 _velocity;
    
    private Transform _playerTransform;

    #endregion
    
    #region Unity Methods
    private void Awake()
    {
        _charController = GetComponent<CharacterController>();
        _playerTransform = GetComponent<Transform>();
        
        _playerTransform.rotation = Quaternion.Euler(0, 90, 0);
    }//EndOf Unity method Awake

    private void Update()
    {
        WalkLogic();
        RotateLogic();
        
        //Jump logic
        _velocity.y += gravity * Time.deltaTime;
        _charController.Move(_velocity * Time.deltaTime);
    }//EndOf Unity method Update

    #endregion
    
    #region Own Methods
    
    //FUUUCK using "Send Messages", I could not, for the life of me, find any way for the fucking Rigidbody to listen to me
    //I'll now try and use the CharacterController component, which avoids using a Rigidbody entirely

    public void OnWalk(InputAction.CallbackContext context)
    {
        _inputWalk = context.ReadValue<Vector2>();
        airborneDrag = 1;
        Debug.Log($"Walk Input: {_inputWalk}");
    }//EndOf method OnWalk

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping {context.performed} - Is Grounded: {_charController.isGrounded}");
        if (context.performed && _charController.isGrounded)
        {
            Debug.Log("Are you jumping, son?");
            _velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
            airborneDrag = 0.88f;
        }//EndOf IF
    }//EndOf method OnJump

    private void WalkLogic()
    {
        _charController.Move(new Vector3(_inputWalk.x, 0, _inputWalk.y) * (walkSpeed * Time.deltaTime * airborneDrag));
    }//EndOf method WalkLogic
    
    private void RotateLogic()
    {
        if (_inputWalk.x < 0)
        {
            _playerTransform.rotation = Quaternion.Euler(0, -90, 0);
        }else if (_inputWalk.x > 0)
        {
            _playerTransform.rotation = Quaternion.Euler(0, 90, 0);
        }//EndOf IF/ELSE chain
    }//EndOf method RotateLogic

    #endregion
}
