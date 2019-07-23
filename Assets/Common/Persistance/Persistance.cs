using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

namespace OnBoard.Persistance {

    public class Persistance
    {
        public static T BinaryLoad<T>(string filename)
        {
            string contentPath = Application.persistentDataPath;
            string destination = Path.Combine(contentPath, filename);
            Debug.Log(destination);
            FileStream file;

            if (File.Exists(destination))
            {
                file = File.OpenRead(destination);
            }
            else
            {
                return default(T);
            }

            BinaryFormatter bf = new BinaryFormatter();
            T data = (T)bf.Deserialize(file);
            file.Close();

            return data;
        }

        public static void BinarySave(string filename, object data)
        {
            string contentPath = Application.persistentDataPath;
            string destination = Path.Combine(contentPath, filename);
            FileStream file;

            if (File.Exists(destination))
            {
                file = File.OpenWrite(destination);
            }
            else
            {
                file = File.Create(destination);
            }

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, data);
            file.Close();
        }
    }
}
