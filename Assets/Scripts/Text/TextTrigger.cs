using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    [SerializeField] private string text = "H'sW";

    private void OnTriggerEnter(Collider other)
    {
        TextController.onTextTriggered?.Invoke(text);
    }

    private void OnTriggerExit(Collider other)
    {
        Destroy(gameObject);
    }
}
