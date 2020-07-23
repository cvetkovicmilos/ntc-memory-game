using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NajboljiRezultati : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI zastaveLako;
    [SerializeField] TextMeshProUGUI zastaveSrednje;
    [SerializeField] TextMeshProUGUI zastaveTesko;
    [SerializeField] TextMeshProUGUI mapeLako;
    [SerializeField] TextMeshProUGUI mapeSrednje;
    [SerializeField] TextMeshProUGUI mapeTesko;
    [SerializeField] TextMeshProUGUI grboviLako;
    [SerializeField] TextMeshProUGUI grboviSrednje;
    [SerializeField] TextMeshProUGUI grboviTesko;

    int zastave_Lako;
    int zastave_Srednje;
    int zastave_Tesko;
    int mape_Lako;
    int mape_Srednje;
    int mape_Tesko;
    int grbovi_Lako;
    int grbovi_Srednje;
    int grbovi_Tesko;

    // Start is called before the first frame update
    void Start()
    {
        zastave_Lako = PlayerPrefs.GetInt("11Rekord");
        zastaveLako.text = (zastave_Lako / 60).ToString("00") + ":" + (zastave_Lako - (zastave_Lako / 60) * 60).ToString("00");

        zastave_Srednje = PlayerPrefs.GetInt("12Rekord");
        zastaveSrednje.text = (zastave_Srednje / 60).ToString("00") + ":" + (zastave_Srednje - (zastave_Srednje / 60) * 60).ToString("00");

        zastave_Tesko = PlayerPrefs.GetInt("13Rekord");
        zastaveTesko.text = (zastave_Tesko / 60).ToString("00") + ":" + (zastave_Tesko - (zastave_Tesko / 60) * 60).ToString("00");

        mape_Lako = PlayerPrefs.GetInt("21Rekord");
        mapeLako.text = (mape_Lako / 60).ToString("00") + ":" + (mape_Lako - (mape_Lako / 60) * 60).ToString("00");

        mape_Srednje = PlayerPrefs.GetInt("22Rekord");
        mapeSrednje.text = (mape_Srednje / 60).ToString("00") + ":" + (mape_Srednje - (mape_Srednje / 60) * 60).ToString("00");

        mape_Tesko = PlayerPrefs.GetInt("23Rekord");
        mapeTesko.text = (mape_Tesko / 60).ToString("00") + ":" + (mape_Tesko - (mape_Tesko / 60) * 60).ToString("00");

        grbovi_Lako = PlayerPrefs.GetInt("31Rekord");
        grboviLako.text = (grbovi_Lako / 60).ToString("00") + ":" + (grbovi_Lako - (grbovi_Lako / 60) * 60).ToString("00");

        grbovi_Srednje = PlayerPrefs.GetInt("32Rekord");
        grboviSrednje.text = (grbovi_Srednje / 60).ToString("00") + ":" + (grbovi_Srednje - (grbovi_Srednje / 60) * 60).ToString("00");

        grbovi_Tesko = PlayerPrefs.GetInt("33Rekord");
        grboviTesko.text = (grbovi_Tesko / 60).ToString("00") + ":" + (grbovi_Tesko - (grbovi_Tesko / 60) * 60).ToString("00");
    }
}
