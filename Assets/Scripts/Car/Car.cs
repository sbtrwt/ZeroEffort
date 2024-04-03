using cowsins;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FPSShooter.Car
{
    public class Car : Interactable
    {
        [SerializeField] private TMP_Text countText;
        [SerializeField] private TMP_Text timerText;
        [SerializeField] private AudioSource audioSource;
        [SerializeField] private float timeToGrabTheCar = 0;
        private float currTimeToGrabTheCar;
        private bool isGameOver;
        private bool isTimerStarted;

        private int partCount = 0;
        private void OnEnable()
        {
            CarParts.OnCarPartCollect += CarParts_OnCarPartCollect;
        }

        private void Start()
        {
            isGameOver = false;
            isTimerStarted = false;
            SetPartCountText(0);
            currTimeToGrabTheCar = timeToGrabTheCar;
        }

        private void CarParts_OnCarPartCollect()
        {
            partCount++;
            if (partCount >= 3)
            {
                audioSource.Play();
                isTimerStarted = true;
                timerText.gameObject.SetActive(true);
            }
            SetPartCountText(partCount);
        }

        private void SetPartCountText(int value)
        {
            countText.text = $"{value}/3";
        }

        private void Update()
        {
            if (!isGameOver && isTimerStarted)
            {
                currTimeToGrabTheCar -= Time.deltaTime;
                timerText.text = currTimeToGrabTheCar.ToString("0.0");
                if (currTimeToGrabTheCar <= 0)
                {
                    audioSource.Stop();
                    timerText.gameObject.SetActive(true);
                    CommonService.Instance.Player.GetComponent<IDamageable>().Damage(100);
                    isGameOver = true;
                }
            }
        }

        public override void Interact()
        {
            interactText = $"{partCount}/3 part";
            if (partCount >= 3)
            {
                SceneManager.LoadScene(2);
            }
        }

        private void OnDisable()
        {
            CarParts.OnCarPartCollect -= CarParts_OnCarPartCollect;
        }


    }
}
