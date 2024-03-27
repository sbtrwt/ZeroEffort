using Cinemachine;
using UnityEngine;

namespace FPSShooter.Player
{
    public class PlayerView : MonoBehaviour
    {
        //private const string RUN_THRESHOLD_X = "RunThresholdX";
        //private const string RUN_THRESHOLD_Y = "RunThresholdY";

        //[SerializeField] private AxisState xAxis;
        //[SerializeField] private AxisState yAxis;

        //[SerializeField] protected Rigidbody playerRb;
        //[SerializeField] protected Animator playerAnimator;
        //[SerializeField] protected Transform cameraTarget;

        //private PlayerController playerController;
        //private Vector3 moveInputDalta;
        //public void SetController(PlayerController playerController)
        //{
        //    this.playerController = playerController;
        //}

        //public void SetPosition(Vector3 position)
        //{
        //    transform.position = position;
        //}

        //public void Move(Vector3 target, float speed)
        //{
        //    moveInputDalta = target;
        //    Vector3 moveDir = Quaternion.Euler(0, Camera.main.transform.eulerAngles.y, 0) * new Vector3(target.x, 0, target.y);
        //    transform.position += speed * Time.deltaTime * moveDir;

        //    bool isRunning = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        //    UpdateAnimatorParameters(target.x, target.y, isRunning);

        //}

        //private void Update()
        //{
        //    xAxis.Update(Time.deltaTime);
        //    yAxis.Update(Time.deltaTime);
        //}

        //private void LateUpdate()
        //{
        //    cameraTarget.localEulerAngles = new Vector3(yAxis.Value, cameraTarget.localEulerAngles.y, cameraTarget.localEulerAngles.z);
        //    transform.eulerAngles = new Vector3(0, xAxis.Value, 0);
        //}


        //private void UpdateAnimatorParameters(float horizontalInput, float verticalInput, bool isRunning)
        //{
        //    // Set the animator parameters RunThresholdX and RunThresholdY based on input values and running state
        //    float targetRunThresholdX = horizontalInput < 0 ? -0.5f : horizontalInput > 0 ? 0.5f : 0f;
        //    float targetRunThresholdY = verticalInput < 0 ? -0.5f : verticalInput > 0 ? 0.5f : 0f;

        //    // Apply running modifier if shift key is pressed
        //    if (isRunning)
        //    {
        //        targetRunThresholdX *= 2; // Double the speed for running
        //        targetRunThresholdY *= 2; // Double the speed for running
        //    }

        //    float lerpSpeed = 10f;

        //    float currentRunThresholdX = playerAnimator.GetFloat(RUN_THRESHOLD_X);
        //    float currentRunThresholdY = playerAnimator.GetFloat(RUN_THRESHOLD_Y);

        //    float newRunThresholdX = Mathf.Lerp(currentRunThresholdX, targetRunThresholdX, Time.deltaTime * lerpSpeed);
        //    float newRunThresholdY = Mathf.Lerp(currentRunThresholdY, targetRunThresholdY, Time.deltaTime * lerpSpeed);

        //    playerAnimator.SetFloat(RUN_THRESHOLD_X, newRunThresholdX);
        //    playerAnimator.SetFloat(RUN_THRESHOLD_Y, newRunThresholdY);
        //}

        //public Transform GetCameraTarget()
        //{
        //    return cameraTarget;
        //}
    }
}
