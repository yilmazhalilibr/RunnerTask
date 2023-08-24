using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RunnerTask.Abstracts.Buttons
{
    public abstract class BaseButton : MonoBehaviour
    {
        [SerializeField] protected Button _button;

        protected virtual void OnValidate()
        {
            if (_button == null)
            {
                _button = GetComponentInChildren<Button>();
            }
        }

        protected virtual void OnEnable()
        {
            _button.onClick.AddListener(HandleButtonClicked);
        }
        protected virtual void OnDisable()
        {
            _button.onClick.RemoveListener(HandleButtonClicked);
        }

        protected abstract void HandleButtonClicked();

    }
}

