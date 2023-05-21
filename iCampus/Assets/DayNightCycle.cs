using UnityEngine;

public class DayNightCycle : MonoBehaviour
{
    public Light directionalLight; // Referencia a la luz direccional
    public float dayDuration = 300f; // Duración total del ciclo día-noche en segundos (5 minutos)

    private float timer; // Temporizador para controlar el ciclo día-noche

    void Start()
    {
        timer = 0f; // Inicializar el temporizador a cero
    }

    void Update()
    {
        timer += Time.deltaTime; // Actualizar el temporizador con el tiempo transcurrido

        // Calcular la rotación de la luz direccional en función del tiempo transcurrido
        float rotationAmount = (timer / dayDuration) * 360f;
        directionalLight.transform.rotation = Quaternion.Euler(rotationAmount, 0f, 0f);

        // Reiniciar el temporizador cuando se completa un ciclo día-noche
        if (timer >= dayDuration)
        {
            timer = 0f;
        }
    }
}
