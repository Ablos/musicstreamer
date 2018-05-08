/*
 * (c) Abel Dieterich - HotkeyCode Inc.
 */

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Windows
{
	public class FileManager
	{
		/// <summary>
		/// Load a class from file.
		/// </summary>
		/// <typeparam name="Class"></typeparam>
		/// <param name="Path to saved file"></param>
		/// <returns></returns>
		public T DeserializeFile<T>(string path)
		{
			if (!File.Exists(path))
				return default(T);

			BinaryFormatter formatter = new BinaryFormatter();
			FileStream saveFile = File.Open(path, FileMode.Open);

			T deserialized = (T)formatter.Deserialize(saveFile);

			saveFile.Close();

			return deserialized;
		}

		/// <summary>
		/// Saves a class to a file.
		/// </summary>
		/// <typeparam name="Class"></typeparam>
		/// <param name="Class to save"></param>
		/// <param name="Directory to save in"></param>
		/// <param name="Filename for the save file"></param>
		public void SerializeFile<T>(T classToSave, string directory, string filename)
		{
			Console.WriteLine(directory);

			if (!Directory.Exists(directory))
			{
				Console.WriteLine("Directory does not exist, creating now");
				Directory.CreateDirectory(directory);
			}

			BinaryFormatter formatter = new BinaryFormatter();
			FileStream saveFile = File.Create(directory + "/" + filename);

			formatter.Serialize(saveFile, classToSave);

			saveFile.Close();
		}
	}
}
