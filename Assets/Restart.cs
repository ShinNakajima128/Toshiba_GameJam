﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void OnClickRestart()
    {
        AIwindowManager.Instance.ChangeAIByState(AIState.Retry);
        StartCoroutine(OnRestart());
    }

    public void GameStart()
    {
        LoadSceneManager.Instance.LoadGameScene();
    }

    public void OnClickTitle()
    {
        LoadSceneManager.Instance.LoadTitleScene();
    }

    public void OnGallery()
    {
        LoadSceneManager.Instance.LoadGallery();
    }

    IEnumerator OnRestart()
    {
        yield return new WaitForSeconds(1.5f);

        LoadSceneManager.Instance.LoadGameScene();
    }
}
