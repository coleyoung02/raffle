using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ParseCSV : MonoBehaviour
{
    [SerializeField] private TextAsset csvFile;
    public List<Tuple<float, string, string>> GetOdds()
    {
        List<Tuple<float, string, string>> l = new List<Tuple<float, string, string>>();
        string[] lines = csvFile.text.Split('\n');

        for (int i = 1; i < lines.Length; i++) // Start from index 1 to skip the header
        {
            string line = lines[i].Trim();
            if (line.Length == 0)
            {
                continue;
            }
            string[] fields = line.Split(',');
            string email = fields[0];
            string name = fields[1];
            if (name.Equals("N/A"))
            {
                name = "";
            }
            float tickets = float.Parse(fields[2]);
            l.Add(new Tuple<float, string, string>(tickets, name, email));
        }
        return l;
    }
}
