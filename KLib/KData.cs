using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace KLib {
	public static class KData {

		#region SUFFIX
		private static string _suffix = ".dat";
		private static string AddSuffix(string bf_name) {
			return bf_name + _suffix;
		}
		#endregion
		
		public static void Save(string bf_name, KObject k_obj) {
			BinaryFormatter bf = new BinaryFormatter ();
			FileStream file = File.Open (Application.persistentDataPath + AddSuffix(bf_name), FileMode.Open);

			bf.Serialize (file, k_obj);
			file.Close ();
		}

		public static KObject Load(string bf_name) {
			string bf_name_with_suffix = AddSuffix (bf_name);
			if (File.Exists (Application.persistentDataPath + bf_name_with_suffix)) {
				BinaryFormatter bf = new BinaryFormatter ();
				FileStream file = File.Open (Application.persistentDataPath + bf_name_with_suffix, FileMode.Open);
				KObject k_obj = (KObject) bf.Deserialize (file);
				file.Close ();
				return k_obj;
			}
			throw new UnityException ("KData.Load: load " + bf_name + ".dat failed: cannot open file or file does not exist");
		}
	}

	#region K OBJECTS

	//Place holder
	public interface IKObject {
	}
		
	/// <summary>
	/// Classes for actual data storage
	/// </summary>
	public class KObject : IKObject {
		public KObject(TYPE type, Type[] prim_types) {
			_type = type;
			foreach (Type a_type in prim_types) {
				if (a_type != typeof(int) || a_type != typeof(float) || a_type != typeof(bool) || a_type != typeof(string) || a_type != typeof(char)) {
					throw new UnityException ("KObject: only types of int, float, bool, string and char allowed!");
				}
			}
			_primitive_types = prim_types;
		}

		/// <summary>
		/// GetType allows downcasting of KObject
		/// </summary>
		private TYPE _type;
		public TYPE GetObjectType() {
			return _type;
		}
		public enum TYPE {
			ARR,
			LIST,
			DICT
		}

		/// <summary>
		/// The primitive types reference. USED JUST IN CASE
		/// </summary>
		private Type[] _primitive_types;
		public Type[] GetPrimitiveTypes() {
			return _primitive_types;
		}
	}
	/// <summary>
	/// Inherited
	/// </summary>
	public class KArrObject<T> : KObject {
		public KArrObject(T[] arr) : base (TYPE.ARR, new Type[1]{typeof(T)}) {
			_arr = arr;
		}
		private T[] _arr;
		public T[] GetData() {
			return _arr;
		}
	}
	public class KListObject<T> : KObject {
		public KListObject(List<T> list) : base (TYPE.LIST, new Type[1]{typeof(T)}) {
			_list = list;
		}
		private List<T> _list;
		public List<T> GetData() {
			return _list;
		}
	}
	public class KDictObject<KeyType, ValType> : KObject {
		public KDictObject(Dictionary<KeyType, ValType> dict) : base (TYPE.DICT, new Type[2]{typeof(KeyType), typeof(ValType)}) {
			_dict = dict;
		}
		private Dictionary<KeyType, ValType> _dict;
		public Dictionary<KeyType, ValType> GetData() {
			return _dict;
		}
	}
	#endregion
}
