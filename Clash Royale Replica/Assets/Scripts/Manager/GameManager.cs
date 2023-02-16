using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    public List<Transform> enemyTowers = new List<Transform>();
    public List<Transform> playerTowers = new List<Transform>();
    public bool isSelect;

    [SerializeField] private UIManager uiManager;


    private void Start()
    {
        Time.timeScale = 1;
        Application.targetFrameRate = 144;
    }



    public void CheckGameEnd(bool isEnemy, bool time)
    {
        Time.timeScale = 0;
        uiManager.SetCrownActive(isEnemy, time);
    }

}
