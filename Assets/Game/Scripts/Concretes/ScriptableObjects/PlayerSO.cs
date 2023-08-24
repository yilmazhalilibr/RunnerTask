using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.ScriptableObjects
{
    [CreateAssetMenu(fileName = "PlayerSO", menuName = "ScriptableObjects/PlayerSO", order = 51)]
    public class PlayerSO : ScriptableObject
    {
        [SerializeField] GameObject _playerPrefab;
        [SerializeField] float _speed;
        [SerializeField] int _rights;


        public GameObject PlayerPrefab => _playerPrefab;
        public float Speed => _speed;
        public int Rights => _rights;
    }

}
