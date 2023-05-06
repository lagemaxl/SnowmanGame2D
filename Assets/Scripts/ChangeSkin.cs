using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField] private List<Sprite> images; // Seznam obrázkù
    [SerializeField] private string skinName; // Název skinu pro uložení do editoru
    private SpriteRenderer targetObject; // Cílový objekt, na kterém chceme mìnit obrázek
    private int currentImageIndex = 0; // Index aktuálního obrázku

    private void Awake()
    {
        // Získáme SpriteRenderer ze stejného objektu, ke kterému je tento skript pøipojen
        targetObject = GetComponent<SpriteRenderer>();

        // Pokud existuje uložený skin pro tento objekt, zobrazíme ho
        if (PlayerPrefs.HasKey(skinName))
        {
            int savedIndex = PlayerPrefs.GetInt(skinName);
            if (savedIndex >= 0 && savedIndex < images.Count)
            {
                currentImageIndex = savedIndex;
                targetObject.sprite = images[currentImageIndex];
            }
        }
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

        // Uložíme index nového obrázku pro tento skin
        PlayerPrefs.SetInt(skinName, currentImageIndex);
    }
}
