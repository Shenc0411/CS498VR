using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStimuli : MonoBehaviour
{

    private bool isInit = false;
    private bool isAppear = true;
    private Vector3 RedBallSize, BlueBallOneSize, BlueBallTwoSize;
    private float DisRedBall, DisBlueBallOne, DisBlueBallTwo;
    private float TimeDelay = 0f;
    private bool isChanging = false;

    public Transform CameraLoc;
    public Transform RedBall;
    public Transform BlueBallOne;
    public Transform BlueBallTwo;

    // Use this for initialization
    void Start()
    {
        RedBallSize = RedBall.localScale;
        BlueBallOneSize = BlueBallOne.localScale;
        BlueBallTwoSize = BlueBallTwo.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInit)
        {
            DisRedBall = Vector3.Distance(CameraLoc.position, RedBall.position);
            DisBlueBallOne = Vector3.Distance(CameraLoc.position, BlueBallOne.position);
            DisBlueBallTwo = Vector3.Distance(CameraLoc.position, BlueBallTwo.position);
            if (isAppear)
            {
                if(!isChanging)
                {
                    BlueBallOne.localScale = RedBallSize * (DisBlueBallOne / DisRedBall);
                    BlueBallTwo.localScale = RedBallSize * (DisBlueBallTwo / DisRedBall);
                }
                if (Input.GetKeyDown(KeyCode.S))
                {
                    isAppear = false;
                    RedBall.localScale = new Vector3(0, 0, 0);
                    isChanging = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.S))
                {
                    isAppear = true;
                    RedBall.localScale = RedBallSize;
                    isChanging = true;
                }
            }
            if(isChanging)
            {
                TimeDelay = TimeDelay + Time.deltaTime;
                if (TimeDelay >= 2f){
                    if(!isAppear)
                    {
                        BlueBallOne.localScale = new Vector3(0, 0, 0);
                        BlueBallTwo.localScale = new Vector3(0, 0, 0);
                    }
                    else if(isAppear)
                    {
                        BlueBallOne.localScale = RedBallSize * (DisBlueBallOne / DisRedBall);
                        BlueBallTwo.localScale = RedBallSize * (DisBlueBallTwo / DisRedBall);
                    }
                    TimeDelay = 0f;
                    isChanging = false;
                }
            }
        }else if(Input.GetKeyDown(KeyCode.S))
        {
            isInit = true;
        }
    }
}

