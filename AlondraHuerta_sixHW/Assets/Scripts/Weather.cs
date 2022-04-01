using System;
using System.Net;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class Weather : MonoBehaviour {
	
	//After created an account we can get the key to make the request
	private string apiKey = "c2abf7afc39be6c722e3ab20fbd69c09";

	private string city;
	private string newCity;
	private string correctCity;

	//The texts are created for show the information to the user
	[SerializeField] Text textCity;
	[SerializeField] Text outputTemp;
	[SerializeField] Text outputMinTemp;
	[SerializeField] Text outputMaxTemp;
	[SerializeField] Text outputDegrees;
	[SerializeField] Text outputWind;
	[SerializeField] Text outputHumidity;
	[SerializeField] Text outputDescription;
	
	//The sprites, images and text are for get the app more visuable attractive
	public Sprite bgWarm1, bgWarm2, bgWarm3, bgCold1, bgCold2, bgCold3;
	public Image bg;
	public Text warning;


	private void Start() {
		
		//It gets the initial city the one of default is Guadalajara
		city = textCity.text;
		correctCity = city;
		newCity = city;

		//The warning is false until the name of the city is incorrect
		warning.gameObject.SetActive(false);

		//Real Wather is the function where the url is created
		GetRealWeather();

	}

	private void Update() {

		//Checks if the name of the city has change and call the function to get the new weather
		if (newCity != textCity.text)
		{
			city = textCity.text;
			newCity = city;
			GetRealWeather();
		}
		

	}

	public void GetCity()
    {
		//The warning which let know the user the city is incorrect is display and wait for 3 seconds to dissapear again
		warning.gameObject.SetActive(true);
		StartCoroutine(WaitForMe());

		//The variables are filled with the last correct city
		textCity.text = correctCity;
		newCity = correctCity;
		city = correctCity;

	}

	IEnumerator WaitForMe()
    {
		yield return new WaitForSeconds(3);
		warning.gameObject.SetActive(false);
	}

	//This function created the url to get all the info of the city
	public void GetRealWeather () {
		string url = "api.openweathermap.org/data/2.5/weather?";
		url += "q=" + city + "&appid=" + apiKey;
		StartCoroutine (GetWeatherCoroutine (url));
	}

	//This function is the one that choose which background to display depending of the temperature
	public void printTemp(double temp)
    {
		if(temp <= 0)
        {
			bg.GetComponent<Image>().sprite = bgCold3;
        }
		if (temp > 0 && temp <= 5)
		{
			bg.GetComponent<Image>().sprite = bgCold2;
		}
		if (temp > 5 && temp <= 10)
        {
			bg.GetComponent<Image>().sprite = bgCold1;
		}
		if (temp > 10 && temp <= 15)
		{
			bg.GetComponent<Image>().sprite = bgWarm3;
		}
		if (temp > 15 && temp <= 20)
		{
			bg.GetComponent<Image>().sprite = bgWarm2;
		}
		if(temp >= 21)
        {
			bg.GetComponent<Image>().sprite = bgWarm1;
		}
	}


	//Makes sure that the url exists and if it does, get all the information of the city
	IEnumerator GetWeatherCoroutine (string url) {
		using (UnityWebRequest webRequest = UnityWebRequest.Get (url)) {
			yield return webRequest.SendWebRequest ();
			if (webRequest.isNetworkError) {
				Debug.Log ("Web request error: " + webRequest.error);
			} else {
				ParseJson (webRequest.downloadHandler.text);
			}
		}
	}
	

	//Gets all the information of the city 
	void ParseJson (string json) {
		
		try {
			
			dynamic obj = JObject.Parse (json);
			
			double temp = obj.main.temp;
			temp = Math.Round(temp - 273.15f);

			//This function is the one that changes the color of the background depending of the temperature
			printTemp(temp);

			double minTemp = obj.main.temp_min;
			minTemp = Math.Round(minTemp - 273.15f);

			double maxTemp = obj.main.temp_max;
			maxTemp = Math.Round(maxTemp - 273.15f);

			string description = obj.weather[0].description.ToString();
			
			string windSpeed= obj.wind.speed.ToString();

			string humidity= obj.main.humidity.ToString();
			string windDegrees = obj.wind.deg.ToString();

			//Assign the correspond unit to every result
			outputTemp.text=temp.ToString() + " °C";
			outputWind.text=  windSpeed + " m/s";
			outputDescription.text=description;
			outputHumidity.text = humidity +"%";
			outputMinTemp.text=minTemp.ToString() + " °C";
			outputMaxTemp.text=maxTemp.ToString() + " °C";
			outputDegrees.text = obj.wind.deg + "°";
			
			textCity.text = obj.name;
			//It saves the name of the last city in case the next city is incorrect
			correctCity = textCity.text;

		}
		catch (Exception e) {
			//Get the city makes sure that if the last city is incorrect the data on the 
			//display is the last one which is correct 
			GetCity();
			Debug.Log("Incorrect city name");
			
		}		

		return;
	}

}