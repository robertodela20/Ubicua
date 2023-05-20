using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using System.Collections;


public class farola : MonoBehaviour
{
    private string weatherAPIUrl = "http://api.openweathermap.org/data/2.5/weather?q=Santiago+de+Compostela,es&appid=fc320eafda5a3d2ae06b2caf62595bf4";
    public Text textField;
    
    private void Start()
    {
        StartCoroutine(UpdateWeatherData());
    }
    
    IEnumerator UpdateWeatherData()
    {
        // Ejecutar una vez inmediatamente
        yield return StartCoroutine(FetchWeatherData());
        
        // Ejecutar repetidamente cada 10 segundos
        InvokeRepeating(nameof(UpdateDataRoutine), 10f, 10f);
    }
    
    IEnumerator FetchWeatherData()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(weatherAPIUrl))
        {
            yield return webRequest.SendWebRequest();
            
            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                string response = webRequest.downloadHandler.text;
                WeatherData weatherData = JsonUtility.FromJson<WeatherData>(response);
                float temperature = weatherData.main.temp;
				int humidity = weatherData.main.humidity;
				float windSpeed = weatherData.wind.speed;
                textField.text = temperature.ToString() + "\n" + humidity.ToString() + "\n" + windSpeed.ToString();
            }
        }
    }
    
    private void UpdateDataRoutine()
    {
        StartCoroutine(FetchWeatherData());
    }
}

[System.Serializable]
public class WeatherData
{
    public WeatherMainData main;
    public WindData wind;
}

[System.Serializable]
public class WeatherMainData
{
    public float temp;
    public int humidity;
}

[System.Serializable]
public class WindData
{
    public float speed;
}

