using System;

[Serializable()]
public class boxEntry
{
    /////////////////////////////////////////////////////Konstruktoren///////////////////////////////////////////////////////////

    public boxEntry() { }
    
    /////////////////////////////////////////////////////Properties///////////////////////////////////////////////////////////

    /// <summary>
    /// Liefert Objektposition zur�ck
    /// </summary>
    public float[] Vector { get; set; }

    /// <summary>
    /// Liefert Identifier f�r Box / Wand / Kreuz
    /// </summary>
    public int _gameObject { get; set; }

}