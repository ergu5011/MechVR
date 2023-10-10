using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MechArm : MonoBehaviour
{
    [SerializeField] private GameObject _heldCrystal;
    [SerializeField] private GameObject _throwCrystal;
    [SerializeField] private Transform _throwSpot;

    private bool _isHeld;
    private bool _isActivated;
    private bool _isGrabbable;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChargedCrystal"))
        {
            _isGrabbable = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("ChargedCrystal"))
        {
            _isGrabbable = false;
        }
    }

    public void ActivateArm()
    {
        if (_isGrabbable == true && _isHeld == false)
        {
            _isHeld = true;

            _heldCrystal.SetActive(true);

            return;
        }

        if (_isHeld == true)
        {
            Instantiate(_throwCrystal, _throwSpot.position, _throwSpot.rotation);

            _heldCrystal.SetActive(false);

            _isHeld = false;
        }
    }
}
