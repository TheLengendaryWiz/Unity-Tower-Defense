using UnityEngine;

public class playerStats : MonoBehaviour
{
    public static int Money;
    public static int lives;
    public int StartMoney = 400;
    public int Startlives = 20;
    public static int rounds;
    private void Start()
    {
        Money = StartMoney;
        lives = Startlives;
        rounds = 0;
    }
}