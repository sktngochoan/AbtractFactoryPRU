using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoBullet : Bullet
{
    public override BulletType GetBulletType()
    {
        return BulletType.MiniBullet;
    }
}
