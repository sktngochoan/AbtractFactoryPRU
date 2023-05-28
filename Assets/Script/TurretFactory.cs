using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TurretFactory : MonoBehaviour
{
    // A reference to the factory building transform (object) which produces the vehicles (i.e. they roll out of it)
    // Initialized when creating instantiating the factory implementation 
    public Transform factoryBuildingTransform;

    // Create a slow car or truck or ... depending on the concrete factory implementation
    public abstract void CreateSlowBullet();

    // Create a fast car or truck or ... depending on the concrete factory implementation
    public abstract void CreateFastBullet();
}
