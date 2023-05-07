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
    public void Change(bool forward)
    {
        if (forward)
        {
            currentImageIndex++;
            if (currentImageIndex >= images.Count)
            {
                currentImageIndex = 0;
            }
        }
        else
        {
            currentImageIndex--;
            if (currentImageIndex < 0)
            {
                currentImageIndex = images.Count - 1;
            }
        }

        targetObject.sprite = images[currentImageIndex];
        PlayerPrefs.SetInt(skinName, currentImageIndex);
    }
}
