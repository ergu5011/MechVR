using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: SerializeField] public EventReference caveAmbiance { get; private set; }

    [field: SerializeField] public EventReference buttonPressed { get; private set; }

    [field: SerializeField] public EventReference mechFootsteps { get; private set; }

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null) Debug.LogError("Found more than one FMOD Events instance in scene");

        instance = this;
    }
}
