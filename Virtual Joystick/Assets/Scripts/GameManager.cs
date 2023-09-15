using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    //simdiki varolan para, skin SimdikiSkin, simdiki sira satın alınan ve alınmayan sıra
    public int simdiki = 0, SimdikiSkin = 0, SimdikiSira = 0;

    private void Awake()
    {
        // if (instance == null)
        // {
        //     instance = this;
        //     DontDestroyOnLoad(gameObject);
        // }
        // else
        // {
        //     Destroy(gameObject);
        // }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // Get the necessary keys from the player prefs.
        if (PlayerPrefs.HasKey("SimdikiSkin"))
        {
            simdiki = PlayerPrefs.GetInt("simdiki");
            SimdikiSkin = PlayerPrefs.GetInt("SimdikiSkin");
            SimdikiSira = PlayerPrefs.GetInt("SimdikiSira");
        }
        else
        {
            Save();
        }
    }

    // This method is to set the necessary keys to player prefs.
    public void Save()
    {
        PlayerPrefs.SetInt("simdiki", simdiki);
        PlayerPrefs.SetInt("SimdikiSkin", SimdikiSkin);
        PlayerPrefs.SetInt("SimdikiSira", SimdikiSira);
    }
}
