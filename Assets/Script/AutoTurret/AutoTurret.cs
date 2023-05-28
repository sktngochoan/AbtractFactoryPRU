using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoTurret : Turret
{
    public override TurretType GetTurretType()
    {
        return TurretType.MiniTurret;
    }
}
