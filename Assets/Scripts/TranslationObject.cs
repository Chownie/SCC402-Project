using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MiniJSON;

[System.Serializable]
public class TranslationObject {
    public enum ApplicableVerbs {
        None,
        Food,
        Liquid,
        Life
    }

    private Dictionary<string, List<string>> Verbs = new Dictionary<string, List<string>>();

    public TranslationObject(string languageCode) {
        TextAsset verbsText = Resources.Load("verbs/" + languageCode) as TextAsset;
        var verbObjects = Json.Deserialize(verbsText.text) as Dictionary<string, object>;
        foreach(KeyValuePair<string, object> verbArr in verbObjects) {
            List<object> listOfVerbs = (List<object>) verbArr.Value;
            Verbs.Add(verbArr.Key, listOfVerbs.Select(s => (string)s).ToList());
        }
        Debug.Log(String.Join("", Verbs[ApplicableVerbs.Food.ToString()].ToArray()));
    }

    public List<string> GetVerbs(string key) {
        return Verbs[key];
    }

    public List<string> GetVerbs(ApplicableVerbs key) {
        return Verbs[key.ToString()];
    }
}

