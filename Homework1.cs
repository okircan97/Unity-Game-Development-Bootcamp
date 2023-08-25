using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Homework1 : MonoBehaviour
{
    // Int değişkenleri.
    int health = 10;
    int health1 = 5;
    int health2 = 1;
    int health3 = 0;

    // Float değişkenleri.
    float damage = 134.3f;
    float damage1 = 76.5f;
    float damage2 = 27.7f;
    float damage3 = 56.78f;

    // String değişkenleri.
    string str1 = "BuUzuncaBirString.";

    void Start()
    {
        Debug.Log("");
        Debug.Log("1. Method");
        Debug.Log("");
        DamagePlayer(health);
        DamagePlayer(health1);
        DamagePlayer(health2);
        DamagePlayer(health3);

        Debug.Log("");
        Debug.Log("2. Method");
        Debug.Log("");
        GuessTheWeapon(damage);
        GuessTheWeapon(damage1);
        GuessTheWeapon(damage2);
        GuessTheWeapon(damage3);

        Debug.Log("");
        Debug.Log("3. Method");
        Debug.Log("");
        PrintStrCharByChar(str1);
    }

    // Bu method oyuncunun canı 1 veya birden fazla ise hasar
    // vermek için. (METHOD 1)
    int DamagePlayer(int hp)
    {
        if (hp >= 10)
        {
            hp--;
            Debug.Log("Daha çok canın var. Can: " + hp);
            return hp;
        }

        else if (5 >= hp && 1 < hp)
        {
            hp--;
            Debug.Log("Canın az kaldı. Can: " + hp);
            return hp;
        }

        else if (1 == hp)
        {
            hp--;
            Debug.Log("Canın kalmadı. Can: " + hp);
            return hp;
        }

        else
        {
            Debug.Log("Canın hasar verebilmem için çok az.");
            return 0;
        }
    }

    // Bu method silahın verdiği hasara bakarak türünü tahmin
    // etmek için. (METHOD 2)
    void GuessTheWeapon(float damage)
    {
        switch (damage)
        {
            case 134.3f:
                Debug.Log("Bu bir çelik balta!");
                break;
            case 76.5f:
                Debug.Log("Bu bir demir kılıç!");
                break;
            case 27.7f:
                Debug.Log("Bu paslı bir hançer!");
                break;
            default:
                Debug.Log("Bu silahın türünü algılayamıyorum.");
                break;
        }
    }


    // Bu method verilen bir stringi, stringin 1. harfinden
    // başlayıp, string'in uzunluğuna gelene kadar harf sayısını 
    // her defasında arttırarak basmak için. (METHOD 3)
    void PrintStrCharByChar(string str)
    {
        int i = 0;
        string newStr = "";
        while (i < str.Length)
        {
            newStr += str[i];
            i++;
            Debug.Log(newStr);
        }
    }
}