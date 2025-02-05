using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot
{
    public static void Shot_(Shotable shotable, float shotInput, float verticalInput, float horizontalInput)
    {

        if (shotable.BallVision.NoControlBall() || shotable.ShotCooldown.NotReady())
        {
            return;
        }

        GameObject gameObject = shotable.GameObject;
        Vector3 shotVector
            = (shotInput + 0.4f) * shotable.ShotPower
            * (gameObject.transform.forward + new Vector3(verticalInput, 0.4f, horizontalInput));

        Ball.Instance.Shot(Deformation.Deform(shotVector, 1f, 10f));

    }


    public static void ForceShot(Shotable shotable, float shotInput, float verticalInput, float horizontalInput)
    {

        GameObject gameObject = shotable.GameObject;
        Vector3 shotVector
            = (shotInput + 0.4f) * shotable.ShotPower
            * (gameObject.transform.forward + new Vector3(verticalInput, 0.2f, horizontalInput)).normalized;

        Ball.Instance.Shot(Deformation.Deform(shotVector, 1f, 10f));

    }


}
