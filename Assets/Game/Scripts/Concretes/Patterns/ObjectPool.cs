using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.Patterns
{
    public class ObjectPool
    {
        GameObject[] _objectPrefabs;
        GameObject[] _instantiatedObject;

        GameObject _activeGameObject;

        public ObjectPool(GameObject activeGameObject, GameObject[] objectPrefabs)
        {
            _activeGameObject = activeGameObject;
            _objectPrefabs = objectPrefabs;

            _instantiatedObject = new GameObject[_objectPrefabs.Length];
            PoolInit();

        }

        private void PoolInit()
        {
            if (_objectPrefabs == null) return;
            for (int i = 0; i < _objectPrefabs.Length; i++)
            {
                GameObject obj = GameObject.Instantiate(_objectPrefabs[i], _activeGameObject.transform);
                obj.SetActive(false);
                _instantiatedObject[i] = obj;
            }
        }

        public GameObject GetRandomPoolObject()
        {
            GameObject randomObj = _instantiatedObject[Random.Range(0, _instantiatedObject.Length)];
            randomObj.SetActive(true);
            return randomObj;
        }
        public GameObject[] GetPoolObjects()
        {
            return _instantiatedObject;
        }
        public void SetRandomPoolObject(GameObject obj)
        {
            obj.SetActive(false);
            obj.transform.parent = _activeGameObject.transform;
            _instantiatedObject[_instantiatedObject.Length + 1] = obj;
        }


    }



}
