using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game_Mechanics
{
    public class FinishLevel : MonoBehaviour
    {
        public ScorePizza scoreScript;
        public bool levelDone;
        [SerializeField] private GameObject results;

        private void Start()
        {
            results.SetActive(false);
        }

        private void Update()
        {
            if (GameObject.FindWithTag("Ragdoll") == null)
            {
                ShowResults();
            }
            else if (levelDone)
            {
                ShowResults();
            }
        }

        private void ShowResults()
        {
            levelDone = true;
            results.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        
        public void NextLevel()
        {
            SceneManager.LoadScene("Level2");
            Time.timeScale = 1f;
        }
        
        public void FinishGame()
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}