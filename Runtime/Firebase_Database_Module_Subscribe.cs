#region Access
using System;
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
        //private static readonly Dictionary<string, ( EventHandler<ValueChangedEventArgs> eventEval, Action<object> valueChangeCast)> _dic_subscriptions = new Dictionary<string, (EventHandler<ValueChangedEventArgs> eventEval, Action<object> valueChangeCast)>();
        #endregion
        #region Reactions ( On___ )
        // Contenedor de toda las reacciones del Business_Firebase_Database_Module_Subscribe
        #endregion
        #region Methods
        // Contenedor de toda la logica del Business_Firebase_Database_Module_Subscribe
        private void Subscribe((string pathKey, bool condition, Action<object> callback) data)
        {
            string[] paths = data.pathKey.Split('/');
            string uniqueKey = paths[paths.Length - 1];
            Debug.Log($"Subscribe | {uniqueKey}");
            //if (data.condition)
            //{
            //    //Si NO existe se añade
            //    if (!_dic_subscriptions.ContainsKey(uniqueKey))
            //    {
                    
            //        _dic_subscriptions.Add(uniqueKey, default);
            //        EventHandler<ValueChangedEventArgs> a =
            //        GetDatabaseReference(uniqueKey).ValueChanged += HandleValueChanged;
            //    }
            //    _dic_subscriptions += data.callback;
            //}
            //else if (_dic_subscriptions.ContainsKey(uniqueKey))
            //{
            //    _dic_subscriptions[uniqueKey] -= data.callback;

            //    //Si no hay ninguno solicitando lo elimina del diccionario
            //    if (_dic_subscriptions[uniqueKey] == null)
            //    {
            //        _dic_subscriptions.Remove(uniqueKey);
            //        GetDatabaseReference(uniqueKey).ValueChanged -= HandleValueChanged;
            //    }
            //}
        }
        private void HandleValueChanged(object sender, ValueChangedEventArgs args)
        {
            //Debug.Log(".....");
            //if (args.DatabaseError != null)
            //{
            //    Debug.LogError(args.DatabaseError.Message);
            //    return;
            //}
            //Debug.Log("Invoked");
            ////Envía el dato suscrito
            //_dic_subscriptions[args.Snapshot.Key]?.Invoke(args.Snapshot.Value);
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


//TODO ver mañana
