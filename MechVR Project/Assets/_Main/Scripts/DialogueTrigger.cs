using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class DialogueTrigger : MonoBehaviour
{
    private bool _hasTriggered = false;

    [SerializeField] private EventReference _playOnceAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (_hasTriggered == true) return;
        
        if (other.gameObject.CompareTag("Player"))
        {
            AudioManager.instance.PlayOneShot(_playOnceAudio, this.transform.position);

            Debug.Log("intro");

            _hasTriggered = true;
        }

        //_hasTriggered = true;
    }
}
