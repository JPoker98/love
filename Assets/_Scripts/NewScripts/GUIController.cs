﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GUIController : MonoBehaviour {

    // #### POLISHED CODE #### 

    public GameManager gm;

    //ScreenElements
    public Animator cameraAnimator;
    public Animator canvasAnimator;

    public Silouette P1Silouette;
    public Silouette P2Silouette;

    public Text score;

    public GameObject bg1;
    public GameObject bg2;
    public Image scoreColor;


    //AudioElements
    public Song currentSong;
    public AudioSource levelMusic;

    public AudioSource P1Audio;
    public AudioSource P2Audio;

    public AudioSource changePhaseAudio;

    public AudioClip[] changePhaseClips;
    public AudioClip gameOverMusic;

    //Pools
    public Sprite[] backgrounds;
    public Pose[] arrows; //up, down, left, right



    // Use this for initialization
    void Start () {
        changePhaseClips = currentSong.changePhaseClips;
        ChooseBackground();
        P1Silouette.playingPose = P1Silouette.idlePose;
        P2Silouette.playingPose = P1Silouette.idlePose;



    }

    public void ChooseBackground() //This method works while backgrounds are static coloured.
    {
        Sprite chosenbg = backgrounds[Random.Range(0, backgrounds.Length)];
        bg1.GetComponent<SpriteRenderer>().sprite = chosenbg;
        bg2.GetComponent<SpriteRenderer>().sprite = chosenbg;
        scoreColor.sprite = chosenbg;
    }

    public void SolveBeat(bool perfect, int currentScore)
    {


        Step step = gm.currentStep;
        StepSO stepSO = gm.currentStepSO;

        P1Silouette.ChangePose(stepSO.pose[0]);
        P2Silouette.ChangePose(stepSO.pose[1]);
        if (stepSO.animationTrigger!=null)
        {
            canvasAnimator.SetTrigger(stepSO.animationTrigger);

        }

        if(stepSO.changeColor)
        {
            ChooseBackground();

        }
        cameraAnimator.SetTrigger("Shake");
        score.text = currentScore.ToString();

        if(perfect)
        {
            //cosas de perfect
        }

    }

    public void GameOverFeedback()
    {

        P2Silouette.ChangePose(P2Silouette.deathPose);
        P2Silouette.nextPose = 9;
        P2Silouette.hasToChange = true;
        levelMusic.Stop();
        levelMusic.clip = gameOverMusic;
        //bso.loop = true;
        levelMusic.Play();

        canvasAnimator.SetTrigger("TryAgain");
        
    }

    public void TryAgainFeedback()
    {
        canvasAnimator.SetTrigger("Restart");
        Start();
    }
    


    public void PlayOrderSound(StepSO step)
    {
        int affectedPlayer = step.affectedPlayers;
        switch (affectedPlayer)
        {
            case 0:
                P1Audio.clip = step.audioStep;
                P1Audio.Play();
                break;
            case 1:
                P2Audio.clip = step.audioStep;
                P2Audio.Play();
                break;
            case 2:
                P1Audio.clip = step.audioStep;
                P1Audio.Play();
                P2Audio.clip = step.audioStep;
                P2Audio.Play();
                break;
        }
    }
    public void PlayOrderSound(Step step) //deprecated
    {
        int affectedPlayer = step.affectedPlayers;
        switch (affectedPlayer)
        {
            case 0:
                P1Audio.clip = step.audioStep;
                P1Audio.Play();
                break;
            case 1:
                P2Audio.clip = step.audioStep;
                P2Audio.Play();
                break;
            case 2:
                P1Audio.clip = step.audioStep;
                P1Audio.Play();
                P2Audio.clip = step.audioStep;
                P2Audio.Play();
                break;
        }

    }
    public void PlayChangePhaseSound(int startingPhase)
    {
        changePhaseAudio.clip = changePhaseClips[startingPhase];
        changePhaseAudio.Play();
    }
           
}



