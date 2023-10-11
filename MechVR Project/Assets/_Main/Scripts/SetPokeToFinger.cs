using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeToFinger : MonoBehaviour
{
    public Transform pokeAttachPoint;

    private XRPokeInteractor _xrPokeInteractor;

    void Start()
    {
        _xrPokeInteractor = transform.parent.parent.GetComponentInChildren<XRPokeInteractor>();
        SetPokeAttachPoint();
    }

    void SetPokeAttachPoint()
    {
        if (pokeAttachPoint == null) 
        {
            Debug.Log("Poke attach point is null"); 
            return;
        }

        if (_xrPokeInteractor == null)
        {
            Debug.Log("XR poke interactor is null");
            return;
        }

        _xrPokeInteractor.attachTransform = pokeAttachPoint;
    }
}
