using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class PlayAudioOnce : MonoBehaviour
{
    private bool _hasPlayed;

    [SerializeField] private EventReference _playOnceAudio;

    public void PlayAudio()
    {
        if (!_hasPlayed)
        {
            AudioManager.instance.PlayOneShot(_playOnceAudio, this.transform.position);

            _hasPlayed = true;
        }
    }
}
