using cowsins;
using System;
using TMPro;
using UnityEngine;

namespace FPSShooter.Car
{
    public class Car : Interactable
    {
        [SerializeField] private TMP_Text countText;
        private int partCount = 0;

        private void OnEnable()
        {
            CarParts.OnCarPartCollect += CarParts_OnCarPartCollect;
        }

        private void Start()
        {
            SetPartCountText(0);
        }

        private void CarParts_OnCarPartCollect()
        {
            partCount++;
            SetPartCountText(partCount);
        }

        private void SetPartCountText(int value)
        {
            countText.text = $"{value}/3";
        }

        public override void Interact()
        {
            interactText = $"{partCount}/3 part";
            if (partCount >= 3)
            {
                //play cutscene;
                //or load other scene which include only cutscene   
            }
        }

        private void OnDisable()
        {
            CarParts.OnCarPartCollect -= CarParts_OnCarPartCollect;
        }
    }
}
