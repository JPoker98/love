﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController : MonoBehaviour {

    //OtherComponents
    BeatController bc;

    //Gameplay Parameters
    int currentBeat;
    int currentPhase;
    public float toleranceZone;
    public float distanceToPerfect; //from 0 (perfect) to 1 (tolerance Zone)
    public Song currentSong;
    public bool transitionPhase; //first should be true
    public bool toleratesInput;
    public bool solvedBeat; //true if the beat input has ended successfully; will be private
    public bool checkedBeat; //true if the script checked after tolerance; restarst in the beginning of beat. Will be private;
    //Internal Parameters
    float currentTime; //surely won't need it
    float currentBeatTime;
    float lastIterationBeatDuration; //helps to check if we are in a new beat.
    float currentBeatInThisPhase;


    //Song Parameters
    float beatDuration;
    int stepsInBeat;
    int[] beatPerPhase; //Lenght = number of phases;
    int correctHitBeat;

	// Use this for initialization
	public void Start () {
        beatDuration = currentSong.beatDuration;
        stepsInBeat = currentSong.stepsInBeat;
        beatPerPhase = currentSong.beatPerPhase;
        correctHitBeat = currentSong.correctHitBeat;

        lastIterationBeatDuration = 0;
        currentTime = 0;
        currentBeatTime = 0;
        currentBeat = 0;
        currentPhase = 0;
        toleratesInput = false;
	}
	
	// Update is called once per frame
	void Update () {
        currentTime += Time.deltaTime;
        currentBeatTime = currentTime % stepsInBeat;

        if(currentBeatTime >= correctHitBeat*(beatDuration/stepsInBeat)-toleranceZone &&
           currentBeatTime <= correctHitBeat * (beatDuration / stepsInBeat) + toleranceZone)
        {
            distanceToPerfect = Mathf.Abs(correctHitBeat * (beatDuration / stepsInBeat) - currentBeatTime) / (toleranceZone);
            toleratesInput = true;
        }
        else if(currentBeatTime > correctHitBeat * (beatDuration / stepsInBeat) + toleranceZone)
        {
            toleratesInput = false;
            if(!checkedBeat)
            {
                checkedBeat = true;
                if(!solvedBeat)
                {
                    
                }
            }
        }
        else
        {
            toleratesInput = false;
        }

        if (lastIterationBeatDuration > currentBeatTime)  //new beat
        {
            AddBeat();
        }

        lastIterationBeatDuration = currentBeatTime;

    }

    void AddBeat()
    {
        currentBeatInThisPhase++;
        currentBeat++;
        checkedBeat = false;
        solvedBeat = false;

        if (beatPerPhase.Length == currentPhase)
        {
            EndSong();
        }
        if (currentBeatInThisPhase > beatPerPhase[currentPhase])
        {
            currentBeatInThisPhase = 0;
            currentPhase++;
            UpdatePhase(currentPhase);
        }

    }

    void UpdatePhase(int currentPhase)
    {
        toleratesInput = currentSong.toleratesInput[currentPhase];
    }

    void EndSong()
    {

    }
}
