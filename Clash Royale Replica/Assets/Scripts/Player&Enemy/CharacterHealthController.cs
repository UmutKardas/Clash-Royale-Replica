using UnityEngine;
using DG.Tweening;

public class CharacterHealthController : MonoBehaviour
{
    public float characterHealthValue = 100;

    [SerializeField] private GameObject healtBar;
    private float _maxCount = 100;
    private Vector3 _currentLerp = Vector3.one;
    private float _duration = 1;


    private void OnEnable()
    {
        _currentLerp = Vector3.one;
        healtBar.transform.parent.gameObject.SetActive(false);
    }



    public void SetCharacterHealthDecrease(float value)
    {
        characterHealthValue -= value;
        healtBar.transform.parent.gameObject.SetActive(true);
        SetManaSlider();
        CheckDead();
    }



    public void CheckDead()
    {
        if (characterHealthValue <= 0)
        {
            characterHealthValue = 100;
            this.gameObject.SetActive(false);
        }
    }



    private void SetManaSlider()
    {
        DOTween.To(() => _currentLerp, x => _currentLerp = x, new Vector3(healtBar.transform.localScale.x, characterHealthValue / _maxCount, healtBar.transform.localScale.z), _duration)
       .OnUpdate(() =>
      {
          healtBar.transform.localScale = _currentLerp;
      });
    }
}