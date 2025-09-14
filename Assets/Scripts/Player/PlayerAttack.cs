using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAttack : MonoBehaviour
{
    #region Global Variables
    
    [SerializeField] private GameObject beam; //the beam itself, as a prefab
    private Rigidbody _beamRb;
    
    [SerializeField] private GameObject beamOrigin; //from where the shots are going to come from

    [SerializeField] [Range(0.1f, 1000f)] private float beamDamage;
    [SerializeField] [Range(0.1f, 1000f)] private float beamSpeed;

    //private bool _isTriple; //Worry about this later to test Wide Beam
    
    #endregion

    #region Unity Methods

    void Awake()
    {
        _beamRb = beam.GetComponent<Rigidbody>();
    }//EndOf Unity method Awake
    
    void Update()
    {
        //Beam shot Logic
        var beams = GameObject.FindGameObjectsWithTag("Beam");
        for (var index = 0; index < beams.Length; index++)
        {
            var beam = beams[index];
            beam.GetComponent<Rigidbody>().AddForce(beamOrigin.transform.forward * beamSpeed, ForceMode.Acceleration);
        }//EndOf FOR-Loop
    }//EndOf Unity method Update

    #endregion
    
    #region Own Methods
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        GameObject clone = Instantiate(beam, beamOrigin.transform.position, beamOrigin.transform.rotation);
        //TODO - Think of how to have the bullet actually project itself (already have a couple ideas while typing this)
        
        Destroy(clone, 7f);
    }//EndOf method OnShoot
    
    #endregion
}
