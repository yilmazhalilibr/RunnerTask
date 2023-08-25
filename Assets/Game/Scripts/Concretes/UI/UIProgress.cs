using RunnerTask.Controllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.UI
{
    public class UIProgress
    {
        UIController _uIController;

        public event System.Action OnListClear;
        public UIProgress(UIController uIController)
        {
            _uIController = uIController;
        }

        public void RemoveOneRight()
        {
            if (_uIController.RightImages.Count == 0)
            {
                OnListClear?.Invoke();
            }
            else
            {
                var lastImage = _uIController.RightImages[_uIController.RightImages.Count - 1];
                lastImage.gameObject.SetActive(false);
                _uIController.RightImages.Remove(lastImage);
            }
        }

        public void RightPanelState(bool state)
        {
            _uIController.RightsPanel.SetActive(state);
        }

        public void FinishPanelState(bool state)
        {
            _uIController.FinishPanel.SetActive(state);
        }


    }
}

