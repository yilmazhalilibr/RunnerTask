using RunnerTask.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.Managers
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] SpawnController[] _spawnControllers;

        private void OnEnable()
        {
            for (int i = 0; i < _spawnControllers.Length; i++)
            {
                _spawnControllers[i].OnSpawnObject += IncreaseSpawnTime;
            }
        }
        private void OnDisable()
        {
            for (int i = 0; i < _spawnControllers.Length; i++)
            {
                _spawnControllers[i].OnSpawnObject -= IncreaseSpawnTime;
            }
        }

        private void IncreaseSpawnTime()
        {
            for (int i = 0; i < _spawnControllers.Length; i++)
            {
                _spawnControllers[i].ExtraSpawnTime += 5f;
            }
        }

    }
}

