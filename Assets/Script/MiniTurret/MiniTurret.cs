using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniTurret : Turret
{
    public override TurretType GetTurretType()
    {
        return TurretType.AutoTurret;
    }
}
