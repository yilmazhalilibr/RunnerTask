using RunnerTask.Abstracts.Controllers;
using RunnerTask.Patterns;
using System.Collections;
using UnityEngine;

namespace RunnerTask.Controllers
{
    public class SpawnController : Controller
    {
        [Header("Spawn Properties")]
        [SerializeField] float _spawnTime;
        [SerializeField] float _spawnMaxTime;
        [Header("Game Object Prefabs Of The Object Pool")]
        [SerializeField] GameObject[] _instantiateObjects;

        private bool _canSpawn = true;

        ObjectPool _pool;
        WaitForSeconds _waitForSecond;

        public bool CanSpawn { get { return _canSpawn; } set { _canSpawn = value; } }
        private void Awake()
        {
            _pool = new ObjectPool(gameObject, _instantiateObjects);
            _waitForSecond = new WaitForSeconds(_spawnTime);

            StartCoroutine(Spawn());
        }

        IEnumerator Spawn()
        {
            while (CanSpawn)
            {
                yield return _pool.GetRandomPoolObject();
                yield return _waitForSecond;
            }
            _waitForSecond = new WaitForSeconds(Random.Range(1.5f, _spawnMaxTime));

        }


    }
}

