using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    int elapsedSeconds;

    private void Awake()
    {
        Provider.TimeManager = this;
    }

    private void Start()
    {
        StartCoroutine(ManageTime());
    }

    IEnumerator ManageTime()
    {
        var wfs = new WaitForSeconds(1);
        while (true)
        {
            yield return wfs;
            elapsedSeconds++;
            var t = TimeSpan.FromSeconds(elapsedSeconds);
            tmp.text = $"{t.Minutes}:{t.Seconds}";
        }
    }
}
