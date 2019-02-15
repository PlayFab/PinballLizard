﻿using UnityEngine;

public class EnemyBehavior : Pausable
{
    public bool WillKeepMoving;
    public bool IsGrabbable;
    public float Rotation;

    private bool isBeingNommed;
    //private Renderer renderer;

    new void Start()
    {
        base.Start();
        IsGrabbable = false;
        WillKeepMoving = true;
        isBeingNommed = false;
        GamePlayEvents.OnTryNom += TryNom;
    }

    private void TryNom(int instanceId)
    {
       if(isBeingNommed == false && gameObject.GetInstanceID() == instanceId)
       {

            isBeingNommed = true;
            GamePlayEvents.SendConfirmNom();
            Invoke("SelfDestruct", 0.2f);
       }
    }

    void Update()
    {
        if (!isPaused)
        {
            transform.RotateAround(gameObject.transform.parent.position, new Vector3(0f, 1f, 0f), Rotation);
        }
    }
    void SelfDestruct()
    {
        Destroy(gameObject);
    }

    new private void OnDestroy()
    {
        GamePlayEvents.OnTryNom -= TryNom;
        base.OnDestroy();
    }
}
