using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;


public class ManaController : MonoBehaviour
{
    [HideInInspector] public float manaCount = 4;
    public bool isComplete;

    [SerializeField] private CardDataController cardDataController;
    [SerializeField] private Image manaSlider;
    [SerializeField] private TMP_Text manaText;
    public float timeStep;

    private float _maxCount = 10;
    private float _currentTime;
    private float _currentLerp;
    private float _duration = 1;


    private void Update()
    {
        SetManaTime();
    }

    /// <summary>
    /// Mana accumulation over a period of time.
    /// </summary>

    private void SetManaTime()
    {
        if (!isComplete)
        {
            if (_currentTime <= 0)
            {
                _currentTime = timeStep;

                if (manaCount < 10)
                    IncreaseManaCount();
            }

            else
            {
                _currentTime -= Time.deltaTime;
            }
        }
    }



    private void IncreaseManaCount()
    {
        manaCount++;
        if (manaCount >= 10)
        {
            isComplete = true;
        }
        SetManaSlider();
    }



    public bool SetManaProficiency(int characterValue)
    {
        return manaCount >= cardDataController.GetCharacterValue(characterValue);
    }



    public void DescreaManaCount(int characterValue)
    {
        manaCount -= cardDataController.GetCharacterValue(characterValue);
        SetManaSlider();
        isComplete = false;
    }



    private void SetManaSlider()
    {
        manaText.text = manaCount.ToString();
        DOTween.To(() => _currentLerp, x => _currentLerp = x, manaCount / _maxCount, _duration).OnUpdate(() =>
        {
            manaSlider.fillAmount = _currentLerp;
        });

    }
}
