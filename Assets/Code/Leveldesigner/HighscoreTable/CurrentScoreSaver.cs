using UnityEngine;
using UnityEngine.SceneManagement;


public class CurrentScoreSaver : MonoBehaviour
{
    public string sceneName;
    
    /// <summary>
    /// Fügt derzeitigen Score der HighscoreTable hinzu
    /// </summary>
    public void SaveScore()
    {
            if (GameDesignerManager.LevelComplete())
            {   /*
            
                // Saver an Evaluator GameObject erzeugen
                GameObject eval = GameObject.Find("Evaluator");
                saver Saver = eval.AddComponent(typeof(saver)) as saver;

                // Info's geben, um derzeitigen Score zu liefern & ScoreEntry erstellen
                int steps = GameObject.Find("Evaluator").GetComponent<evaluator>().steps;
                Saver.levelID = LoadHandler.levelNameDistribution;
                Saver.player = Nameneingabe.Saved_Name;

                scoreEntry CurrentScore = new scoreEntry(Saver.levelID, Saver.player, steps);
                

                

                // Vorhandene Liste laden
                Saver.read(LoadHandler.levelNameDistribution);
            
                // currentEntry hinzufügen zu geladener scoreEntry-Liste
                Saver.scoreList.Add(CurrentScore);

                // TESTING //////////////////////////////////////////////////////////////
                scoreEntry E1 = new scoreEntry(Saver.levelID, "Player2", 10);
                scoreEntry E2 = new scoreEntry(Saver.levelID, "Player3", 20);
                Saver.scoreList.Add(E1);
                Saver.scoreList.Add(E2);
            */
                //Nächste Scene laden
                SceneManager.LoadScene(sceneName);


            }
            
    }
}
