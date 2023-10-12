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
    [field: SerializeField] public EventReference introDialogue { get; private set; }

    [field: Header("Scanner")]
    [field: SerializeField] public EventReference scannedSlug { get; private set; }

    [field: SerializeField] public EventReference scannedICrystal { get; private set; }

    [field: SerializeField] public EventReference scannedCCrystal { get; private set; }

    [field: SerializeField] public EventReference scannedMushroom { get; private set; }

    [field: SerializeField] public EventReference scannedNull { get; private set; }

    [field: Header("System")]
    [field: SerializeField] public EventReference systemArm { get; private set; }

    [field: SerializeField] public EventReference systemSpotlight { get; private set; }

    [field: SerializeField] public EventReference systemShock { get; private set; }

    [field: SerializeField] public EventReference systemDrill { get; private set; }

    [field: SerializeField] public EventReference systemCannon { get; private set; }

    [field: SerializeField] public EventReference systemFlamethrower { get; private set; }

    [field: SerializeField] public EventReference systemMusic { get; private set; }

    [field: SerializeField] public EventReference systemFood { get; private set; }

    [field: SerializeField] public EventReference systemCoffee { get; private set; }

    [field: SerializeField] public EventReference systemScreen { get; private set; }

    [field: SerializeField] public EventReference systemSignal { get; private set; }

    [field: SerializeField] public EventReference slugEncounter { get; private set; }

    public static FMODEvents instance { get; private set; }

    private void Awake()
    {
        if (instance != null) Debug.LogError("Found more than one FMOD Events instance in scene");

        instance = this;
    }
}
