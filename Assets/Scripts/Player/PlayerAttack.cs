using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour
{
    #region Global Variables
    
    [SerializeField] private GameObject beam;
    [SerializeField] private Transform beamOrigin; //from where the shots are going to come from
    //private bool _isTriple; //Worry about this later to test Wide Beam, but you'll need two extra beam origins
    
    #endregion

    #region Unity Methods

    void Awake()
    {
        
    }//EndOf Unity method Awake

    #endregion
    
    #region Own Methods
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        //
    }//EndOf method OnShoot
    
    #endregion
}
