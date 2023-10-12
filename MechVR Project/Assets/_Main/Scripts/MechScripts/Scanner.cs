using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Scanner : MonoBehaviour
{
    [SerializeField] private GameObject _scanZone;

    [SerializeField] private PlayableDirector _activateTimeline;

    private string _tagComparison;

    public void ActivateScanner()
    {
        _activateTimeline.Play();
    }

    public void Scanning()
    {
        switch (_tagComparison)
        {
            case "Slug":
                AudioManager.instance.PlayOneShot(FMODEvents.instance.scannedSlug, this.transform.position);
                break;
            case "ChargedCrystal":
                AudioManager.instance.PlayOneShot(FMODEvents.instance.scannedCCrystal, this.transform.position);
                break;
            case "InertCrystal":
                AudioManager.instance.PlayOneShot(FMODEvents.instance.scannedICrystal, this.transform.position);
                break;
            case "Mushroom":
                AudioManager.instance.PlayOneShot(FMODEvents.instance.scannedMushroom, this.transform.position);
                break;
            default:
                AudioManager.instance.PlayOneShot(FMODEvents.instance.scannedNull, this.transform.position);
                break;
        }

        _tagComparison = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        _tagComparison = other.gameObject.tag;
    }
}
