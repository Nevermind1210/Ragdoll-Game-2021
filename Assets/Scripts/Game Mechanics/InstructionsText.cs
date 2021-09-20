using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game_Mechanics
{
    public class InstructionsText : MonoBehaviour
    {
        public GameObject textScreen;


        private void Update()
        {
            if (textScreen.scene.IsValid())
            {
                Time.timeScale = 0.0f;
                StartCoroutine(DestroyDelay());
            }
        }

        IEnumerator DestroyDelay()
        {
            yield return new WaitForSecondsRealtime(12);
            {
                Destroy(textScreen);
                Time.timeScale = 1.0f;
            }
        }
    }
}