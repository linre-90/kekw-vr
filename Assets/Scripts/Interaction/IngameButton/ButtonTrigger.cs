﻿using System;
using UnityEngine;

namespace Kekw.Interaction
{
    /// <summary>
    /// Ingame button base collision detection.
    /// </summary>
    class ButtonTrigger: MonoBehaviour
    {
        // Master script in parent.
        IngameButton ingameButton;

        private void Awake()
        {
            ingameButton = this.GetComponentInParent<IngameButton>();
        }

        // This triggers main button script.
        private void OnCollisionEnter(Collision collision)
        {
            
            if (collision.gameObject.CompareTag("IngameButton"))
            {
                ingameButton.OnButtonPressed();
            }
        }
    }
}
