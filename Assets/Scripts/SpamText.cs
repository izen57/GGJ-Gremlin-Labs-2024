using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LetterSO", menuName = "Scriptable Objects/ Letter")]
public class SpamText : ScriptableObject
{
    [SerializeField] string spam; 
    /*{"Hello this is MeisterBank. We are here to inform you that you have 454 dolllars of debt. Please contact within the 24 hours or we will take away your steam account.",
    "Hello this is Michael to talk about your car's extended warranty. It says here umm... hmm... (inhales), it says you're a pussy. (Duke Nukem outro playing)",
    "Hey man, I got good news. TF2 got a major update.",
    "https://theuselessweb.com - You might enjoy this",
    "Hi I'm your local shower shitter. Check your shower.",};*/
}
