using RunnerTask.Abstracts.Controllers;
using RunnerTask.Abstracts.Movements;
using RunnerTask.Controllers;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.Patterns
{
    public class ObjectPool
    {
        private Queue<GameObject> _pooledObjects;
        private GameObject[] _objectPrefabs;


        GameObject _objectPrefab;
        Controller _controller;

        int _poolSize;
        public ObjectPool(Controller controller, GameObject objectPrefab, int size)
        {
            _controller = controller;
            _objectPrefab = objectPrefab;
            _poolSize = size;

            _pooledObjects = new Queue<GameObject>();

            PoolInitialize();
        }
        public ObjectPool(Controller controller, GameObject[] objectPrefabs)
        {
            _controller = controller;
            _objectPrefabs = objectPrefabs;

            _pooledObjects = new Queue<GameObject>();

            PoolInitialize();

        }

        private void PoolInitialize()
        {
            if (_controller.SingleType)
            {
                for (int i = 0; i < _poolSize; i++)
                {
                    GameObject obj = GameObject.Instantiate(_objectPrefab, _controller.transform);
                    obj.SetActive(false);
                    _pooledObjects.Enqueue(obj);
                }
            }
            else
            {
                for (int i = 0; i < _objectPrefabs.Length; i++)
                {
                    GameObject obj = GameObject.Instantiate(_objectPrefabs[i], _controller.transform);
                    obj.SetActive(false);
                    _pooledObjects.Enqueue(obj);
                }
            }

        }

        public GameObject GetPooledObject()
        {
            GameObject obj = _pooledObjects.Dequeue();
            obj.SetActive(true);
            _pooledObjects.Enqueue(obj);
            return obj;

        }

        public GameObject GetPoolObjectRandom()
        {
            GameObject obj = _pooledObjects.ToArray()[Random.Range(0, _pooledObjects.Count)];
            obj.SetActive(true);
            _pooledObjects.Enqueue(obj);
            return obj;
        }


    }
}
