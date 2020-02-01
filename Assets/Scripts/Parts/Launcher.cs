using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Launcher controller
/// </summary>
public class Launcher : MonoBehaviour
{
    /// <summary>
    /// Set this to load the projectile
    /// </summary>
    public Projectile Projectile { get; set; }

    [Header("Controls")]
    [SerializeField] RotationControl upRotationControl;
    [SerializeField] ButtonControl triggerControl;

    [Header("Parts")]
    [SerializeField] Transform tilt; // Object that tilts
    [SerializeField] Transform projectileSpawn; // Point at which the projectiles are launched, world direction is used for launch vector.

    [Header("Settings")]
    [SerializeField] float force = 1f; // Force that is imparted on the projectile
    [SerializeField] float loadingTime = 1f; // Time it takes to load launcher with a new projectile
    [SerializeField] float unloadingTime = 1f; // Time to remove a loaded projectile
    [SerializeField] float firingTime = 1f; // Time to fire a projectile
    [SerializeField] float cooldownTime = 1f; // Time to reset after firing

    [Header("Events")]
    public UnityEvent onLoading;
    public UnityEvent onLoaded;

    public UnityEvent onUnloading;
    public UnityEvent onUnloaded;
    
    public UnityEvent onFire;

    public UnityEvent onCooldownStart;
    public UnityEvent onCooldownEnd;

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

    private void Start()
    {
        triggerControl.onButtonDown.AddListener(Trigger);
    }

    /// <summary>
    /// Triggers the launcher
    /// </summary>
    public void Trigger()
    {

    }

}
