﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using PlayFab.Json;
using System;
using Microsoft.AppCenter.Unity.Crashes;


public class Events : MonoBehaviour
{

    // Use this for initialization
    void Awake()
    {
        TrackingEvents.OnPlayFabTitleEvent += SendTitleEvent;
        TrackingEvents.OnPlayFabPlayerEvent += SendPlayerEvent;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SendTitleEvent(Dictionary<string, object> eventBody, string eventTitle)
    {
        PlayFabClientAPI.WriteTitleEvent(
            new WriteTitleEventRequest()
            {
                Body = eventBody,
                EventName = eventTitle,
                Timestamp = DateTime.Now
            },
            (result) =>
            {

            },
            (error) =>
            {
                Debug.Log(error.ErrorMessage);
#if UNITY_ANDROID
                //Crashes on iOS every single time without fail
                Crashes.TrackError(new Exception(error.ErrorMessage));
#endif
            }
       );
    }

    public void SendPlayerEvent(Dictionary<string, object> eventBody, string eventTitle)
    {
        PlayFabClientAPI.WritePlayerEvent(
            new WriteClientPlayerEventRequest()
            {
                Body = eventBody,
                EventName = eventTitle,
                Timestamp = DateTime.Now
            },
            (result) =>
            {

            },
            (error) =>
            {
                Debug.Log(error.ErrorMessage);
#if UNITY_ANDROID
                //Crashes on iOS every single time without fail
                Crashes.TrackError(new Exception(error.ErrorMessage));
#endif
            }
       );
    }

    private void OnDestroy()
    {
        TrackingEvents.OnPlayFabTitleEvent -= SendTitleEvent;
        TrackingEvents.OnPlayFabPlayerEvent -= SendPlayerEvent;
    }
}