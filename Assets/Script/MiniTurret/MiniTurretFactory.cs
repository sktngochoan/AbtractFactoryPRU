using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MiniTurretFactory : TurretFactory
{
    private const string slowBullet = "MiniNormalBullet";
    private const string fastBullet = "MiniExplosiveBullet";

    public override void CreateSlowBullet()
    {
        var factoryTransformPosition = factoryBuildingTransform.transform.position;
        var slowBulletObject = Resources.Load(slowBullet) as GameObject;
        if (slowBulletObject != null)
        {
            var slowTruck = Instantiate(slowBulletObject.transform, new Vector3(factoryTransformPosition.x, factoryTransformPosition.y, factoryTransformPosition.z), Quaternion.identity);
        }
        else
        {
            throw new System.ArgumentException(slowBullet + "could not be found inside or loaded from Resources folder");
        }
    }

    public override void CreateFastBullet()
    {
        var factoryTransformPosition = factoryBuildingTransform.transform.position;
        var fastBulletObject = Resources.Load(fastBullet) as GameObject;
        if (fastBulletObject != null)
        {
            var fastTruck = Instantiate(fastBulletObject.transform, new Vector3(factoryTransformPosition.x, factoryTransformPosition.y, factoryTransformPosition.z), Quaternion.identity);
            
        }
        else
        {
            throw new System.ArgumentException(fastBullet + "could not be found inside or loaded from Resources folder");
        }
    }
}
