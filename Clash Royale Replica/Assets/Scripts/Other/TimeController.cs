using System.Collections;
using UnityEngine;
using TMPro;

public class TimeController : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private ManaController manaController;
    [SerializeField] private EnemySpawnController enemySpawnController;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private float timeStep;


    private int _second = 45;
    private int _minute = 2;
    private bool _isComplete;



    private void Start()
    {
        StartCoroutine(nameof(SetTime));
    }


    /// <summary>
    /// To reduce the time with the speed I set.
    /// </summary>
    public IEnumerator SetTime()
    {
        while (true)
        {
            if (_isComplete)
                break;
            DescraseSecond();
            SetTimeTextValues();
            yield return new WaitForSeconds(timeStep);
        }
    }



    private void SetEnemySpawnTime()
    {
        if (GetShortTime())
        {
            enemySpawnController.timeStep = 2.5f;
            manaController.timeStep = 1f;
        }
    }



    private bool GetShortTime()
    {
        return _minute == 0;
    }


    private void DescraseSecond()
    {
        _second--;

        if (_second <= 0)
        {
            _second = 60;
            DecreaseMinute();
        }
    }



    private void DecreaseMinute()
    {
        _minute--;
        SetEnemySpawnTime();
        if (_minute < 0)
        {
            _isComplete = true;
            _minute = 0;
            _second = 0;
            gameManager.CheckGameEnd(false, true);
        }

    }



    private void SetTimeTextValues()
    {
        timerText.text = _minute.ToString("00") + " : " + _second.ToString("00");
    }
}
