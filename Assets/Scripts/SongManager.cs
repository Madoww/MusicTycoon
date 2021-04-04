using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

public class SongManager : Singleton<SongManager>
{
    public List<SongGenre> songGenres = new List<SongGenre>();

    public SongGenre GetGenreOfName(string name)
    {
        name = Regex.Replace(name.ToLower(), "[^a-zA-Z0-9]", String.Empty);
        for (int i = 0; i<songGenres.Count; i++)
        {
            if(name == songGenres[i].genreName.ToLower())
            {
                return songGenres[i];
            }
        }
        return null;
    }
}
