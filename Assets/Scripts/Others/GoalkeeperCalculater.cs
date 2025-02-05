using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalkeeperCalculater
{

    private const float EXPERIMENTAL_LIMIT = 10;
    private const float EXPERIMENTAL_INCREASE_RATE = 0.3f;



    public static Vector3[] CalculateAll(Goalkeeper goalkeeper)
    {

        Ball ball = Ball.Instance;
        Vector3 ballPos = ball.transform.position;
        Vector3 catchAreaPos = goalkeeper.CatchArea.transform.position;
        Vector3 ballVelocity = ball.Rigidbody.velocity;

        // if ball position y not equal 0 before meeting
        float estimatedMeetingTime = (catchAreaPos.z - ballPos.z) / ballVelocity.z;

        // time of ball position y equal 0 if y = 0 in start
        //  X(t) = 0 when t = (V_y * 2) / g
        float estimatedBallY_ZeroTime = (ballVelocity.y * 2) / (Gravity.GLOBAL_GRAVITY / 0.02f);

        //  CASE - 1 : Ball pos_y > 0 until meeting 
        bool case1;
        //  CASE - 2 : Ball pos_y = 0 before meeting

        case1 = estimatedBallY_ZeroTime > estimatedMeetingTime;

        if (case1)
        {
            float t;            //  Time
            float g = (Gravity.GLOBAL_GRAVITY / 0.02f);
            float Mx, My, Mz;   //  Meeting Pos
            float Dx, Dy, Dz;   //  Distance with goalkeeper
            float Vx, Vy, Vz;   //  required velocity of goalkeeper

            t = estimatedMeetingTime;

            Mx = ballPos.x + (t * ballVelocity.x);
            My = ballPos.y + (t * ballVelocity.y) - ((g * t * t) / 2f); //X(t) = V*t - (g * t^2)/2
            Mz = catchAreaPos.z;

            Dx = Mx - catchAreaPos.x;
            Dy = Mz - catchAreaPos.z;
            Dz = 0;

            Vx = Dx / t;
            Vy = (Dy / t) + ((g * t) / 2); // V(0) = (d/t) + ((g*t)/2)
            Vz = 0;

            Vector3 meetingPos = new Vector3(Mx, My, Mz);
            DateTime dt1 = DateTime.Now;
            dt1 = dt1.AddSeconds(t);
            string meetingTime = dt1.ToString("hh.mm.ss.fffffff");

            Vector3 requiredVelocity = new Vector3(Vx, Vy, Vz);

            Debug.Log("CASE - 1");
            Debug.Log("Meeting : " + meetingPos);
            Debug.Log("Time    : "+t +" meeting Time : " + meetingTime);
            Debug.Log("Vel     : " + requiredVelocity);


            if (requiredVelocity.y < 0)
            {
                requiredVelocity.y = 0.1f;
            }

            if (t > 0)
                return new Vector3[] { meetingPos, requiredVelocity };

        }

        Debug.Log("CASE - 2");
        Debug.Log("ball y :" + ball.transform.position.y);

        ballVelocity.y += EXPERIMENTAL_INCREASE_RATE;
        return CalculateAllExperimental(goalkeeper,ballVelocity,0);



    }



    private static Vector3[] CalculateAllExperimental(Goalkeeper goalkeeper,Vector3 ballVel,int times)
    {
        times++;
        if (times >= EXPERIMENTAL_LIMIT)
            return null;

        Ball ball = Ball.Instance;
        Vector3 ballPos = ball.transform.position;
        Vector3 catchAreaPos = goalkeeper.CatchArea.transform.position;
        Vector3 ballVelocity = ballVel;

        // if ball position y not equal 0 before meeting
        float estimatedMeetingTime = (catchAreaPos.z - ballPos.z) / ballVelocity.z;

        // time of ball position y equal 0 if y = 0 in start
        //  X(t) = 0 when t = (V_y * 2) / g
        float estimatedBallY_ZeroTime = (ballVelocity.y * 2) / (Gravity.GLOBAL_GRAVITY / 0.02f);

        //  CASE - 1 : Ball pos_y > 0 until meeting 
        bool case1;
        //  CASE - 2 : Ball pos_y = 0 before meeting


        case1 = estimatedBallY_ZeroTime > estimatedMeetingTime;

        if (case1)
        {
            float t;            //  Time
            float g = (Gravity.GLOBAL_GRAVITY / 0.02f);
            float Mx, My, Mz;   //  Meeting Pos
            float Dx, Dy, Dz;   //  Distance with goalkeeper
            float Vx, Vy, Vz;   //  required velocity of goalkeeper

            t = estimatedMeetingTime;

            Mx = ballPos.x + (t * ballVelocity.x);
            My = ballPos.y + (t * ballVelocity.y) - ((g * t * t) / 2f); //X(t) = V*t - (g * t^2)/2
            Mz = catchAreaPos.z;

            Dx = Mx - catchAreaPos.x;
            Dy = Mz - catchAreaPos.z;
            Dz = 0;

            Vx = Dx / t;
            Vy = (Dy / t) + ((g * t) / 2); // V(0) = (d/t) + ((g*t)/2)
            Vz = 0;

            Vector3 meetingPos = new Vector3(Mx, My, Mz);
            DateTime dt1 = DateTime.Now;
            dt1 = dt1.AddSeconds(t);
            string meetingTime = dt1.ToString("hh.mm.ss.fffffff");

            Vector3 requiredVelocity = new Vector3(Vx, Vy, Vz);

            Debug.Log("CASE - 1");
            Debug.Log("Meeting : " + meetingPos);
            Debug.Log("Time    : " + t + " meeting Time : " + meetingTime);
            Debug.Log("Vel     : " + requiredVelocity);

            if(requiredVelocity.y < 0)
            {
                requiredVelocity.y = 0.1f;
            }

            if (t > 0)
                return new Vector3[] { meetingPos, requiredVelocity };

        }

        /*
        Debug.Log("CASE - 2");
        Debug.Log("ball y :" + ball.transform.position.y);
        */
        ballVelocity.y += EXPERIMENTAL_INCREASE_RATE;
        Debug.Log("times : "+times+" "+ballVelocity);
        return CalculateAllExperimental(goalkeeper, ballVelocity,times);


    }





    public static Vector3[] CalculateAll_(Goalkeeper goalkeeper)
    {

        Ball ball = Ball.Instance;
        Vector3 ballPos = ball.transform.position;
        Vector3 catchAreaPos = goalkeeper.CatchArea.transform.position;
        Vector3 ballVelocity = ball.Rigidbody.velocity;

        // if ball position y not equal 0 before meeting
        float estimatedMeetingTime = (catchAreaPos.z - ballPos.z) / ballVelocity.z;

        // time of ball position y equal 0
        //  X(t) = 0 when t = (V_y * 2) / g
        float estimatedBallY_ZeroTime = (ballVelocity.y * 2) / (Gravity.GLOBAL_GRAVITY / 0.02f);



        float t;            //  Time
        float g = (Gravity.GLOBAL_GRAVITY / 0.02f);
        float Mx, My, Mz;   //  Meeting Pos
        float Dx, Dy, Dz;   //  Distance with goalkeeper
        float Vx, Vy, Vz;   //  required velocity of goalkeeper

        t = estimatedMeetingTime;

        Mx = ballPos.x + (t * ballVelocity.x);

        My = ballPos.y + (t * ballVelocity.y) - ((g * t * t) / 2f); //X(t) = V*t - (g * t^2)/2

        Mz = catchAreaPos.z;

        if (My < 0)
        {
            My = 0f;
        }
        else
        {

        }
        
        

        Dx = Mx - catchAreaPos.x;
        Dy = My - catchAreaPos.y;
        Dz = Mz - catchAreaPos.z;


        Vx = Dx / t;
        Vy = (Dy / t) + ((g * t) / 2); // V(0) = (d/t) + ((g*t)/2)
        Vz = Dz / t;

        Vector3 meetingPos = new Vector3(Mx, My, Mz);
        DateTime dt1 = DateTime.Now;
        
        Debug.Log("t : "+t);
        if(t != float.NegativeInfinity && t!=float.PositiveInfinity)
            dt1 = dt1.AddSeconds(t);
        string meetingTime = dt1.ToString("hh.mm.ss.fffffff");

        Vector3 requiredVelocity = new Vector3(Vx, Vy, Vz);

/*
        Debug.Log("Meeting : " + meetingPos);
        Debug.Log("Meeting Time : " + meetingTime);
        Debug.Log("Vel     : " + requiredVelocity);
*/

        return new Vector3[] { meetingPos, requiredVelocity };

    }







    private static Vector3[] CalculateAllYedek(Goalkeeper goalkeeper)
    {

        Ball ball = Ball.Instance;
        Vector3 ballPos = ball.transform.position;
        Vector3 catchAreaPos = goalkeeper.CatchArea.transform.position;
        Vector3 ballVelocity = ball.Rigidbody.velocity;

        // if ball position y not equal 0 before meeting
        float estimatedMeetingTime = (catchAreaPos.z - ballPos.z) / ballVelocity.z;

        // time of ball position y equal 0
        //  X(t) = 0 when t = (V_y * 2) / g
        float estimatedBallY_ZeroTime = (ballVelocity.y * 2) / (Gravity.GLOBAL_GRAVITY / 0.02f);

        //  CASE - 1 : Ball pos_y > 0 until meeting 
        bool case1;
        //  CASE - 2 : Ball pos_y = 0 before meeting
        bool case2;


        case1 = estimatedBallY_ZeroTime > estimatedMeetingTime;
        case2 = !case1; // it's trivial

        if (case1)
        {
            float t;            //  Time
            float g = (Gravity.GLOBAL_GRAVITY / 0.02f);
            float Mx, My, Mz;   //  Meeting Pos
            float Dx, Dy, Dz;   //  Distance with goalkeeper
            float Vx, Vy, Vz;   //  required velocity of goalkeeper

            t = estimatedMeetingTime;

            Mx = ballPos.x + (t * ballVelocity.x);
            My = ballPos.y + (t * ballVelocity.y) - ((g * t * t) / 2f); //X(t) = V*t - (g * t^2)/2
            Mz = catchAreaPos.z;

            Dx = Mx - catchAreaPos.x;
            Dy = Mz - catchAreaPos.z;
            Dz = 0;

            Vx = Dx / t;
            Vy = (Dy / t) + ((g * t) / 2); // V(0) = (d/t) + ((g*t)/2)
            Vz = 0;

            Vector3 meetingPos = new Vector3(Mx, My, Mz);
            DateTime dt1 = DateTime.Now;
            dt1 = dt1.AddSeconds(t);
            string meetingTime = dt1.ToString("hh.mm.ss.fffffff");

            Vector3 requiredVelocity = new Vector3(Vx, Vy, Vz);

            Debug.Log("CASE - 1");
            Debug.Log("Meeting : " + meetingPos);
            Debug.Log("Time    : " + t + " meeting Time : " + meetingTime);
            Debug.Log("Vel     : " + requiredVelocity);

            return new Vector3[] { meetingPos, requiredVelocity };

        }
        else
        {


            return null;

        }




    }




}
