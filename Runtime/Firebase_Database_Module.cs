#region Access
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
#endregion
// https://firebase.google.com/docs/database/unity/save-data
namespace MMA.Firebase_Database
{
    public static partial class Key
    {
        // public const string _   = KeyData._;
        public static string Initialize   = "Firebase_Database_Initialize";
        public static string Set   = "Firebase_Database_Set";
        public static string Get   = "Firebase_Database_Get";
    }
    public static partial class Import
    {
        //public const string _ = _;
    }
    public sealed partial class Firebase_Database_Module : Module
    {
        #region References
        //[Header("Applications")]
        //[SerializeField] public ApplicationBase interface_Business_Firebase_Database;
        private FirebaseDatabase _database = default;
        

        #endregion
        #region Reactions ( On___ )
        // Contenedor de toda las reacciones del Business_Firebase_Database
        protected override void OnSubscription(bool condition)
        {
            //Initialize
            Middleware.Subscribe_Publish(condition, Key.Initialize, Initialize);

            //Set
            Middleware<(string path, object value)>.Subscribe_Task(condition, Key.Set, Set);

            //Get
            Middleware<string, object>.Subscribe_Task(condition, Key.Get, Get);
            Middleware<(string path, object defaultValue), object>.Subscribe_Task(condition, Key.Get, Get);

            //Subscribe TODO => Revisar como manejar los id sin que pete
            //Middleware<(string pathKey, bool condition, Action<object> callback)>.Subscribe_Publish(condition, Key.Subscribe, Subscribe);
        }
        #endregion
        #region Methods
        // Contenedor de toda la logica del Business_Firebase_Database
        private void Initialize(){
            _database = FirebaseDatabase.DefaultInstance;
        }

        private DatabaseReference GetDatabaseReference(string path)
        {
            return _database.GetReference(path);
        }
        
        #endregion
        #region Request ( Coroutines )
        // Contenedor de toda la Esperas de corutinas del Business_Firebase_Database
        #endregion
        #region Task ( async )
        // Contenedor de toda la Esperas asincronas del Business_Firebase_Database

        private async Task<object> Get(string path)
        {
            //Debug.Log($"GET {path}");
            DatabaseReference dbref = GetDatabaseReference(path);
            DataSnapshot snapshot = await dbref.GetValueAsync();
            return snapshot.Value;
        }

        private async Task<object> Get((string path, object defaultValue) data)
        {
            object valueToSend = await Get(data.path);

            //Si no recibe datos mandar default
            if (valueToSend == null) return data.defaultValue;

            //Si no es igual el valor recibido que el default, prioridad default
            if (!valueToSend.GetType().Equals(data.defaultValue.GetType())){
                Debug.LogWarning($"[Firebase Database Module]: Alerta path => ({data.path}), no son los mismos tipos, recibido: ({valueToSend}) | default: ({data.defaultValue})");
                return data.defaultValue;
            }

            
            return valueToSend;
        }

        private async Task Set((string path, object value) data)
        {
            //Debug.Log($"SET {data.path} | Value : {data.value}");
            DatabaseReference dbref = GetDatabaseReference(data.path);
            await dbref.SetValueAsync(data.value);
        }
        #endregion
    }
}
