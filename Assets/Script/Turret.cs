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
    void Update()
    {
        transform.Translate(Vector3.right * (BulletSpeed * Time.deltaTime));
    }
}
