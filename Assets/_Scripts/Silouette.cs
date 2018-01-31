﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Silouette : MonoBehaviour
{

    public Player _player;
    public GameManager _gameManager;
    public SpriteMask _playerMask;
    public Animator animator;
    float time;

    public int currentPose;
    public int nextPose;
    public bool hasToChange;
    public bool isIdle;

    public Sprite[] currentInitAnimation;
    public Sprite[] currentIdleAnimation;
    public Sprite[] currentReturnAnimation;
    public int currentStatus; //will be private. 0 = init; 1= idle; 2=return;
    public int currentSprite;


    public float timeBetweenSprites;

    void Start()
    {
        currentInitAnimation = new Sprite[_player.Pose0Idle.Length];
        _player.Pose0Idle.CopyTo(currentInitAnimation, 0);

        currentIdleAnimation = new Sprite[_player.Pose0Idle.Length];
        _player.Pose0Idle.CopyTo(currentIdleAnimation, 0);

        currentReturnAnimation = new Sprite[_player.Pose0Idle.Length];
        _player.Pose0Idle.CopyTo(currentReturnAnimation, 0);
        currentSprite = 0;
        time = 0;

    }

    void Update()
    {
        time += Time.deltaTime;
        if (hasToChange)
        {
            ChangePose(nextPose);
        }
        if (time > timeBetweenSprites)
        {
            time -= timeBetweenSprites;
            ChangeSprite();
        }
    }

    void ChangeSprite()
    {
        switch (currentStatus)
        {
            case 0: //Init Animation
                if (currentInitAnimation.Length == 0) return;
                _playerMask.sprite = currentInitAnimation[currentSprite];
                currentSprite++;
                currentSprite %= currentInitAnimation.Length;
                if (currentSprite == 0)
                {
                    currentStatus++;
                }
                break;
            case 1: //Idle Animation
                isIdle = true;
                _playerMask.sprite = currentIdleAnimation[currentSprite];
                currentSprite++;
                currentSprite %= currentIdleAnimation.Length;
             
                break;
            case 2: //Return Animation
                _playerMask.sprite = currentReturnAnimation[currentSprite];
                currentSprite++;
                currentSprite %= currentReturnAnimation.Length;
                if (currentSprite == 0)
                {
                    currentStatus = 0;
                    currentSprite = 0;
                    ChangeReturn(nextPose);
                }
                break;
        }

    }

    void ChangePose(int pose)
    {
        hasToChange = false;
        isIdle = false;
        currentSprite = 0;
        currentStatus = 2;
        ChangeIdle(nextPose);
        if (nextPose != currentPose) //else, let same Sprite[]
        {
            switch (pose)
            {
                case 1:
                    currentInitAnimation = new Sprite[_player.Pose1.Length];
                    _player.Pose1.CopyTo(currentInitAnimation, 0);
                    break;
                case 2:
                    currentInitAnimation = new Sprite[_player.Pose2.Length];
                    _player.Pose2.CopyTo(currentInitAnimation, 0);
                    break;
                case 3:
                    currentInitAnimation = new Sprite[_player.Pose3.Length];
                    _player.Pose3.CopyTo(currentInitAnimation, 0);
                    break;
                case 4:
                    currentInitAnimation = new Sprite[_player.Pose4.Length];
                    _player.Pose4.CopyTo(currentInitAnimation, 0);
                    break;
                case 5:
                    currentInitAnimation = new Sprite[_player.Pose5.Length];
                    _player.Pose5.CopyTo(currentInitAnimation, 0);
                    break;
                case 6:
                    currentInitAnimation = new Sprite[_player.Pose6.Length];
                    _player.Pose6.CopyTo(currentInitAnimation, 0);
                    break;
                case 7:
                    currentInitAnimation = new Sprite[_player.Pose7.Length];
                    _player.Pose7.CopyTo(currentInitAnimation, 0);
                    break;
                case 8:
                    currentInitAnimation = new Sprite[_player.Pose8.Length];
                    _player.Pose8.CopyTo(currentInitAnimation, 0);
                    break;
                case 9:
                    currentInitAnimation = new Sprite[_player.Pose9.Length];
                    _player.Pose9.CopyTo(currentInitAnimation, 0);
                    break;
            }
        }
    } //First change, happens when triggered. Turns hasToChange = true

    void ChangeIdle(int pose)
    {
        if (nextPose != currentPose) //else, let same Sprite[]
        {
            switch (pose)
            {
                case 1:
                    currentIdleAnimation = new Sprite[_player.Pose1Idle.Length];
                    _player.Pose1Idle.CopyTo(currentIdleAnimation, 0);
                    break;
                case 2:
                    currentIdleAnimation = new Sprite[_player.Pose2Idle.Length];
                    _player.Pose2Idle.CopyTo(currentIdleAnimation, 0);
                    break;
                case 3:
                    currentIdleAnimation = new Sprite[_player.Pose3Idle.Length];
                    _player.Pose3Idle.CopyTo(currentIdleAnimation, 0);
                    break;
                case 4:
                    currentIdleAnimation = new Sprite[_player.Pose4Idle.Length];
                    _player.Pose4Idle.CopyTo(currentIdleAnimation, 0);
                    break;
                case 5:
                    currentIdleAnimation = new Sprite[_player.Pose5Idle.Length];
                    _player.Pose5Idle.CopyTo(currentIdleAnimation, 0);
                    break;
                case 6:
                    currentIdleAnimation = new Sprite[_player.Pose6Idle.Length];
                    _player.Pose6Idle.CopyTo(currentIdleAnimation, 0);
                    break;
                case 7:
                    currentIdleAnimation = new Sprite[_player.Pose7Idle.Length];
                    _player.Pose7Idle.CopyTo(currentIdleAnimation, 0);
                    break;
                case 8:
                    currentIdleAnimation = new Sprite[_player.Pose8Idle.Length];
                    _player.Pose8Idle.CopyTo(currentIdleAnimation, 0);
                    break;
                case 9:
                    currentIdleAnimation = new Sprite[_player.Pose9Idle.Length];
                    _player.Pose9Idle.CopyTo(currentIdleAnimation, 0);
                    break;

            }
        }
    } //Second change, happens when goes out from Idle

    void ChangeReturn(int pose) //Last change, turns nextPose into currentPose;
    {
        if (nextPose != currentPose) //else, let same Sprite[]
        {
            switch (pose)
            {
                case 1:
                    currentReturnAnimation = new Sprite[_player.Pose1Transition.Length];
                    _player.Pose1Transition.CopyTo(currentReturnAnimation, 0);
                    break;
                case 2:
                    currentReturnAnimation = new Sprite[_player.Pose2Transition.Length];
                    _player.Pose2Transition.CopyTo(currentReturnAnimation, 0);
                    break;
                case 3:
                    currentReturnAnimation = new Sprite[_player.Pose3Transition.Length];
                    _player.Pose3Transition.CopyTo(currentReturnAnimation, 0);
                    break;
                case 4:
                    currentReturnAnimation = new Sprite[_player.Pose4Transition.Length];
                    _player.Pose4Transition.CopyTo(currentReturnAnimation, 0);
                    break;
                case 5:
                    currentReturnAnimation = new Sprite[_player.Pose5Transition.Length];
                    _player.Pose5Transition.CopyTo(currentReturnAnimation, 0);
                    break;
                case 6:
                    currentReturnAnimation = new Sprite[_player.Pose6Transition.Length];
                    _player.Pose6Transition.CopyTo(currentReturnAnimation, 0);
                    break;
                case 7:
                    currentReturnAnimation = new Sprite[_player.Pose7Transition.Length];
                    _player.Pose7Transition.CopyTo(currentReturnAnimation, 0);
                    break;
                case 8:
                    currentReturnAnimation = new Sprite[_player.Pose8Transition.Length];
                    _player.Pose8Transition.CopyTo(currentReturnAnimation, 0);
                    break;
                case 9:
                    currentReturnAnimation = new Sprite[_player.Pose9Transition.Length];
                    _player.Pose9Transition.CopyTo(currentReturnAnimation, 0);
                    break;
            }
        }
        currentPose = nextPose;

        
    }
}
