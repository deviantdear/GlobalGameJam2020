using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Launcher controller
/// </summary>
public class LauncherControl : MonoBehaviour
{
    /// <summary>
    /// Set this to load the projectile
    /// </summary>
    public Projectile AmmoLoaded { get => _ammoLoaded; set => Reload(value); }
    [SerializeField] Projectile _ammoLoaded;

    [Header("Controls")]
    [SerializeField] RotationControl upRotationControl;
    [SerializeField] RotationControl panRotationControl;
    [SerializeField] ButtonControl triggerControl;
    [SerializeField] ButtonControl reloadControl;

    [Header("Parts")]
    [SerializeField] Transform tilt; // Object that tilts
    [SerializeField] Transform pan;

    [Header("Settings")]
    [SerializeField] float loadingTime = 1f; // Time it takes to load launcher with a new projectile
    [SerializeField] float unloadingTime = 1f; // Time to remove a loaded projectile
    [SerializeField] float firingTime = 1f; // Time to fire a projectile
    [SerializeField] float cooldownTime = 1f; // Time to reset after firing

    [Header("Events")]
    [SerializeField] State currentState = State.unarmed;
    public UnityEvent onLoading;
    public UnityEvent onLoaded;

    public UnityEvent onUnloading;
    public UnityEvent onUnloaded;

    public UnityEvent onFire;

    public UnityEvent onCooldownStart;
    public UnityEvent onCooldownEnd;
    public UnityEvent onFiringFailed;
    private void Start()
    {
        triggerControl.onButtonDown.AddListener(Trigger);
        reloadControl.onButtonUp.AddListener(()=>Reload());
    }

    private void Update()
    {
        tilt.Rotate(Vector3.right, upRotationControl.Rotation);
        pan.Rotate(Vector3.up, panRotationControl.Rotation);
    }
    #region state_managment

    [System.Serializable]
    public enum State
    {
        unarmed,
        loading,
        unloading,
        loaded,
        firing,
        cooldown
    }

    float stateBegun = 0f;
    public State CurrentState { get => currentState; }


    private void LateUpdate()
    {
        switch (currentState)
        {
            case State.loading:
                DoWhileLoading();
                break;
            case State.unloading:
                DoWhileUnloading();
                break;
            case State.firing:
                DoWhileFiring();
                break;
            case State.cooldown:
                DoWhileCooldown();
                break;
            case State.loaded:
                DoWhileLoaded();
                break;
            default:
                DoWhileUnloaded();
                break;
        }
    }


    private void DoWhileUnloaded()
    {
        // Do nothing, waiting to load ammo
    }

    private void NextState(float prevStateLength, State nextState, UnityEvent triggerEvent)
    {
        // Wait till end of loading time, then change state to loaded.
        if (stateBegun + prevStateLength < Time.time)
        {
            Debug.Log($" Was {currentState} Changing state to {nextState}");
            ChangeState(nextState);
            triggerEvent.Invoke();
        }
    }
    #endregion
    private void DoWhileLoading()
    {
        // Wait till end of loading time, then change state to loaded.
        NextState(loadingTime, State.loaded, onLoaded);

    }

    private void DoWhileUnloading()
    {
        // Wait till end of unloading time, and change state to unarmed.
        NextState(unloadingTime, State.unarmed, onUnloaded);
    }

    private void DoWhileLoaded()
    {
        // Await trigger
    }

    private void DoWhileFiring()
    {
        NextState(firingTime, State.cooldown, onCooldownStart);
    }

    private void DoWhileCooldown()
    {
        NextState(cooldownTime, State.unarmed, onCooldownEnd);
    }

    private void ChangeState(State newState)
    {
        currentState = newState;
        stateBegun = Time.time;
    }

    /// <summary>
    /// Triggers the launcher
    /// </summary>
    public void Trigger()
    {
        // If the cannon isn't loaded, then you can't shoot.
        if (currentState != State.loaded) 
        {
            onFiringFailed.Invoke();
            return;
        }
        Debug.Log("Firing");
        ChangeState(State.firing);
        onFire.Invoke();
    }

    /// <summary>
    /// Unloads the launcher
    /// </summary>
    public void Unload()
    {
        // If the cannon isn't loaded, no need to unload
        if (currentState != State.loaded)
        {
            return;
        }
        Debug.Log("Unloading");
        ChangeState(State.unloading);
        onUnloading.Invoke();
    }

    /// <summary>
    /// Reloads the launcher
    /// </summary>
    public void Reload(Projectile newProjectile = null)
    {
        // 
        if (currentState != State.unarmed)
        {
            return;
        }
        Debug.Log("Reloading");
        if (newProjectile)
            _ammoLoaded = newProjectile;
        ChangeState(State.loading);
        onLoading.Invoke();
    }

}
