using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour
{
    [SerializeField] private List<Sprite> images; // Seznam obr�zk�
    [SerializeField] private string skinName; // N�zev skinu pro ulo�en� do editoru
    private SpriteRenderer targetObject; // C�lov� objekt, na kter�m chceme m�nit obr�zek
    private int currentImageIndex = 0; // Index aktu�ln�ho obr�zku

    private void Awake()
    {
        // Z�sk�me SpriteRenderer ze stejn�ho objektu, ke kter�mu je tento skript p�ipojen
        targetObject = GetComponent<SpriteRenderer>();

        // Pokud existuje ulo�en� skin pro tento objekt, zobraz�me ho
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

    // Metoda pro zm�nu obr�zku
    public void Change()
    {
        // Zv���me index aktu�ln�ho obr�zku a ov���me, zda jsme p�ekro�ili po�et obr�zk� v seznamu
        currentImageIndex++;
        if (currentImageIndex >= images.Count)
        {
            currentImageIndex = 0;
        }

        // Nastav�me nov� obr�zek na c�lov�m objektu
        targetObject.sprite = images[currentImageIndex];

        // Ulo��me index nov�ho obr�zku pro tento skin
        PlayerPrefs.SetInt(skinName, currentImageIndex);
    }
}
