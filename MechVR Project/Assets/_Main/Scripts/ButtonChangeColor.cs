using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeColor : MonoBehaviour
{
    private bool _state;

    private MeshRenderer _changeMat;

    [SerializeField] private Material _mat1;
    [SerializeField] private Material _mat2;

    [SerializeField] private bool _oneTimeUse;
    private bool _hasPressed;

    void Start()
    {
        _changeMat = GetComponent<MeshRenderer>();
    }

    public void Pressed()
    {
        if (_hasPressed == true && _oneTimeUse == true) return;

        if ( _state == false)
        {
            _changeMat.sharedMaterial = _mat2;
        }
        else
        {
            _changeMat.sharedMaterial = _mat1;
        }

        AudioManager.instance.PlayOneShot(FMODEvents.instance.buttonPressed, this.transform.position);

        _state = !_state;

        _hasPressed = true;
    }
}
