using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmp;
    public int ElapsedSeconds { get; private set; }
    public event Action<int> Minute;

    private void Awake()
    {
        Provider.Timer = this;
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
            ElapsedSeconds++;
            if (ElapsedSeconds % 60 == 0) Minute?.Invoke(ElapsedSeconds / 60);
            DrawActualTime();
        }
    }

    void DrawActualTime()
    {
        var t = TimeSpan.FromSeconds(ElapsedSeconds);
        tmp.text = $"{t.Minutes}:{t.Seconds}";
    }
}
