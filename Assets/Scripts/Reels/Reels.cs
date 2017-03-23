﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reels : MonoBehaviour
{

    public delegate void ReelsHandler(); 
    public event ReelsHandler OnReelsFullStop;

    // Reels components
    public Reel[] reels;
    private Reel currentReel;
    private Reel reel1, reel2, reel3;


    // Initialize Reels components
    void Awake()
    {
        reel1 = reels[0];
        reel2 = reels[1];
        reel3 = reels[2];

        // Add Stop handlers to the event of each reel
        reel1.OnFullStop += CompleteStopHandler;
        reel2.OnFullStop += CompleteStopHandler;
        reel3.OnFullStop += CompleteStopHandler;
    }


    // Set up the spin idle animation for the reels
    private void SpinReels()
    { 
        for (int i = 0; i < reels.Length; i++)
        {
            currentReel = reels[i];
            currentReel.Spin();
        } 
    } 


    // Set up the landing and stop animation for the reels
    private void StopReels()
    {
        bool fullStop = false;
        for (int i = 0; i < reels.Length; i++)
        { 
            currentReel = reels[i];
            currentReel.Stop(); 
        } 
    }


    // Handler when all reels have stopped 
    private void CompleteStopHandler()
    { 
        // Dispatch Full Stop event
        if (OnReelsFullStop != null)
        {
            OnReelsFullStop();
        }
        else
        {
            Debug.Log("FullStop event is null");
        }
    }
    

    // Unubscribe handlers from events
    void OnDisable()
    {
        reel1.OnFullStop -= CompleteStopHandler;
        reel2.OnFullStop -= CompleteStopHandler;
        reel3.OnFullStop -= CompleteStopHandler;
    }


    // PUBLIC METHODS
    public void Spin()
    {
        SpinReels();
    }

    public void Stop()
    {
        StopReels(); 
    } 
}
