using UnityEngine;
using DG.Tweening;


public class TowerHealthController : MonoBehaviour
{
    public bool isEnemyTower;
    public bool isMainTower;
    public float towerHealt;

    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject healtBar;
    private Vector3 _currentLerp = Vector3.one;
    private float _duration = 1;
    private float _maxCount = 500;


    public void SetTowerTakeDamage(float value)
    {
        towerHealt -= value;
        healtBar.transform.parent.gameObject.SetActive(true);
        SetTowerDeActive();
        SetManaSlider();
    }



    private void SetTowerDeActive()
    {
        if (towerHealt <= 0)
        {
            if (isMainTower)
            {
                gameManager.CheckGameEnd(isEnemyTower, false);
            }

            this.gameObject.SetActive(false);
        }
    }



    private void SetManaSlider()
    {
        DOTween.To(() => _currentLerp, x => _currentLerp = x, new Vector3(healtBar.transform.localScale.x, towerHealt / _maxCount, healtBar.transform.localScale.z), _duration)
        .OnUpdate(() =>
       {
           healtBar.transform.localScale = _currentLerp;
       });
    }
}
