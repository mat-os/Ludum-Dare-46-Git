using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntitiesControler : MonoBehaviour
{
    public List <GameObject> enemiesList = new List<GameObject>();
    public List <GameObject> humansList = new List<GameObject>();

    public delegate void MethodContainer();
    public event MethodContainer AddNewEnemyEvent;

    public void AddNewEnemy(GameObject enemyEntity)
    {
        enemiesList.Add(enemyEntity);
        AddNewEnemyEvent.Invoke();
    }
}
