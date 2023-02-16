using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [Header("Card")]
    public List<GameObject> cardButtons = new List<GameObject>();
    public List<float> buttonAnimationYValues = new List<float>();
    public bool isTouch;
    private float _buttonYSpeed = 0.3f;


    [Header("Other")]
    [SerializeField] private ObjectPoolen setObjectPoolen;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ManaController manaController;



    [Header("End Panel")]
    [SerializeField] private GameObject endGamePanel;
    [SerializeField] private TMP_Text endPanelInfoText;
    public List<GameObject> enemyCrowns = new List<GameObject>();
    public List<GameObject> playerCrowns = new List<GameObject>();
    private int playerCrownIndex;
    private int enemyCrownIndex;



    public void SelectCharacter(int value)
    {
        if (manaController.SetManaProficiency(value))
        {
            setObjectPoolen.SetSelectObject(value);
            gameManager.isSelect = true;
        }

        else
        {
            gameManager.isSelect = false;
        }
    }



    public void SelectButton()
    {
        isTouch = true;
    }

    /// <summary>
    /// For character card animations.
    /// </summary>
    #region CardAnimation
    public void SetButtonMoveUpAnimation(int value)
    {
        SetButtonAnimationDeActive();
        RectTransform buttonRectTransform = cardButtons[value].GetComponent<RectTransform>();
        buttonRectTransform.DOMove(new Vector3(buttonRectTransform.position.x, buttonAnimationYValues[0], buttonRectTransform.position.z), _buttonYSpeed);
    }



    public void SetButtonMoveDownAnimation(int value)
    {
        RectTransform buttonRectTransform = cardButtons[value].GetComponent<RectTransform>();
        buttonRectTransform.DOMove(new Vector3(buttonRectTransform.position.x, buttonAnimationYValues[1], buttonRectTransform.position.z), _buttonYSpeed);
    }
    #endregion


    public void SetButtonAnimationDeActive()
    {
        for (int i = 0; i < cardButtons.Count; i++)
        {
            SetButtonMoveDownAnimation(i);
        }
    }


    /// <summary>
    /// Here I made the crown that will be active when the main tower is destroyed or when the time runs out.
    /// </summary>
    #region EndPanelCrownActive
    public void SetCrownActive(bool isEnemy, bool time)
    {
        endGamePanel.SetActive(true);
        if (!time)
        {
            SetMainTowerDestroyCrown(isEnemy);
        }

        else
        {
            SetEnemyAndPlayerCrownValue();
            SetEnemyAndPlayerCrownValue();
        }
    }


    private void SetMainTowerDestroyCrown(bool isEnemy)
    {
        if (isEnemy)
        {
            endPanelInfoText.text = "WIN";
            for (int i = 0; i < playerCrowns.Count; i++)
            {
                playerCrowns[i].SetActive(true);
            }

            for (int i = 0; i < gameManager.enemyTowers.Count; i++)
            {
                if (!gameManager.playerTowers[i].gameObject.activeSelf)
                {
                    enemyCrownIndex++;
                }
            }

            for (int i = 0; i < enemyCrownIndex; i++)
            {
                enemyCrowns[i].SetActive(true);
            }

        }

        else
        {
            endPanelInfoText.text = "LOSE";

            for (int i = 0; i < enemyCrowns.Count; i++)
            {
                enemyCrowns[i].SetActive(true);
            }

            for (int i = 0; i < gameManager.playerTowers.Count; i++)
            {
                if (!gameManager.enemyTowers[i].gameObject.activeSelf)
                {
                    playerCrownIndex++;
                }
            }

            for (int i = 0; i < playerCrownIndex; i++)
            {
                playerCrowns[i].SetActive(true);
            }
        }
    }



    private void SetEnemyAndPlayerCrownValue()
    {
        for (int i = 0; i < gameManager.enemyTowers.Count; i++)
        {
            if (!gameManager.enemyTowers[i].gameObject.activeSelf)
            {
                playerCrownIndex++;
            }
        }

        for (int i = 0; i < gameManager.playerTowers.Count; i++)
        {
            if (gameManager.playerTowers[i].gameObject.activeSelf)
            {
                enemyCrownIndex++;
            }
        }
        SetEnemyAndPlayerCrownActive();
    }



    private void SetEnemyAndPlayerCrownActive()
    {
        for (int i = 0; i < enemyCrownIndex; i++)
        {
            enemyCrowns[i].SetActive(true);
        }

        for (int i = 0; i < playerCrownIndex; i++)
        {
            playerCrowns[i].SetActive(true);
        }

    }



    private void WinnerTextByCrownValue()
    {
        if (playerCrownIndex > enemyCrownIndex)
        {
            endPanelInfoText.text = "WIN";
        }
        else if (playerCrownIndex == enemyCrownIndex)
        {
            endPanelInfoText.text = "--";
        }
        else
        {
            endPanelInfoText.text = "LOSE";
        }
    }
    #endregion


    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
