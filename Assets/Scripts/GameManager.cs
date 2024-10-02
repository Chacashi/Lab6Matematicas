using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private int maxLife;
    [SerializeField] private int currentLife;
    [SerializeField] private int damageEnemys;
    public TMP_Text lifeText;
    public TMP_Text timerText;
    public float currentTime;

    private void Update()
    {
        currentTime += Time.deltaTime;

        UpdateTimer();

    }

    void UpdateTimer()
    {

        timerText.text = "Puntos: "+ Mathf.FloorToInt(currentTime);
    }
    public void ChangueLifeMax(float maxLife)
    {
        lifeText.text = "Vida: " + maxLife;
    }

    public void ChangueCurrentLife(float currentLife)
    {
        lifeText.text = "Vida: " + currentLife;
    }

    public void SetLife(float currentLife)
    {
        ChangueCurrentLife(currentLife);
        ChangueLifeMax(currentLife);
    }

    public int GetDamageEnemys() { return damageEnemys; }

    void Start()
    {
         currentTime = 0.0f;
        currentLife = maxLife;
       SetLife(currentLife);


    }
}
