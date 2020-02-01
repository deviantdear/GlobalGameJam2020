using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Launcher controller
/// </summary>
public class Launcher : MonoBehaviour
{
    public Projectile Projectile { get; set; }

    public UnityAction onLoading;
    public UnityAction onLoaded;

    public UnityAction onUnloading;
    public UnityAction onUnloaded;
    
    public UnityAction onFire;

    public UnityAction onCooldownStart;
    public UnityAction onCooldownEnd;

    public enum State
    {
        unarmed,
        loading,
        loaded,
        firing,
        cooldown
    }

    State currentState = State.unarmed;
    public State CurrentState { get => currentState; }


    [SerializeField]
    RotationControl upRotationControl;

}
