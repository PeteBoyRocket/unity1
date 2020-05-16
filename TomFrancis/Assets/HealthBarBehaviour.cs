using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour : MonoBehaviour
{
    public Image filledPart;

    public void ShowHealthFraction(float fraction)
    {
        var currentScale = this.filledPart.rectTransform.localScale;
        this.filledPart.rectTransform.localScale = new Vector3(fraction, currentScale.y, currentScale.z);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
