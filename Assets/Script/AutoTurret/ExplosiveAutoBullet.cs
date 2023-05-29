using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosiveAutoBullet : AutoBullet
{
    private void Start()
    {
        BulletSpeed = 10;
        BulletDame = 20;
    }
}
