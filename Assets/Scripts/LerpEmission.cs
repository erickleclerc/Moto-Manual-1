using UnityEngine;

public class LerpEmission : MonoBehaviour
{
    [SerializeField] private float speed = 0.3f;

    public Color startColor; // Starting color
    public Color endColor = new Color(0, 0.7490f, 0.7490f, 1); // Ending color

    private Renderer gameObjectRenderer; // Renderer component to apply color

    public bool isHighlighted = false;

    void Start()
    {
        gameObjectRenderer = GetComponent<Renderer>(); // Get renderer component
        startColor = gameObjectRenderer.material.color; // Set start color
    }

    void Update()
    {
        float sine = Mathf.Sin(Time.time / speed);

        if (isHighlighted)
        {
            Color lerpedColor = Color.Lerp(startColor, endColor, sine);

            gameObjectRenderer.material.color = lerpedColor;
        }
        else
        {
            gameObjectRenderer.material.color = startColor;
        }
    }
}

