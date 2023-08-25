using RunnerTask.Abstracts.Controllers;
using RunnerTask.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RunnerTask.Controllers
{
    public class UIController : Controller
    {
        [SerializeField] GameObject _rigtsPanel;
        [SerializeField] GameObject _finisPanel;
        [SerializeField] List<RawImage> _rights;

        UIProgress _progress;

        public GameObject RightsPanel { get { return _rigtsPanel; } set { _rigtsPanel = value; } }
        public GameObject FinishPanel { get { return _finisPanel; } set { _finisPanel = value; } }
        public List<RawImage> RightImages { get { return _rights; } set { _rights = value; } }

        private void Awake()
        {
            _progress = new UIProgress(this);
        }
        private void OnEnable()
        {
            _progress.OnListClear += UIGameOver;
        }
        private void OnDisable()
        {
            _progress.OnListClear -= UIGameOver;
        }
        private void UIGameOver()
        {
            _progress.RightPanelState(false);
            _progress.FinishPanelState(true);
        }

    }
}

