using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AddTextAboveEnemy : MonoBehaviour
{
    private EnemyData enemyData;
    [SerializeField] private TextMeshProUGUI textPlaceholder;

    // Start is called before the first frame update
    void Start()
    {

        enemyData = GetComponentInParent<EnvironmentMover>().enemyData;
        if (enemyData == null) return;
        textPlaceholder.text = enemyData.enemyName + " " + enemyData.health;

    }


}
