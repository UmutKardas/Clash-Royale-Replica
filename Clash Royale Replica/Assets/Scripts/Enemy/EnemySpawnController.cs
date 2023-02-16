using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private ObjectPoolen objectPoolen;
    private GameObject _selectEnemyCharacter;
    private int _randomCharacterIndex;
    public float timeStep;


    [Header("Spawn Transform")]
    private int _randomTransformXValue;
    private int _randomTransformZValue;


    [Header("Character Transform")]
    private float _characterPositionY = 2f;
    private float _characterRotationY = 180f;


    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeStep);
            SpawnEnemyObject();
        }
    }



    private void SpawnEnemyObject()
    {
        _randomCharacterIndex = Random.Range(objectPoolen.poolCharacterObjects.Length / 2, objectPoolen.poolCharacterObjects.Length);
        _selectEnemyCharacter = objectPoolen.poolCharacterObjects[_randomCharacterIndex].poolList[objectPoolen.poolCharacterObjects[_randomCharacterIndex].index].gameObject;
        SetEnemyTransform(_selectEnemyCharacter);
        _selectEnemyCharacter.GetComponent<CharacterMovementController>().CharacterSpawn();
        _selectEnemyCharacter.GetComponent<CharacterMovementController>().characterType = CharacterMovementController.CharacterType.Enemy;
        objectPoolen.poolCharacterObjects[_randomCharacterIndex].index++;

        if (objectPoolen.poolCharacterObjects[_randomCharacterIndex].index == objectPoolen.poolCharacterObjects[_randomCharacterIndex].maxCount)
        {
            objectPoolen.poolCharacterObjects[_randomCharacterIndex].index = 0;
        }
    }



    private void SetEnemyTransform(GameObject enemyObject)
    {
        _randomTransformXValue = Random.Range(-6, 7);
        _randomTransformZValue = Random.Range(11, 18);
        enemyObject.transform.eulerAngles = new Vector3(enemyObject.transform.rotation.x, _characterRotationY, enemyObject.transform.rotation.z);
        enemyObject.transform.position = new Vector3(_randomTransformXValue, _characterPositionY, _randomTransformZValue);

        enemyObject.SetActive(true);
    }
}
