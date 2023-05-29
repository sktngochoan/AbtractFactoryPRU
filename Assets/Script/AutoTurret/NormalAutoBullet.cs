using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAutoBullet : AutoBullet
{
    private void Start()
    {
        BulletSpeed = 6;
        BulletDame = 10;
    }
}
