using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (menuName = "Narrative")]
public class Narrative : ScriptableObject
{
     public string id;
     public Color color = Color.white;
     [TextArea (minLines:7, maxLines: 7)]
     [SerializeField] private string line;
     [SerializeField] private string person;
     public SimpleAudioEvent _audio;
     public string _event;

     public string GetLine()
     {
          if (_event != "")
          {
               EventManager.TriggerEvent(_event);
          }
          
          if (_audio != null)
          {
               FindObjectOfType<AudioSourcePoolManager>().PlayAudioEvent(_audio);
          }

          if (person != "")
          {
               return person + ": " + line;
          }
          return line;
     }
}
