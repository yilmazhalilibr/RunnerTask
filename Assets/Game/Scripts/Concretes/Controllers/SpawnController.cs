using RunnerTask.Abstracts.Controllers;
using RunnerTask.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.Controllers
{
    public class SpawnController : Controller
    {
        [Header("Single Object Pool")]
        [SerializeField] float _spawnInterval = .3f;
        [SerializeField] int _poolSize = 20;
        [SerializeField] GameObject _objectPrefab;
        [SerializeField] bool _singleType;

        [Header("Multiple Object Pool")]
        [SerializeField] float _spawnMinTime;
        [SerializeField] float _spawnMaxTime;
        [SerializeField] GameObject[] _objectPrefabs;

        WaitForSeconds _waitForSecond;
        ObjectPool _objectPool;

        public event System.Action OnSpawnObject;

        public override bool SingleType => _singleType;
        public float ExtraSpawnTime { get; set; }

        private void Awake()
        {
            if (_singleType)
            {
                _objectPool = new ObjectPool(this, _objectPrefab, _poolSize);
            }
            else
            {
                _objectPool = new ObjectPool(this, _objectPrefabs);
            }

        }

        private void Start()
        {
            if (SingleType)
            {
                _waitForSecond = new WaitForSeconds(_spawnInterval);
                StartCoroutine(SpawnRoutine());
            }
            else
            {
                StartCoroutine(SpawnRoutineRandom());
            }
            if (SingleType) return;
            StartCoroutine(ObjectCheckTransform());

        }
        private void OnValidate()
        {
            if (SingleType)
            {
                _spawnMinTime = 0;
                _spawnMaxTime = 0;
                _objectPrefabs = null;
            }
            else
            {
                _spawnInterval = 0;
                _poolSize = 0; _objectPrefab = null;

            }
        }

        public IEnumerator SpawnRoutine()
        {
            while (true)
            {
                var obj = _objectPool.GetPooledObject();
                obj.transform.position = transform.position;

                yield return _waitForSecond;
            }
        }

        public IEnumerator SpawnRoutineRandom()
        {
            int i = 0;

            while (true)
            {
                if (i == 0) yield return new WaitForSeconds(Random.Range(0, 10));
                i = 1;
                var obj = _objectPool.GetPooledObjectRandom();
                obj.transform.position = transform.position;
                OnSpawnObject?.Invoke();
                yield return new WaitForSeconds(Random.Range(_spawnMinTime + ExtraSpawnTime, _spawnMaxTime + ExtraSpawnTime));
                ExtraSpawnTime = 0;
            }
        }

        public void ActiveObjectsHandle()
        {
            var activeObjects = GetComponentsInChildren<EnemyController>();

            for (int i = 0; i < activeObjects.Length; i++)
            {
                if (activeObjects[i].transform.position.z < -5f)
                {
                    activeObjects[i].gameObject.SetActive(false);
                    activeObjects[i].transform.position = gameObject.transform.position;
                }

            }
        }

        IEnumerator ObjectCheckTransform()
        {
            var wait = new WaitForSeconds(1f);

            while (true)
            {
                ActiveObjectsHandle();
                //Debug.Log("This process worked");
                yield return wait;
            }
        }


    }
}

