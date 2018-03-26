using System.Collections.Generic;
namespace BasicNavigation
{
    public static class AppState
    {
        private static Dictionary<string, bool> state = new Dictionary<string, bool>();
        public static bool GetState(string pageName) => state.ContainsKey(pageName) ? state[pageName] : false;
        public static void SetState(string pageName, bool isBold)
        {
            if (state.ContainsKey(pageName))
                state[pageName] = isBold;
            else
                state.Add(pageName, isBold);
        }
        public static void Save()
        {
            var settings = Windows.Storage.ApplicationData.Current.RoamingSettings;
            foreach (var key in state.Keys)
            {
                settings.Values[key] = state[key];
            }
        }
        public static void Load(string pageName)
        {
            if (!state.ContainsKey(pageName) && Windows.Storage.ApplicationData.Current.RoamingSettings.Values.ContainsKey(pageName))
                state.Add(pageName, (bool)Windows.Storage.ApplicationData.Current.RoamingSettings.Values[pageName]);
        }
    }
}
