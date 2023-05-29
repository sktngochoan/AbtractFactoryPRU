using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletFactory : MonoBehaviour
{
    public Transform TurretTransform;

    public abstract void CreateSlowBullet();

    public abstract void CreateFastBullet();
}
