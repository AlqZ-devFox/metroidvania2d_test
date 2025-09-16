using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class PlayerAttack : MonoBehaviour
{
    #region Global Variables
    
    [SerializeField] private GameObject beam;
    private GameObject[] _beams; //array of beam prefab
    [SerializeField] private Transform beamOrigin; //from where the shots are going to come from
    [SerializeField] private int maxBeam = 64;
    [SerializeField] private float waitToDestroy = 6;

    [SerializeField] [Range(0.1f, 1000f)] private float beamDamage;
    [SerializeField] [Range(0.1f, 1000f)] private float beamSpeed;

    //private bool _isTriple; //Worry about this later to test Wide Beam
    
    #endregion

    #region Unity Methods

    void Awake()
    {
        for (int i = 0; i < maxBeam; i++)
        {
            _beams[i] = Instantiate(beam, beamOrigin);
            _beams[i].SetActive(false);
        }//EndOf FOR Loop
        
        beam.SetActive(false);
    }//EndOf Unity method Awake

    void Update()
    {
        //Beam Logic
        BeamLogic();
    }//EndOf Unity method Update

    #endregion
    
    #region Own Methods
    
    public void OnShoot(InputAction.CallbackContext context)
    {
        for (int i = 0; i < _beams.Length; i++)
        {
            if (context.performed && !_beams[i].activeInHierarchy)
            {
                _beams[i].SetActive(true);
                StartCoroutine(DeactivateBeam(_beams[i]));
                
                return;
            }//EndOf IF
        }//EndOf FOR Loop
    }//EndOf method OnShoot

    private IEnumerator DeactivateBeam(GameObject beam)
    {
        yield return new WaitForSeconds(waitToDestroy);
        beam.SetActive(false);
    }

    private void BeamLogic()
    {
        for (int i = 0; i < _beams.Length; i++)
        {
            if (_beams[i].activeInHierarchy)
            {
                _beams[i].GetComponent<Rigidbody>().linearVelocity = Vector3.forward * (beamSpeed * Time.deltaTime);
            }//EndOf IF
        }//EndOf FOR Loop
    }//EndOf method BeamLogic
    
    #endregion
}
