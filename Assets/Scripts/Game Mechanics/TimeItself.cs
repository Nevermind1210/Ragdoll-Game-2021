using UnityEngine;

namespace Game_Mechanics
{
    public class TimeItself : MonoBehaviour
    {
        private static TimeItself _instance;

        public static TimeItself Instance
        {
            get {return _instance;}
        }

        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        public void Start()
        {
            if (Time.timeScale != 1f)
            {
                Time.timeScale = 1f;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}