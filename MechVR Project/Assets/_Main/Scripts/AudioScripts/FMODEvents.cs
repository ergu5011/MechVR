using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMODUnity;

public class FMODEvents : MonoBehaviour
{
    [field: Header("Ambience")]
    [field: SerializeField] public EventReference caveAmbiance { get; private set; }

    [field: Header("Mech SFX")]
    [field: SerializeField] public EventReference buttonPressed { get; private set; }

    [field: SerializeField] public EventReference mechFootsteps { get; private set; }

    [field: SerializeField] public EventReference mechTurning { get; private set; }

    [field: SerializeField] public EventReference armActivation { get; private set; }

    [field: SerializeField] public EventReference electricShock { get; private set; }

    [field: Header("Misc SFX")]
    [field: SerializeField] public EventReference crystalGrab { get; private set; }

    [field: SerializeField] public EventReference crystalExplosion { get; private set; }

    [field: SerializeField] public EventReference rockDestruction { get; private set; }

    [field: SerializeField] public EventReference slugSplat { get; private set; }

    [field: Header("Voices")]
    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null) Debug.LogError("Found more than one FMOD Events instance in scene");

        instance = this;
    }
}
