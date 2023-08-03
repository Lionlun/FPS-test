using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Health health;

    void Start()
    {
        slider.maxValue = health.MaxHealth;
    }

    void Update()
    {
        UpdateHealth();
	}

    void UpdateHealth()
    {
        slider.value = health.CurrentHealth;
    }
}
