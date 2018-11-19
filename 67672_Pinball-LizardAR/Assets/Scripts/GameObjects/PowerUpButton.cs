﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpButton : Pausable
{
    public enum PowerUp { BREATH, BOMB, SKIP, MAX_POWERUP }
    public PowerUp PowerUpType;
    public Inventory inventory;
    public MouthEatEnemies mouthEatEnemies;
    public BreathWeapon breathWeapon;

    private bool isReadyToConfirm;
    private bool isDisplayingPrice;
    private bool isDisabled;
    new void Start()
    {
        isReadyToConfirm = false;
        isDisplayingPrice = false;
        isDisabled = true;
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused)
        {
            switch (PowerUpType)
            {
                case PowerUp.BREATH:
                    if (inventory.BreathWeaponCount <= 0)
                    {
                        isDisplayingPrice = true;
                    }
                    break;
                case PowerUp.BOMB:
                    if (inventory.InstaBombCount <= 0)
                    {
                        isDisplayingPrice = true;
                    }
                    break;
                case PowerUp.SKIP:
                    if (inventory.SkipCount <= 0)
                    {
                        isDisplayingPrice = true;
                    }
                    break;
            }
            if (isDisplayingPrice)
            {
                if (CheckPrice(PowerUpType) == false)
                {
                    isDisabled = true;
                }
            }
        }
    }

    public void OnClick()
    {
        if (!isPaused)
        {
            if (isDisabled == false)
            {
                if (isReadyToConfirm)
                {
                    switch (PowerUpType)
                    {
                        case PowerUp.BREATH:
                            ActivateBreath();
                            break;
                        case PowerUp.BOMB:
                            ActivateBoom();
                            break;
                        case PowerUp.SKIP:
                            ActivateSkip();
                            break;
                    }
                }
                else
                {
                    isReadyToConfirm = true;
                }
                if (isDisplayingPrice & isReadyToConfirm)
                {
                    Buy(PowerUpType);
                }
            }
        }
    }

    private void ActivateBreath()
    {

    }

    private void ActivateBoom()
    {

    }

    private void ActivateSkip()
    {

    }

    private void Buy(PowerUp powerUpType)
    {
    }

    private bool CheckPrice(PowerUp powerUpType)
    {
        return false;
    }
}
