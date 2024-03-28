using UnityEngine;

public class LevelGridCreator : MonoBehaviour
{
    [SerializeField] private Transform cellObj;

    [SerializeField] private int objCount_N_X_N;
    [SerializeField] private float offset;
    private void Start()
    {
        for (int i = 0; i < objCount_N_X_N; i++) { 
            for (int j = 0; j < objCount_N_X_N; j++)
            {
                Transform obj = Instantiate(cellObj);
                 
                obj.position = new Vector3(offset * i, 0, offset * j);
            }
        }
    }
}
