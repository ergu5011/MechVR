using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyableWall : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject _wallBody;
    [SerializeField] private ParticleSystem _destroyParticle;

    private void Kaboom() 
    {
        _wallBody.SetActive(false);

        _destroyParticle.Play();

        AudioManager.instance.PlayOneShot(FMODEvents.instance.rockDestruction, this.transform.position);
    }

    public void Interact()
    {
        Kaboom();
    }
}
