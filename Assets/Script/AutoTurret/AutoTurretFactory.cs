using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurretFactory : TurretFactory
{
    private const string SlowBullet = "AutoNormalBullet";
    private const string FastBullet = "AutoExplosiveBullet";

    public override void CreateSlowBullet()
    {
        var factoryTransformPosition = factoryBuildingTransform.transform.position;
        var slowBullet = Resources.Load(SlowBullet) as GameObject;
        if (slowBullet != null)
        {
            var slowCar = Instantiate(slowBullet.transform, new Vector2(factoryTransformPosition.x, factoryTransformPosition.y), Quaternion.identity);        }
        else
        {
            throw new System.ArgumentException(SlowBullet + "could not be found inside or loaded from Resources folder");
        }
    }

    public override void CreateFastBullet()
    {
        var factoryTransformPosition = factoryBuildingTransform.transform.position;
        var fastBullet = Resources.Load(FastBullet) as GameObject;
        if (fastBullet != null)
        {
            var fastCar = Instantiate(fastBullet.transform, new Vector2(factoryTransformPosition.x, factoryTransformPosition.y), Quaternion.identity);
        }
        else
        {
            throw new System.ArgumentException(FastBullet + "could not be found inside or loaded from Resources folder");
        }
    }
}
