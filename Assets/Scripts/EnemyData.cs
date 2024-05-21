using UnityEngine;
[CreateAssetMenu(fileName = "new enemy Data", menuName = "enmeis")]
public class EnemyData : ScriptableObject
{
    public string enemyName;
    public int damage;
    public int health;
    public int score;
}
