using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using KardasTag;

public class CharacterMovementController : MonoBehaviour
{
    [SerializeField] private CharacterDataTransmitter characterDataTransmitter;
    public List<Transform> towers = new List<Transform>();
    public Transform _targetTranform;
    public CharacterType characterType;

    private GameManager _gameManager;
    private bool _isTowerSelect;
    private bool _isTargetSelect;
    private float _distance;
    private float _targetDistance;

    NavMeshAgent navMeshAgent;


    private void Start()
    {
        CharacterSpawn();
    }



    public void CharacterSpawn()
    {
        GetComponentValues();
        SelectTowerTarget();
    }


    #region TargetTower

    /// <summary>
    ///  Choosing the closest from certain enemy towers.
    /// </summary>
    public void SelectTowerTarget()
    {
        GetTowerTransform();
        for (int i = 0; i < towers.Count; i++)
        {
            _distance = Vector3.Distance(this.gameObject.transform.position, towers[i].localPosition);
            if (_targetTranform != null)
            {
                _targetDistance = Vector3.Distance(this.gameObject.transform.position, towers[i - 1].localPosition);
                if (characterType == CharacterType.Player)
                {
                    if (Mathf.Abs(_targetDistance) < Mathf.Abs(_distance))
                    {
                        _targetTranform = towers[i];
                    }
                }

                else
                {
                    if (Mathf.Abs(_targetDistance) > Mathf.Abs(_distance))
                    {
                        _targetTranform = towers[i];
                    }
                }
            }

            else
            {
                _targetTranform = towers[i];
            }
        }

        _isTowerSelect = true;
    }


    /// <summary>
    ///  Selecting based on the active of certain enemy strongholds.
    /// </summary>
    private void GetTowerTransform()
    {
        characterDataTransmitter.GetAttackAnimationActive(false);
        towers.Clear();
        navMeshAgent.enabled = true;
        _targetTranform = null;
        _isTowerSelect = false;

        if (characterType == CharacterType.Player)
        {
            for (int i = 0; i < _gameManager.enemyTowers.Count; i++)
            {
                if (_gameManager.enemyTowers[i].gameObject.activeSelf)
                {
                    towers.Add(_gameManager.enemyTowers[i]);
                }
            }
        }

        else
        {
            for (int i = 0; i < _gameManager.playerTowers.Count; i++)
            {
                if (_gameManager.playerTowers[i].gameObject.activeSelf)
                {
                    towers.Add(_gameManager.playerTowers[i]);
                }
            }
        }
    }
    #endregion


    private void GetComponentValues()
    {
        navMeshAgent = this.gameObject.GetComponent<NavMeshAgent>();
        _gameManager = GameObject.FindGameObjectWithTag(Tag.GAMEMANAGER).GetComponent<GameManager>();
    }



    public void SetTargetCharacter(Transform targetTransform)
    {
        characterDataTransmitter.GetAttackAnimationActive(true);
        _targetTranform = targetTransform;
        navMeshAgent.enabled = false;
        _isTowerSelect = false;
        _isTargetSelect = true;
    }



    void Update()
    {
        SetCharacterMove();
        SetCharacterLookatTarget();
    }



    private void SetCharacterMove()
    {
        if (_isTowerSelect && _targetTranform != null)
        {
            if (_targetTranform.gameObject.activeSelf)
            {
                navMeshAgent.SetDestination(_targetTranform.position);
            }
            else
            {
                _isTowerSelect = false;
                SelectTowerTarget();
            }
        }
    }



    private void SetCharacterLookatTarget()
    {
        if (_isTargetSelect && _targetTranform != null)
        {
            if (_targetTranform.gameObject.activeSelf)
            {
                this.gameObject.transform.LookAt(_targetTranform);
            }

            else
            {
                _isTargetSelect = false;
                SelectTowerTarget();
            }
        }
    }



    public enum CharacterType : int
    {
        Enemy,
        Player
    }
}
