using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HoldKey : MonoBehaviour
{
    public Image ProgressImage;
    public KeyCode _HoldKey;
    public Player _Player;
    public Animator _Controls;

    public enum Player
    {
        PlayerOne, PlayerTwo
    }

    void Update()
    {
        if (Input.GetKey(_HoldKey))
        {
            if (ProgressImage.fillAmount < 1)
            {
                ProgressImage.fillAmount += Time.deltaTime;
            }
            else
            {
                // On Complete Progress
                if (_Player == Player.PlayerOne)
                    Global.PlayerOneReady = true;
                else
                    Global.PlayerTwoReady = true;

                if (Global.PlayerOneReady && Global.PlayerTwoReady)
                {
                    // Both are ready
                    _Controls.Play("Close");
                    gameObject.SetActive(false);
                }
            }
        }
        else
        {
            if (ProgressImage.fillAmount > 0)
            {
                ProgressImage.fillAmount -= Time.deltaTime;
            }

            if (_Player == Player.PlayerOne)
                Global.PlayerOneReady = false;
            else
                Global.PlayerTwoReady = false;
        }
    }

}
