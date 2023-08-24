using RunnerTask.Abstracts.Buttons;
using RunnerTask.Managers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerTask.Buttons
{
    public class ExitButton : BaseButton
    {
        protected override void HandleButtonClicked()
        {
            LevelManager.ExitGame();
        }

    }

}
