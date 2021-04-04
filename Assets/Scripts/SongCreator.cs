﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Text.RegularExpressions;

public class SongCreator : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_Dropdown genreInput;
    [SerializeField] private TMP_Dropdown typeInput;
    [SerializeField] private TextMeshProUGUI beatHoursInput;
    [SerializeField] private TextMeshProUGUI vocalsHoursInput;

    private Song song = new Song();

    int beatHours;
    int vocalsHours;
    int hoursTotal;

    private void UpdateInfo()
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
    }

    public void Create()
    {
        song = new Song();
        UpdateInfo();
        song.QualityIndex = CalculateSongQualityIndex();
        GameManager.Instance.songs.Add(song);
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

    private int CalculateSongQualityIndex()
    {
        int quality = 0;
        float expectedBeatToVocalsRatio = ((float)song.genre.beatImportance / 100);

        if(song.type == SongType.beat)
        {
            quality = beatHours * GetBoost(ItemType.keyboard) * GetBoost(ItemType.headphones) * GetBoost(ItemType.software);
        }

        if(song.type == SongType.song)
        {
            float beatToVocalsRatio = ((float)beatHours / hoursTotal);
            Debug.Log("Expected: " + expectedBeatToVocalsRatio + ", Actual: " + beatToVocalsRatio);

            float ratioDifference = Mathf.Abs(expectedBeatToVocalsRatio - beatToVocalsRatio);

            Debug.Log("Original: " + (beatHours * song.genre.beatImportance + vocalsHours * (100 - song.genre.beatImportance)) + ", Divided by: " + ratioDifference);
            quality = (int)((float)(beatHours * song.genre.beatImportance + vocalsHours * (100-song.genre.beatImportance)) / Mathf.Max(ratioDifference,0.1f));
            //quality = (beatHours * song.genre.beatImportance * GetBoost(ItemType.keyboard) * GetBoost(ItemType.headphones) * GetBoost(ItemType.software)) + (vocalsHours * (100 - song.genre.beatImportance) * GetBoost(ItemType.microphone));
        }

        Debug.Log(quality / 2 + " | " + quality);
        quality = UnityEngine.Random.Range(quality / 2, quality);
        return quality;
    }

    private int GetBoost(ItemType type)
    {
        return InventoryManager.Instance.GetActiveItem(type) ? InventoryManager.Instance.GetActiveItem(type).qualityBoost : 1;
    }
}
