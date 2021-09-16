using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Game_Mechanics
{
    public class InstructionsText : MonoBehaviour
    {
        public GameObject textScreen;


        private void Update()
        {
            StartCoroutine(DestroyDelay());
        }

        IEnumerator DestroyDelay()
        {
            yield return new WaitForSecondsRealtime(12);
            {
                Destroy(textScreen);
            }
        }
    }
}