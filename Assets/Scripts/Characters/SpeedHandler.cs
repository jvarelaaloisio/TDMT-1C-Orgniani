using UnityEngine;

[CreateAssetMenu(menuName = "Character Movement/Speed Handler", fileName = "SH_")]

public class SpeedHandler : ScriptableObject
{
    public virtual float HandleSpeed(float speed, float maxSpeed)
    {
        if (speed == maxSpeed)
        {
            var newSpeed = speed / 2;
            return newSpeed;
        }

        return speed;
    }
}
