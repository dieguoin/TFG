using UnityEngine;

public class ExplosionTimeOut : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1);
    }

}
