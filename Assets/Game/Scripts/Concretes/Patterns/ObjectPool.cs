using RunnerTask.Abstracts.Controllers;
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
                    AddPool(obj, false);
                }
            }
            else
            {
                for (int i = 0; i < _objectPrefabs.Length; i++)
                {
                    GameObject obj = GameObject.Instantiate(_objectPrefabs[i], _controller.transform);
                    AddPool(obj, false);
                }
            }

        }
        /**/
        public GameObject GetPooledObject()
        {
            GameObject obj = _pooledObjects.Dequeue();
            return AddPool(obj, true);

        }

        public GameObject GetPooledObjectRandom()
        {
            GameObject obj = _pooledObjects.ToArray()[Random.Range(0, _pooledObjects.Count)];

            if (!obj.activeSelf)
            {

                return AddPool(obj, true);
            }
            else
            {
                for (int i = 0; i < _pooledObjects.Count; i++)
                {
                    if (!_pooledObjects.ToArray()[i].activeSelf)
                    {
                        return _pooledObjects.ToArray()[i];
                    }
                    //Debug.Log("Resource new enemy");
                }
                return null;
            }

        }
        /**/

        private GameObject AddPool(GameObject obj, bool state)
        {
            obj.SetActive(state);
            _pooledObjects.Enqueue(obj);
            return obj;
        }


    }
}
