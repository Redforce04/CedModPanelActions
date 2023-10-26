using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using PanelActions.Attributes;
using PanelActions.Internal;

namespace PanelActions
{
    public class ActionManager
    {
        static ActionManager()
        {
            _registeredActions = new List<Action>();
            RegisterAttributes();
        }

        public static void Init()
        {
            Logging.Log("Init ActionManager");
        }
        private static void RegisterAttributes()
        {
            var actions = AbstractedTypeExtensions.FindAllInstancesOfAttribute<ActionItemAttribute>();
            //var sliders = AbstractedTypeExtensions.FindAllInstancesOfAttribute<SliderAttribute>();
            Logging.Log($"Found {actions.Count} attributes.");
            foreach (var attribute in actions)
            {
                if (attribute.Attribute is ActionItemAttribute action)
                {
                    if (action.DisplayName == "")
                    {
                        action.DisplayName = attribute.ItemName;
                    }

                    if (action.Name == GetPrefix(action) + "-")
                    {
                        action.Name = attribute.ItemName;
                    }
                }
                switch (attribute.Attribute)
                {
                    case MenuSelectionAttribute menuSelection:
                        break;
                    case ButtonAttribute:
                        break;
                    case MenuAttribute:
                        break;
                    case ModalAttribute:
                        break;
                    case SelectionAttribute:
                        break;
                    case SliderAttribute:
                        break;
                }
            }
        }

        private static string GetPrefix(ActionItemAttribute attribute) => attribute switch
        {
            ButtonAttribute => nameof(Button),
            MenuAttribute => nameof(Menu),
            MenuSelectionAttribute => "",
            ModalAttribute => nameof(Modal),
            SelectionAttribute => nameof(Selection),
            SliderAttribute => nameof(Slider),
            _ => ""
        };
        internal static void RegisterAction(Action action)
        {
            if(!_registeredActions.Contains(action))
                _registeredActions.Add(action);
        }

        internal static void UnRegisterAction(Action action)
        {
            if(_registeredActions.Contains(action))
                _registeredActions.Remove(action);
        }

        private static List<Action> _registeredActions;

        public static ReadOnlyCollection<Action> RegisteredActions
        {
            get => new ReadOnlyCollection<Action>(_registeredActions);

        }

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