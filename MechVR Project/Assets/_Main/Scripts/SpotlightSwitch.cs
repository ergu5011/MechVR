using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightSwitch : MonoBehaviour
{
    private bool _state = true;

    // Switches wether the spotlight is on or off
    public void IsPressed()
    {
        gameObject.SetActive(_state);

        _state = !_state;
    }
}
