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
    // [SerializeField] public PlayerInput playerInput;
    private PlayerInput playerInput;
    private InputAction actionWalk;
    private InputAction actionJump;

    public float jumpForce;
    public float walkSpeed;
    //public float speedBoostSpeed; //Leaving this here now, but you do NOT want to tackle with this at the moment, future Alyx will take care of it

    #endregion
    
    #region Unity Methods
    void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        playerInput = GetComponent<PlayerInput>();

        actionWalk = playerInput.FindAction("Walk");
        actionJump = playerInput.FindAction("Jump");
    }//EndOf Unity method Awake
    
    #endregion
    
    #region Own Methods
    private void OnWalk()
    {
        Debug.Log("OnWalk was called");

        //TODO Check Player's rotation
        
        
    }//endOf method OnWalk
    
    #endregion
}
