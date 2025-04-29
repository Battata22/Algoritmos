using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    [SerializeField] float _distSpawneo;
    [SerializeField] float _spawnerCooldown;
    [SerializeField] ParticleSystem _part;
    float distMinimaSpawneo = 0.5f;
    float waitSpawner;

    [SerializeField] RollerBehaivour _roller;
    ObjectPool<Enemy> _poolEnemies;

    private void Awake()
    {
        _poolEnemies = new ObjectPool<Enemy>(SpawnRoller, RollerOn, RollerOff, 5);
    }

    void Start()
    {
        _part = GetComponentInChildren<ParticleSystem>();
    }

    
    void Update()
    {
        waitSpawner += Time.deltaTime;
        Spawn();
    }

    void Spawn()
    {
        if (waitSpawner >= _spawnerCooldown)
        {
            var enemy = _poolEnemies.Get();
            waitSpawner = 0;
            _part.Play();
        }
    }

    Enemy SpawnRoller()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        return Instantiate(_roller, new Vector3(x + Random.Range(-_distSpawneo, _distSpawneo), y + Random.Range(-_distSpawneo, _distSpawneo), z + Random.Range(-_distSpawneo, _distSpawneo)), Quaternion.identity);
    }

    void RollerOn(Enemy roller)
    {
        roller.gameObject.SetActive(true);
        roller.Recicle(_poolEnemies);
    }

    void RollerOff(Enemy roller)
    {
        roller.gameObject.SetActive(false);
        //por las dudas
        roller.Recicle(_poolEnemies);
    }

}
