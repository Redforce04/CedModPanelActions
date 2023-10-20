using System;
using System.Collections.Generic;
using System.Linq;

namespace PanelActions
{
    public class ActionManager
    {
        static ActionManager()
        {
            RegisteredActions = new List<Action>();
        }
        public static List<Action> RegisteredActions { get; set; }

        public static T GetAction<T>() where T : Action
        {
            return (T)RegisteredActions.First(action => action is T);
        }

        public static Action? GetAction(Type type)
        {
            if (type.BaseType != typeof(Action))
            {
                return null;
            }

            return RegisteredActions.FirstOrDefault(action => action.GetType() == type);
        }

        public static Action? GetAction(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            return RegisteredActions.FirstOrDefault(action => action.Name.ToLower().Contains(name.ToLower()));
        }
    }
}