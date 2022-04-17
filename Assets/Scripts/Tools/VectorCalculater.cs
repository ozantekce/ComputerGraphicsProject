using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorCalculater
{



    public static bool CheckVectorXFrontOfVectorY(Vector3 vectorX,Vector3 vectorY)
    {

        float cos = (Vector3.Dot(vectorX, vectorY) / (vectorX.magnitude* vectorY.magnitude));

        return cos > 0;

    }


    public static Vector3 PreventToPassMaxMagnitude(Vector3 vector3, float max)
    {

        if (vector3.magnitude > max)
            vector3 = vector3.normalized * max;
        return vector3;

    }

    /// <summary>
    /// return the unit vector needed to get to the destination
    /// </summary>
    /// <param name="position"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static Vector3 CalculateDirectionVector(Vector3 position, Vector3 target)
    {
        return ( target - position ).normalized;
    }


    /// <summary>
    /// return the unit vector needed to get to the destination but ignoring y axis because
    /// </summary>
    /// <param name="position"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public static Vector3 CalculateDirectionVectorWithoutYAxis(Vector3 position, Vector3 target)
    {
        target.y = 0;
        position.y = 0;
        return (target - position).normalized;

    }

    /// <summary>
    /// remove the removeAxis and return a vector2
    /// </summary>
    /// <param name="vector"></param>
    /// <param name="removeAxis"></param>
    /// <returns></returns>
    public static Vector2 Vector3toVector2(Vector3 vector, Axis removeAxis)
    {
        Vector2 rtn = Vector2.zero;
        if(removeAxis == Axis.x)
        {
            rtn.x = vector.y;
            rtn.y = vector.z;
        }else if(removeAxis == Axis.y)
        {
            rtn.x = vector.x;
            rtn.y = vector.z;
        }else if(removeAxis == Axis.z)
        {
            rtn.x = vector.x;
            rtn.y= vector.y;
        }

        return rtn;

    }



    public static Vector2 ThreeDForwardToTwoDForward(Vector3 vector)
    {
        return new Vector2(vector.x, vector.z).normalized;
    }


}
