using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KardasTag;

public class BattleAttackController : MonoBehaviour
{
    [SerializeField] private ShootController shootController;


    public void SetDamage(Transform target)
    {
        if (Mathf.Abs(Vector3.Distance(target.position, this.gameObject.transform.position)) < 1.2f)
        {
            if (this.gameObject.layer == LayerMask.NameToLayer(Tag.ARROW))
            {
                if (target.gameObject.CompareTag(Tag.TARGET))
                {
                    target.gameObject.GetComponent<CharacterHealthController>().SetCharacterHealthDecrease(25f);
                }

                else
                {
                    target.gameObject.GetComponent<TowerHealthController>().SetTowerTakeDamage(65);
                }
            }

            else if (this.gameObject.layer == LayerMask.NameToLayer(Tag.MAGICBALL))
            {
                if (target.gameObject.CompareTag(Tag.TARGET))
                {
                    target.gameObject.GetComponent<CharacterHealthController>().SetCharacterHealthDecrease(65f);
                }

                else
                {
                    target.gameObject.GetComponent<TowerHealthController>().SetTowerTakeDamage(65);
                }
            }
            shootController.SelectTarget(null, false);
        }
    }
}
