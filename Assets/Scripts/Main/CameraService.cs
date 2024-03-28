using Cinemachine;
using FPSShooter.InputSystem;
using UnityEngine;

namespace FPSShooter.Main
{
    public class CameraService
    {
        private CinemachineVirtualCamera virtualCamera;

        private const float EFFECT_FOV = 90;
        private const float NORMAL_FOV = 70;
        private const float BLAND_SPEED = 2;
        public CameraService(CinemachineVirtualCamera virtualCamera)
        {
            this.virtualCamera = virtualCamera;

            InputService.OnSprint += InputService_OnSprint;
            InputService.OnSprintCanceled += InputService_OnSprintCanceled;
        }

       
        private void InputService_OnSprint()
        {
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(NORMAL_FOV, EFFECT_FOV, Time.deltaTime * BLAND_SPEED);
        }

        private void InputService_OnSprintCanceled()
        {
            virtualCamera.m_Lens.FieldOfView = Mathf.Lerp(EFFECT_FOV, NORMAL_FOV, Time.deltaTime * BLAND_SPEED);
        }

        public void Update()
        {

        }
       

        public void SetTarget(Transform transform)
        {
            virtualCamera.Follow = transform;
            virtualCamera.LookAt = transform;
        }

        ~CameraService()
        {
            InputService.OnSprint -= InputService_OnSprint;
            InputService.OnSprintCanceled -= InputService_OnSprintCanceled;
        }
    }
}