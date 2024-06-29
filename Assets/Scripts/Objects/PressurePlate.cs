using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [SerializeField] private GameObject button;
    private Color pressedColor = Color.red;
    private Color defaultColor = Color.green;

    private Renderer buttonRenderer;
    public bool onPlate;

    private void Awake()
    {
        buttonRenderer = button.GetComponent<Renderer>();
    }

    void Start()
    {
        buttonRenderer.material.color = defaultColor;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickable"))
        {
            onPlate = true;
            UpdateButtonColor();
            Debug.Log("Pressed");
        }
    }

    void OnTriggerExit(Collider other)
    {
        onPlate = false;
        UpdateButtonColor();
        Debug.Log("released");
    }

    void UpdateButtonColor()
    {
        buttonRenderer.material.color = onPlate ? pressedColor : defaultColor;
    }
}