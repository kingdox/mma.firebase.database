#region Access
using System;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
#endregion
namespace MMA.Firebase_Database
{
    public static partial class Key
    {
        // public const string _   = KeyData._;
        public static string Subscribe = "Firebase_Database_Subscribe";
    }
    public static partial class Import
    {
        //public const string _ = _;
    }
    public sealed partial class Firebase_Database_Module : Module
    {
        #region References
        //[Header("Applications")]
        //[SerializeField] public ApplicationBase interface_Business_Firebase_Database_Module_Subscribe;
        private Dictionary<string, Action<object>> _dic_subscriptions = new Dictionary<string, Action<object>>();
        #endregion
        #region Reactions ( On___ )
        // Contenedor de toda las reacciones del Business_Firebase_Database_Module_Subscribe
        #endregion
        #region Methods
        // Contenedor de toda la logica del Business_Firebase_Database_Module_Subscribe
        private void Subscribe((string path, bool condition, Action<object> callback) data)
        {
            string[] paths = data.path.Split('/');
            //Debug.Log($"Subscribe | {data.path}");

            if (data.condition)
            {
                //Si NO existe se añade
                if (!_dic_subscriptions.ContainsKey(data.path))
                {
                    _dic_subscriptions.Add(data.path, default);
                    GetDatabaseReference(data.path).ValueChanged += HandleValueChanged;
                }
                _dic_subscriptions[data.path] += data.callback;
            }
            else if (_dic_subscriptions.ContainsKey(data.path))
            {
                _dic_subscriptions[data.path] -= data.callback;

                //Si no hay ninguno solicitando lo elimina del diccionario
                if (_dic_subscriptions[data.path] == null)
                {
                    _dic_subscriptions.Remove(data.path);
                    GetDatabaseReference(data.path).ValueChanged -= HandleValueChanged;
                }
            }
        }
        private void HandleValueChanged(object sender, ValueChangedEventArgs args)
        {
            //Debug.Log(".....");
            if (args.DatabaseError != null)
            {
                Debug.LogError(args.DatabaseError.Message);
                return;
            }
            //Debug.Log($"Invoked {sender}");

            string stringLinkPath = args.Snapshot.Reference.ToString();
            string _matcher = "//";
            int index = stringLinkPath.LastIndexOf(_matcher);
            stringLinkPath = stringLinkPath.Remove(0, index + _matcher.Length);

            //Hacemos Invoke del value 
            _dic_subscriptions[stringLinkPath]?.Invoke(args.Snapshot.Value);
        }
        #endregion
        #region Request ( Coroutines )
        // Contenedor de toda la Esperas de corutinas del Business_Firebase_Database_Module_Subscribe
        #endregion
        #region Task ( async )
        // Contenedor de toda la Esperas asincronas del Business_Firebase_Database_Module_Subscribe
        #endregion
    }
}
