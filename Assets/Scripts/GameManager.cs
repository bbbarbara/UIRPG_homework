using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Enemy enemy;
    public int expAmountToLevelUp;
    private int playerExp;
    private int currentLevel;
    private bool isShieldOn;
    [SerializeField] private TMP_Text playerName, playerHealth, enemyName, enemyHealth, playerLevel,toggleShield;
    [SerializeField] private Weapon[] weapons;
    [SerializeField] private Enemy[] enemieTypes;
    public GameObject loseUi;

    void Start()
    {
        loseUi.SetActive(false);
        playerExp = 0;
        currentLevel = 1;
        isShieldOn = false;
        playerName.text = player.CharName;
        enemyName.text = enemy.name;
        UpdateHealth();
        UpdateLevel();
        player.ChangeWeapon(weapons[0]);
    }

    private void UpdateHealth()
    {
        playerHealth.text = player.health.ToString();
        enemyHealth.text = enemy.health.ToString();
        if (player.health <= 0)
        {
            loseUi.SetActive(true);
        }
    }

    public void DoRound()
    {
        //int damage = player.Attack();
        enemy.GetHit(player.Weapon);
        player.Weapon.ApplyEffect(enemy);
        int enemyDamage = enemy.Attack();
        player.GetHit(enemyDamage);
        enemy.Weapon.ApplyEffect(player);
        if (IsEnemyDead())
        {
            NextEnemy();
        }
        UpdateHealth();
        UpdateLevel();
    }

    private void UpdateLevel()
    {
        if (currentLevel < 2 && playerExp >= expAmountToLevelUp)
        {
            Debug.Log("levelup");
            currentLevel++;
        }
        
        if (playerExp >= expAmountToLevelUp * currentLevel * 1.4)
        {
            Debug.Log("levelup");
            currentLevel++;
        }

        playerLevel.text = "Level: " + currentLevel;
    }

    public void ToggleShield()
    {
        isShieldOn = !isShieldOn;
        if (isShieldOn)
        {
            toggleShield.text = "ON";
            toggleShield.color = Color.green;
        }
        else
        {
            toggleShield.text = "OFF";
            toggleShield.color = Color.red;
        }
        // ka so darit talak ?
    }

    public void DropdownSelection(int index)
    {
        player.ChangeWeapon(weapons[index]);
    }

    public void NextEnemy()
    {
        enemy = enemieTypes[Random.Range(0, enemieTypes.Length)];
        enemy.ResetHealth();
        enemyName.text = enemy.name;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private bool IsEnemyDead()
    {
        if (enemy.health<=0)
        {
            playerExp += 10;
            return true;
        }
        return false;
    }

}
