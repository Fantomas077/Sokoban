using System;

[Serializable()]
public class boxEntry
{
    /////////////////////////////////////////////////////Konstruktoren///////////////////////////////////////////////////////////

    public boxEntry() { }
    
    /////////////////////////////////////////////////////Properties///////////////////////////////////////////////////////////

    /// <summary>
    /// Liefert Objektposition zurück
    /// </summary>
    public float[] Vector { get; set; }

    /// <summary>
    /// Liefert Identifier für Box / Wand / Kreuz
    /// </summary>
    public int _gameObject { get; set; }

}