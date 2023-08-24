using RunnerTask.Abstracts.Controllers;
using RunnerTask.Patterns;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
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

        [Header("Random Pool")]
        [SerializeField] float _minSpawnTime;
        [SerializeField] float _maxSpawnTime;
        [SerializeField,Description("If you check this button, you need use SpawnInterval value.")] bool _theSameInterval;
        [SerializeField] GameObject[] _objectsPrefabs;


        WaitForSeconds _waitForSecond;
        ObjectPool _objectPool;

        public event System.Action OnSpawnObject;
        public override bool SingleType => _singleType;
        public float ExtraSpawnTime { get; set; }

        private void Awake()
        {
            _objectPool = SingleType ? new ObjectPool(this, _objectPrefab, _poolSize) : new ObjectPool(this, _objectsPrefabs);
        }

        private void Start()
        {
            _waitForSecond = new WaitForSeconds(_spawnInterval);

            var coroutine = SingleType ? SpawnRoutine() : SpawnRoutineRandom();
            StartCoroutine(coroutine);
        }

        private void OnValidate()
        {
            if (_singleType)
            {
                _minSpawnTime = 0;
                _maxSpawnTime = 0;
                _objectsPrefabs = null;
            }
            else
            {
                _poolSize = 0;
                _objectPrefab = null;
            }
            if (_theSameInterval)
            {
                _minSpawnTime = 0;
                _maxSpawnTime = 0;
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

        private IEnumerator SpawnRoutineRandom()
        {
            while (true)
            {
                var obj = _objectPool.GetPooledObject();
                obj.transform.position = transform.position;
                float value = _theSameInterval ? _spawnInterval : Random.Range(_minSpawnTime, _maxSpawnTime);
                yield return new WaitForSeconds(value);
            }
        }


    }
}

