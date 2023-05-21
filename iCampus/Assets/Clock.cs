using UnityEngine;
using System;

public class Clock : MonoBehaviour
{
    public Transform hourHand; // Referencia al puntero de las horas
    public Transform minuteHand; // Referencia al puntero de los minutos

    private float totalSeconds; // Total de segundos en el ciclo de 24 horas
    private float timer; // Temporizador para controlar el ciclo del reloj

    void Start()
    {
        totalSeconds = 24f * 60f * 60f; // Calcular el total de segundos en 24 horas
        timer = 0f; // Inicializar el temporizador a cero
    }

    void Update()
    {
        timer += Time.deltaTime; // Actualizar el temporizador con el tiempo transcurrido

        // Calcular el ángulo de rotación para los punteros de las horas y los minutos
        float rotationAmount = (timer / (5f * 60f)) * 360f;
        TimeSpan time = TimeSpan.FromSeconds(timer);
        float hours = (float)time.TotalHours;
        float minutes = (float)time.TotalMinutes % 60f;

        // Rotar los punteros de las horas y los minutos
        hourHand.rotation = Quaternion.Euler(0f, 0f, -hours * 30f);
        minuteHand.rotation = Quaternion.Euler(0f, 0f, -minutes * 6f);

        // Reiniciar el temporizador cuando se completa el ciclo de 24 horas
        if (timer >= totalSeconds)
        {
            timer = 0f;
        }
    }
}