using Sirenix.OdinInspector;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDatabase", menuName = "Character/CharacterDatabase")]
public class CharacterScriptableObjects : SerializedScriptableObject
{
    private int selectedChracter = 0;
	
    public CharacterStats[] characterList;

    public void UpdateUnlockedCharacters(int[] unlockedArray)
    {
        foreach (CharacterStats character in characterList)
        {
            character.isUnlocked = false;
        }

        for (int i = 0; i < unlockedArray.Length; i++)
        {
            foreach (CharacterStats character in characterList)
            {
                if(character.characterNumber == unlockedArray[i])
                {
                    character.isUnlocked = true;
                }
            }
        }
    }
	
    public void UpdateSelectedCharacters(int selectedChar) => selectedChracter = selectedChar;
    
	public void SetCurrentCharacter()
    {
        // Sets and saves the current selected chracter
    }

    public string GetCurrentCharacterAudio()
    {
        return characterList[selectedChracter].powerUpAudioName;
    }

    public Vector3 GetCurrentCharacterPos()
    {
        return characterList[selectedChracter].oriPos;
    }

    public GameObject GetCurrentCharacter()
    {
        // Gets the currently saved character
        return characterList[selectedChracter].characterPrefab;
    }

    public int GetCurrentCharacterID()
    {
        return selectedChracter;
    }
}

[System.Serializable]
public class CharacterStats
{
    public int characterNumber;
    public GameObject characterPrefab;
    public int characterCost;
    public Sprite iconSprite;
    public Sprite envSprite;
    public bool isUnlocked;
    public string powerUpAudioName;
    public Vector3 oriPos;
}
