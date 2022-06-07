[System.Serializable] public class PlayerData
{
public string playerName;
public int highScore;
    public PlayerData(MainManager mainManager, UIHandler uIHandler)
    {
        highScore = mainManager.m_Points;
        playerName = uIHandler.playerNameInputField.text;
    }
}