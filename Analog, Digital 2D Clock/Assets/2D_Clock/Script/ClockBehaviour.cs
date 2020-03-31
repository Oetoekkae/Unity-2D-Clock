using System;
using TMPro;
using UnityEngine;

public class ClockBehaviour : MonoBehaviour {
    [Header("Clock Arm")]
    public Transform hoursAnalog, minutesAnalog, secondsAnalog;
    [Header("Digital Values")]
    public TextMeshProUGUI hoursDigi, minutesDigi, secondsDigi;

    private const float hours = -360f / 12f,
        minutes = -360f / 60f,
        seconds = -360f / 60f;

    // Update is called once per framed
    void Update() { 
        updateTime();
    }

    //Päivittää kellon ajan
    void updateTime() {

        //Tämän hetkinen aika
        DateTime currentTime = DateTime.Now;

        //Viisareiden asetus oikeaan kulmaan ajan perusteella
        hoursAnalog.localRotation = Quaternion.Euler(0f, 0f, (float)currentTime.Hour * hours + ((float)currentTime.Minute * minutes * (float)0.055));
        minutesAnalog.localRotation = Quaternion.Euler(0f, 0f, (float)currentTime.Minute * minutes);
        secondsAnalog.localRotation = Quaternion.Euler(0f, 0f, (float)currentTime.Second * seconds);

        //Digitaalisen ajan asetus
        hoursDigi.SetText(checkForSingleDigit(currentTime.Hour));
        minutesDigi.SetText(checkForSingleDigit(currentTime.Minute));
        secondsDigi.SetText(checkForSingleDigit(currentTime.Second));
    }

    //Tarkastaa mikäli arvo on yksinumeroinen ja palauttaa sen kaksinumeroisena merkkijonona
    String checkForSingleDigit(int digits) {
        if (digits < 10) {
            string addZero = "0" + digits.ToString();
            return addZero;
        }
        return digits.ToString();
    }
}
