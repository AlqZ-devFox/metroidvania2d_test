using System;
using System.Collections;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    #region  Global Variables

    [SerializeField] private GameObject doorShootable; //The part of the door you shoot to open, different from the shield it may have

    [SerializeField] private float closeTime = 7.0f;
    private bool _isOpen; //Only Serialize this when debugging

    #endregion

    #region Unity Methods

    private void Start()
    {
        doorShootable.SetActive(true); //Make sure it's there
        _isOpen = false; //By default, close the door
    }//EndOf Unity method Start

    private void Update()
    {
        if (_isOpen)
        {
            StartCoroutine(CloseDoor());
        }//EndOf IF
    }//EndOf Unity method Update
    
    private void OnTriggerEnter(Collider other)
    {
        /*
         * We want to check if the door is being shot at
         * For now, we only check if it is, indeed being shot at, but later we'll add missile doors and PERHAPS power bomb doors
         */
        //TODO: Have an even "outerer" IF check in case the door has a shield (as in, it's a missile/missileSuper/bombPower door

        if (other.CompareTag("beam") /*TODO: Maybe missiles/missileSuper/bombNormal can open these too*/)
        {
            _isOpen = true;
            OpenDoor();
        }//EndOf IF
    }//EndOf method OnTriggerEnter

    #endregion
    
    #region Own Methods

    private IEnumerator CloseDoor()
    {
        yield return new WaitForSeconds(closeTime);
        _isOpen = false;
        doorShootable.SetActive(true);
    }//EndOf IEnumerator method CloseDoor

    private void OpenDoor()
    {
        if (_isOpen)
        {
            //TODO: Instead of just deactivating the shootable part of the Door, have a cool animation or something
            doorShootable.SetActive(false); //Door was shot at with a proper weapon/key, open it
        }//EndOf IF
    }//EndOf method OpenDoor
    
    #endregion
}
