using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BallVision))]
public class BallVisionEditor : Editor
{
    private void OnSceneGUI()
    {
        BallVision vision = (BallVision)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(vision.transform.position, Vector3.up, Vector3.forward, 360, vision.visionRadius);

        Vector3 visionAngleA = vision.DirFromAngle(-vision.visionAngle / 2, false);
        Vector3 visionAngleB = vision.DirFromAngle(vision.visionAngle / 2, false);

        Handles.DrawLine(vision.transform.position, vision.transform.position + visionAngleA * vision.visionRadius);
        Handles.DrawLine(vision.transform.position, vision.transform.position + visionAngleB * vision.visionRadius);

        Handles.color = Color.red;
        if(vision.ballTransform != null)
        {
            Handles.DrawLine(vision.transform.position, vision.ballTransform.position);
        }


    }


}
