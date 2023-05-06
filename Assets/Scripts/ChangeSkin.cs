using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField] private List<Sprite> images; // Seznam obrázkù
    private SpriteRenderer targetObject; // Cílový objekt, na kterém chceme mìnit obrázek
    private int currentImageIndex = 0; // Index aktuálního obrázku

    private void Awake()
    {
        // Získáme SpriteRenderer ze stejného objektu, ke kterému je tento skript pøipojen
        targetObject = GetComponent<SpriteRenderer>();
    }

    // Metoda pro zmìnu obrázku
    public void Change()
    {
        // Zvýšíme index aktuálního obrázku a ovìøíme, zda jsme pøekroèili poèet obrázkù v seznamu
        currentImageIndex++;
        if (currentImageIndex >= images.Count)
        {
            currentImageIndex = 0;
        }

        // Nastavíme nový obrázek na cílovém objektu
        targetObject.sprite = images[currentImageIndex];
    }
}
