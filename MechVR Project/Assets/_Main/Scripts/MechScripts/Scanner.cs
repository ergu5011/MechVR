using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    [SerializeField] private GameObject _scanZone;

    private string _tagComparison;
    private string _voiceLine;

    public void Scanning()
    {
        _scanZone.SetActive(true);
        _scanZone.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (_tagComparison)
        {
            case "Slug":
                _voiceLine = "123";
                break;
            case "ChargedCrystal":
                _voiceLine = "123";
                break;
            case "InertCrystal":
                _voiceLine = "123";
                break;
            case "Mushroom":
                _voiceLine = "123";
                break;
            default:
                _voiceLine = "123";
                break;

        }

        AudioManager.instance.PlayOneShot(FMODEvents.instance.slugSplat, this.transform.position);
    }
}
