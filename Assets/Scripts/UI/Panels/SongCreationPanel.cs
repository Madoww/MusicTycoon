using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SongCreationPanel : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] private TMP_Dropdown genreInput;
    [SerializeField] private TMP_Dropdown typeInput;
    [SerializeField] private TextMeshProUGUI beatHoursInput;
    [SerializeField] private TextMeshProUGUI vocalsHoursInput;

    [SerializeField] private UIButton createButton;

    void Start()
    {
        createButton.onClick += GenerateSong;
    }

    private void GenerateSong()
    {
        SongCreator creator = new SongCreator();

        creator.Initialize(nameInput, genreInput, typeInput, beatHoursInput, vocalsHoursInput);
        creator.Create();
    }
}
