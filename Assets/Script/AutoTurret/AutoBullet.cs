using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBullet : Bullet
{
    public float slow = 0;
    public override BulletType GetBulletType()
    {
        return BulletType.MiniBullet;
    }
}
