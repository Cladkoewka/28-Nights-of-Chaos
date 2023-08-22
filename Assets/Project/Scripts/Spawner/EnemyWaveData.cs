using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Wave", menuName = "Enemy Wave")]
public class EnemyWaveData : ScriptableObject
{
    public Enemy[] Enemies;
    public float SpawnInterval;
    public int EnemiesCount;
}
