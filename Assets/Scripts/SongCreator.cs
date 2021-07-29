using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Text.RegularExpressions;

public class SongCreator
{
    /*[SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_Dropdown genreInput;
    [SerializeField] private TMP_Dropdown typeInput;
    [SerializeField] private TextMeshProUGUI beatHoursInput;
    [SerializeField] private TextMeshProUGUI vocalsHoursInput;*/

    int beatHours;
    int vocalsHours;
    int hoursTotal;

    private Song tempSong;

    public void Initialize(TMP_InputField name, TMP_Dropdown genre, TMP_Dropdown type, TextMeshProUGUI beatHoursInput, TextMeshProUGUI vocalsHoursInput)
    {
        tempSong = new Song();

        tempSong.name = name.text;
        //song.genre = (SongGenre)Enum.Parse(typeof(SongGenre), Regex.Replace(genreInput.captionText.text.ToLower(), "[^a-zA-Z0-9]", String.Empty));
        tempSong.genre = SongManager.Instance.GetGenreOfName(genre.captionText.text);
        tempSong.type = (SongType)Enum.Parse(typeof(SongType), type.captionText.text.ToLower());
        beatHours = int.Parse(beatHoursInput.text);
        Debug.Log("VOCALS: " + vocalsHoursInput.text);
        vocalsHours = int.Parse(vocalsHoursInput.text);
        tempSong.hoursSpentProducing = beatHours + vocalsHours;

        if (beatHours == 0)
            beatHours = 1;
        if (vocalsHours == 0)
            vocalsHours = 1;

        hoursTotal = beatHours + vocalsHours;
    }

    /*private void UpdateInfo()
    {
        song.name = nameInput.text;
        //song.genre = (SongGenre)Enum.Parse(typeof(SongGenre), Regex.Replace(genreInput.captionText.text.ToLower(), "[^a-zA-Z0-9]", String.Empty));
        song.genre = SongManager.Instance.GetGenreOfName(genreInput.captionText.text);
        song.type = (SongType)Enum.Parse(typeof(SongType), typeInput.captionText.text.ToLower());
        beatHours = int.Parse(beatHoursInput.text);
        vocalsHours = int.Parse(vocalsHoursInput.text);
        song.hoursSpentProducing = beatHours + vocalsHours;

        if (beatHours == 0)
            beatHours = 1;
        if (vocalsHours == 0)
            vocalsHours = 1;

        hoursTotal = beatHours + vocalsHours;
    }*/

    public void Create()
    {
        tempSong.QualityIndex = CalculateSongQualityIndex2();
        GameManager.Instance.songs.Add(tempSong);
    }

    /*private int CalculateSongQualityIndex()
    {
        int quality = 0;
        float expectedBeatToVocalsRatio = ((float)song.genre.beatImportance / 10);

        if (song.type == SongType.beat)
        {
            quality = beatHours * GetBoost(ItemType.keyboard) * GetBoost(ItemType.headphones) * GetBoost(ItemType.software);
        }

        if(song.type == SongType.song)
        {

        }
    }*/

    private float CalculateSongQualityIndex()
    {
        float quality = 0;
        float expectedBeatToVocalsRatio = ((float)tempSong.genre.beatImportance / 100);

        if(tempSong.type == SongType.beat)
        {
            quality = beatHours * GetBoost(ItemType.keyboard) * GetBoost(ItemType.headphones) * GetBoost(ItemType.software);
        }

        if(tempSong.type == SongType.song)
        {
            float beatToVocalsRatio = ((float)beatHours / hoursTotal);
            Debug.Log("Expected: " + expectedBeatToVocalsRatio + ", Actual: " + beatToVocalsRatio);

            float ratioDifference = Mathf.Abs(expectedBeatToVocalsRatio - beatToVocalsRatio);

            Debug.Log("Original: " + (beatHours * tempSong.genre.beatImportance + vocalsHours * (100 - tempSong.genre.beatImportance)) + ", Divided by: " + ratioDifference);
            quality = (int)((float)(beatHours * tempSong.genre.beatImportance + vocalsHours * (100- tempSong.genre.beatImportance)));
            //quality = (beatHours * song.genre.beatImportance * GetBoost(ItemType.keyboard) * GetBoost(ItemType.headphones) * GetBoost(ItemType.software)) + (vocalsHours * (100 - song.genre.beatImportance) * GetBoost(ItemType.microphone));
        }

        Debug.Log(quality / 2 + " | " + quality);
        quality = UnityEngine.Random.Range(quality / 2, quality);
        return quality;
    }

    private float CalculateSongQualityIndex2()
    {
        float quality = 0;

        float expectedBeatHours = hoursTotal * ((float)tempSong.genre.beatImportance / 100f);
        float expectedVocalHours = hoursTotal * ((float)(100f - tempSong.genre.beatImportance) / 100f);

        float ratio = 0;

        if (tempSong.genre.beatImportance > 50)
        {
            ratio = Mathf.Abs(beatHours - expectedBeatHours) / expectedBeatHours;
        }
        else
        {
            ratio = Mathf.Abs(vocalsHours - expectedVocalHours) / expectedVocalHours;
        }
        
        

        if(tempSong.type == SongType.song)
        {
            float actualRatio = 1 - ratio > 0 ? 1 - ratio : 0;
            float beatQuality = beatHours * actualRatio * GetBoost(ItemType.keyboard);
            float vocalsQuality = vocalsHours * actualRatio * GetBoost(ItemType.microphone);
            Debug.Log("Ratio: " + ratio);
            Debug.Log("Beat: " + beatQuality + ", vocals " + vocalsQuality);
            quality = Mathf.Pow(beatQuality + vocalsQuality, 2) / 100f;
            Debug.Log("Total: " + quality);
        }

        return quality;
    }

    private float GetBoost(ItemType type)
    {
        return InventoryManager.Instance.GetActiveItem(type) ? InventoryManager.Instance.GetActiveItem(type).qualityMultiplier : 1;
    }
}
