using System;
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
    public float jumpForce;
    public float walkSpeed;
    //public float speedBoostSpeed; //Leaving this here now, but you do NOT want to tackle with this at the moment, future Alyx will take care of it

    #endregion
    
    #region Unity Methods
    void Awake()
    {
        
    }//EndOf Unity method Awake

    #endregion
    
    #region Own Methods
    
    //FUUUCK using "Send Messages", I could not, for the life of me, find any way for the fucking Rigidbody to listen to me
    //I'll now try and use the CharacterController component, which avoids using a Rigidbody entirely
    #endregion
}
