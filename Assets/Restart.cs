using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : MonoBehaviour
{
    public void OnClickRestart()
    {
        LoadSceneManager.Instance.LoadGameScene();
    }
    public void OnClickTitle()
    {
        LoadSceneManager.Instance.LoadTitleScene();
    }
}
