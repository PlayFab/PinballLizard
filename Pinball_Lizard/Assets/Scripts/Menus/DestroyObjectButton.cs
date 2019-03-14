﻿using UnityEngine;
using UnityEngine.UI;

public class DestroyObjectButton : MonoBehaviour
{
    public GameObject ObjectToDestroy;
    public Button OnPress;

    void Start()
    {
        OnPress.onClick.AddListener(DestroyObject);
    }

    void Update()
    {

    }
    void DestroyObject()
    {
        Destroy(ObjectToDestroy);
    }
}