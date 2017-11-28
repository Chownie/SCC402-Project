using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using MiniJSON;

[Serializable]
public class TranslationObject {
    public enum ApplicableVerbs {
        None,
        Food,
        Liquid,
        Furniture
    }

    [Serializable]
    public class Word {
        public String name;
        public String gender;

        public Word(string name, string gender) {
            this.name = name;
            this.gender = gender;
        }
    }

    private Dictionary<string, List<string>> Verbs = new Dictionary<string, List<string>>();
    private Dictionary<string, Word> Words = new Dictionary<string, Word>();
    public TranslationObject(string languageCode) {
        TextAsset verbsText = Resources.Load("verbs/" + languageCode) as TextAsset;
        TextAsset wordsText = Resources.Load("words/" + languageCode) as TextAsset;
        
        var verbObjects = Json.Deserialize(verbsText.text) as Dictionary<string, object>;
        foreach(KeyValuePair<string, object> verbArr in verbObjects) {
            List<object> listOfVerbs = (List<object>) verbArr.Value;
            Verbs.Add(verbArr.Key, listOfVerbs.Select(s => (string)s).ToList());
        }

        var wordObjects = Json.Deserialize(wordsText.text) as Dictionary<string, object>;
        foreach (KeyValuePair<string, object> word in wordObjects) {
            Dictionary<string, object> dictWord = (Dictionary<string, object>)word.Value;
            Word newWord = new Word((string)dictWord["name"], (string)dictWord["gender"]);
            Words.Add(word.Key, newWord);
        }
    }

    public List<string> GetVerbs(string key) {
        return Verbs[key];
    }

    public List<string> GetVerbs(ApplicableVerbs key) {
        return Verbs[key.ToString()];
    }

    public string GetLocalizedGender(string key) {
        key = key.Trim("[]".ToCharArray()).ToLower();
        if (Words.Keys.Contains(key)) {
            return Words[key].gender;
        }
        return "?";
    }

    public string GetLocalizedString(string key) {
        key = key.Trim("[]".ToCharArray()).ToLower();
        if (Words.Keys.Contains(key)) {
            return Words[key].name;
        }
        return String.Format("UNTRANSLATED [{0}]", key);
    }
}

