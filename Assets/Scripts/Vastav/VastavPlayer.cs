using UnityEngine;

public class VastavPlayer : MonoBehaviour
{
    [SerializeField] private float speed;

    private void OnEnable()
    {
        VastavPlayerInput.OnMove += VastavPlayerInput_OnMove;
    }

    private void VastavPlayerInput_OnMove(Vector2 vector)
    {
        transform.position += new Vector3(vector.x, 0, vector.y) * Time.deltaTime * speed;
    }

    private void OnDisable()
    {
        VastavPlayerInput.OnMove -= VastavPlayerInput_OnMove;
    }
}