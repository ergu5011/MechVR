using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressTest : MonoBehaviour
{
    private bool _state; // False = blue, true = red

    private MeshRenderer _changeMat;

    [SerializeField] private Material _mat1;
    [SerializeField] private Material _mat2;

    void Start()
    {
        _changeMat = GetComponent<MeshRenderer>();
    }

    void Update()
    {
        
    }

    public void Pressed()
    {
        if ( _state == false)
        {
            _changeMat.sharedMaterial = _mat2;

            //Debug.Log("button is red now");
        }
        else
        {
            _changeMat.sharedMaterial = _mat1;

            //Debug.Log("button is blue now");
        }

        _state = !_state;
    }
}
