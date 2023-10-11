using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlugTrigger : MonoBehaviour
{
    private bool _hasTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if (_hasTriggered == true) return;

        if (other.gameObject.CompareTag("Player"))
        {
            IInteractable interactable = other.gameObject.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }

            _hasTriggered = true;
        }
    }
}
