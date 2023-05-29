using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBullet : Bullet
{
    public override BulletType GetBulletType()
    {
        return BulletType.AutoBullet;
    }
}
