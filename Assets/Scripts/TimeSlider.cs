using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeSlider : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI beatTime;
    [SerializeField] private TextMeshProUGUI vocalsTime;
    [SerializeField] private TMP_InputField totalHours;
    [SerializeField] private Slider slider;

    public void UpdateTimes()
    {
        float value = slider.value;
        int timeSpentOnBeats = (int)(float.Parse(totalHours.text) * value);
        int timeSpentOnVocals = int.Parse(totalHours.text) - timeSpentOnBeats;
        beatTime.SetText(timeSpentOnBeats.ToString());
        vocalsTime.SetText(timeSpentOnVocals.ToString());
    }

    private void Update()
    {
        UpdateTimes();
    }
}
