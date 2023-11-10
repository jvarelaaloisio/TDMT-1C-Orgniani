using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Character Movement/Multiplier Speed Handler", fileName = "SH_")]
public class SpeedMultiplierHandler : SpeedHandler
{
    public override float HandleSpeed(float speed, float maxSpeed)
    {
        if(speed != maxSpeed)
        {
            var newSpeed = speed * 2;
            return newSpeed;
        }

        return speed;
    }
}

