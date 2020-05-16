using UnityEngine;

public class CanvasBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        References.canvas = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
