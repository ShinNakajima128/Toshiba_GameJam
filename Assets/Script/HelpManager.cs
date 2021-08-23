using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelpManager : MonoBehaviour
{
    [Header("テキスト表示用")]
    [SerializeField] Text m_help = default;
    [Header("ゲーム説明用のテキスト")]
    [SerializeField, TextArea(1,3)] string[] m_helpTexts = default;
    [Header("ゲーム説明用の画像")]
    [SerializeField] Image[] m_helpImages = default;
    [Header("ヘルプ画面の右のボタン")]
    [SerializeField] GameObject m_rightButton = default;
    [Header("ヘルプ画面の左のボタン")]
    [SerializeField] GameObject m_leftButton = default;
    int currentType = 0;


    private void OnEnable()
    {
        currentType = 0;
        ChangeContents(currentType);
        m_leftButton.SetActive(false);
        m_rightButton.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            float x = Input.GetAxisRaw("Horizontal");

            ChangeHelpState((int)x);
        }
    }

    public void ChangeHelpState(int buttonType)
    {
        SoundManager.Instance.PlaySeByName("5_1_select");

        if (buttonType == -1)
        {
            if (currentType > 0)
            {
                currentType--;
                ChangeContents(currentType);

                if (currentType == 0)
                {
                    m_leftButton.SetActive(false);
                }
                else if (currentType == m_helpImages.Length - 2)
                {
                    m_rightButton.SetActive(true);
                }
            }
        }
        else if (buttonType == 1)
        {
            if (currentType < m_helpImages.Length - 1)
            {
                currentType++;
                ChangeContents(currentType);

                if (currentType == m_helpImages.Length - 1)
                {
                    m_rightButton.SetActive(false);
                }
                else if (currentType == 1)
                {
                    m_leftButton.SetActive(true);
                }
            }
        }
    }


    void ChangeContents(int index)
    {
        Debug.Log(index);

        for (int i = 0; i < m_helpImages.Length; i++)
        {
            if (i == index)
            {
                m_helpImages[i].enabled = true;
            }
            else
            {
                m_helpImages[i].enabled = false;
            }
        }

        for (int i = 0; i < m_helpTexts.Length; i++)
        {
            if (i == index)
            {
                m_help.text = m_helpTexts[i];
                return;
            }
        }
    }
}
