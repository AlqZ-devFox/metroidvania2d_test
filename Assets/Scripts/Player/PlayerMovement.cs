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
    [SerializeField] public Rigidbody playerRb;
    [SerializeField] public PlayerInput playerInput;

    public float jumpForce;
    public float walkSpeed;
    //public float speedBoostSpeed; //Leaving this here now, but you do NOT want to tackle with this at the moment, future Alyx will take care of it

    #endregion
    
    #region Unity Methods
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();
    }//EndOf Unity method Awake
    
    #endregion
    
    #region Own Methods

    private void PlayerWalk()
    {
        if (playerInput.actions.Equals("Walk")) //TODO: Turns out, this doesn't work like that
        {
            this.playerRb.linearVelocity = Vector3.forward *  walkSpeed;
        }
    }//EndOf method PlayerWalk
    
    #endregion
}
