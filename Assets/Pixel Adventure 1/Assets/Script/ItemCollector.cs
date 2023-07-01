using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int BananaCount=0;
    [SerializeField] private Text bananaCounter;

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Banana")){
            Destroy(collision.gameObject);
            BananaCount++;
            bananaCounter.text="Bananas: "+ BananaCount;
        }

    }
}
