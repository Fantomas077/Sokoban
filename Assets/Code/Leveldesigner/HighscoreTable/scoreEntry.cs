using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable()]
public class scoreEntry // kein MonoBehaviour, da zu Serialisieren
{
    public scoreEntry(string _levelID,string _player, double _points) { this.levelID = _levelID; this.player = _player; this.points = _points; }

    /////////////////////////////////////////Properties//////////////////////////////////////////////////////////////////////////////////////////
    public string levelID   { get; set; }
    public string player { get; set; }
    public double points { get; set; }
        
}
