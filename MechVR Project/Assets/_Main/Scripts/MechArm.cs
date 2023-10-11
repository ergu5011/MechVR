using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class MechArm : MonoBehaviour
{
    [SerializeField] private GameObject _heldCrystal;
    [SerializeField] private GameObject _throwCrystal;
    [SerializeField] private Transform _throwSpot;

    [SerializeField] private PlayableDirector _grabTimeline;
    [SerializeField] private PlayableDirector _throwTimeline;

    private bool _isHeld;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("ChargedCrystal"))
        {
            _isHeld = true;

            _heldCrystal.SetActive(true);
        }
    }

    public void ActivateArm()
    {
        if (_isHeld == false) _grabTimeline.Play();
        else _throwTimeline.Play();
    }

    public void ThrowCrystal()
    {
        Instantiate(_throwCrystal, _throwSpot.position, _throwSpot.rotation);

        _heldCrystal.SetActive(false);

        _isHeld = false;
    }
}
