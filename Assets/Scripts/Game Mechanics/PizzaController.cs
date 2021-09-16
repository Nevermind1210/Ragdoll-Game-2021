using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Game_Mechanics
{
    public class PizzaController : MonoBehaviour
    {
        public ScorePizza score;
        
        [Header("--Setup The Pizza--")] 
        [SerializeField] private GameObject pizza;
        [SerializeField] private Camera playerCamera; // The camera the player sees
        [SerializeField] private Slider powerBar; // the charge up of the pizza and its throw distance
        [SerializeField] private bool holdingPizza;
        [SerializeField] private bool chargingUp;
        [SerializeField] private float startPos;
        [SerializeField] private float returnTime;
        [Header("--Throw Power--")] 
        [SerializeField] private float power;
        [SerializeField] private float minPow;
        [SerializeField] private float maxPow;
        [SerializeField] private float powerMulti;

        private void Start()
        {
            pizza.GetComponent<Rigidbody>().useGravity = false;

            powerBar.value = 0;
            powerBar.maxValue = maxPow;
            powerBar.minValue = minPow;
        }

        private void Update()
        {
            ChargeUp();
            ThrowingPizza();
        }

        private void ChargeUp()
        {
            if (Input.GetKey(KeyCode.Space) && holdingPizza)
            {
                chargingUp = true;

                if (power > maxPow)
                {
                    power = maxPow;
                }
                else
                {
                    power = power += powerMulti * Time.deltaTime;
                    powerBar.value = power;
                }
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                chargingUp = false;
            }
        }

        private void ThrowingPizza()
        {
            if (holdingPizza)
            {
                pizza.transform.position = playerCamera.transform.position + playerCamera.transform.forward * startPos;

                if (Input.GetMouseButtonDown(0) && !chargingUp)
                {
                    holdingPizza = false;
                    pizza.GetComponent<Rigidbody>().useGravity = true;
                    pizza.GetComponent<Rigidbody>().AddForce(playerCamera.transform.forward * power, ForceMode.Impulse);
                    score.UpdateShots(1);
                    Invoke("ReturnPizza", returnTime);
                }
            }
        }

        private void ReturnPizza()
        {
            holdingPizza = true;
            pizza.GetComponent<Rigidbody>().useGravity = false;
            pizza.GetComponent<Rigidbody>().velocity = Vector3.zero;
            power = minPow;
            powerBar.value = power;
        }
    }
}