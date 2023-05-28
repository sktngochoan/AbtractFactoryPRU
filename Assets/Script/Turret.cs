using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Turret : MonoBehaviour
{
    // Each vehicle implementation specifies its own movement speed
    protected float BulletSpeed = 0f;
    public enum TurretType
    {
        AutoTurret,
        MiniTurret
    }

    public abstract TurretType GetTurretType();

    // If a vehicle is not on a container ship, and if a vehicle is not yet waiting at the beach, (pickup location)
    // we let it move towards the beach (pickup location). Once it has reached the pickup location, we move the vehicle
    // onto the container ship
    void Update()
    {
        transform.Translate(Vector3.right * (BulletSpeed * Time.deltaTime));
    }
}
