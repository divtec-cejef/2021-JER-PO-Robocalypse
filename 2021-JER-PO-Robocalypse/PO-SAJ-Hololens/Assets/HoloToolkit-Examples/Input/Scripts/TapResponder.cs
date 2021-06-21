// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See LICENSE in the project root for license information.

using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace HoloToolkit.Unity.InputModule.Tests
{
    /// <summary>
    /// This class implements IInputClickHandler to handle the tap gesture.
    /// It increases the scale of the object when tapped.
    /// </summary>
    public class TapResponder : MonoBehaviour, IInputClickHandler
    {
        public int weapon;
        //private Renderer renderer;

        private Boolean IsClicked = false;


        void Start()
        {
            //renderer = GetComponent<Renderer>();
        }

        public void OnInputClicked(InputClickedEventData eventData)
        {
            // Increase the scale of the object just as a response.
            // gameObject.transform.localScale += 0.05f * gameObject.transform.localScale;

            if (!IsClicked)
            {
                IsClicked = true;
                //StartCoroutine(ChangeColorTime());
            }

            eventData.Use(); // Mark the event as used, so it doesn't fall through to other handlers.
        }

        /**
         * Change la couleur du cube et attend 0.5 seconde avant de le
         * rendre de nouveau cliquable
         */
        IEnumerator ChangeColorTime()
        {
            //renderer.material.color = Color.red;

            yield return new WaitForSeconds(0.5f);

            //renderer.material.color = Color.cyan;
            IsClicked = false;
        }
    }
}