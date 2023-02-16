using System;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolen : MonoBehaviour
{
    [HideInInspector] public GameObject selectPlayerCharacter;
    [HideInInspector] public int characterCardValue;
    public GameObject selectBattleObject;

    public PoolCharacterObjects[] poolCharacterObjects;
    public PoolBattleObjects[] poolBattleObjects;



    private void Awake()
    {
        GeneratePlayerObject();
        GenerateEnemyObject();
        GenerateBattleObject();
    }



    public void SetSelectObject(int value)
    {

        characterCardValue = value;
        selectPlayerCharacter = poolCharacterObjects[value].poolList[poolCharacterObjects[value].index].gameObject;
        selectPlayerCharacter.GetComponent<CharacterMovementController>().CharacterSpawn();
        poolCharacterObjects[value].index++;

        if (poolCharacterObjects[value].index == poolCharacterObjects[value].maxCount)
        {
            poolCharacterObjects[value].index = 0;
        }
    }



    /// <summary>
    /// With a dynamic object pool I create it only once and use it continuously
    /// </summary>
    #region  GenerateObject
    public void GeneratePlayerObject()
    {
        for (int i = 0; i < poolCharacterObjects.Length / 2; i++)
        {
            for (int k = 0; k < poolCharacterObjects[i].maxCount; k++)
            {
                GameObject clone = Instantiate(poolCharacterObjects[i].objectPrefab);
                poolCharacterObjects[i].poolList.Add(clone);
                clone.SetActive(false);
            }
        }
    }



    public void GenerateEnemyObject()
    {
        for (int i = poolCharacterObjects.Length / 2; i < poolCharacterObjects.Length; i++)
        {
            for (int k = 0; k < poolCharacterObjects[i].maxCount; k++)
            {
                GameObject clone = Instantiate(poolCharacterObjects[i].objectPrefab);
                poolCharacterObjects[i].poolList.Add(clone);
                clone.SetActive(false);
            }
        }
    }



    public void GenerateBattleObject()
    {
        for (int i = 0; i < poolBattleObjects.Length; i++)
        {
            for (int k = 0; k < poolBattleObjects[i].maxCount; k++)
            {
                GameObject clone = Instantiate(poolBattleObjects[i].objectPrefab);
                poolBattleObjects[i].poolBattleList.Add(clone);
                clone.SetActive(false);
            }
        }
    }
    #endregion



    public void SetSelectBattleObject(int value, Transform spawnTransform, Transform targetRansform)
    {
        selectBattleObject = poolBattleObjects[value].poolBattleList[poolBattleObjects[value].index].gameObject;
        selectBattleObject.SetActive(true);
        selectBattleObject.transform.position = spawnTransform.position;
        selectBattleObject.GetComponent<ShootController>().SelectTarget(targetRansform, true);
        poolBattleObjects[value].index++;
        if (poolBattleObjects[value].index == poolBattleObjects[value].maxCount)
        {
            poolBattleObjects[value].index = 0;
        }
    }
}



[Serializable]
public class PoolCharacterObjects
{
    public List<GameObject> poolList = new List<GameObject>();
    public GameObject objectPrefab;
    public int maxCount;
    public int index;
}



[Serializable]
public class PoolBattleObjects
{
    public List<GameObject> poolBattleList = new List<GameObject>();
    public GameObject objectPrefab;
    public int maxCount;
    public int index;
}
