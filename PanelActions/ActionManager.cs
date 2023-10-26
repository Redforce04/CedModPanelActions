using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using PanelActions.Attributes;
using PanelActions.Attributes.Modals;
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
            var selections = actions.Where(x => x.Attribute is MenuSelectionAttribute).ToList();
            for (int i = 0; i < selections.Count; i++)
            {
                var menuAttribute = (MenuSelectionAttribute)selections[i].Attribute;
                if (menuAttribute.MenuSelection.MenuAction == null)
                {
                    //if(selections[i] )
                }
            }

            Dictionary<AbstractedTypeExtensions.AttributeResult, string> removeThese =
                new Dictionary<AbstractedTypeExtensions.AttributeResult, string>();
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
                    case ModalAttribute modal:
                        if (!ProcessModal(attribute, ref modal, out string skipReason))
                        {
                            removeThese.Add(attribute, skipReason);
                            goto skip;
                        }

                        break;
                    case SelectionAttribute selection:
                        if (!ProcessSelection(attribute, ref selection, out skipReason))
                        {
                            removeThese.Add(attribute, skipReason);
                            goto skip;
                        }
                        
                        break;
                    case SliderAttribute:
                        break;
                }

                skip:
                continue;
            }

            foreach (var removal in removeThese)
            {
                actions.Remove(removal.Key);
                Logging.Log($"{removal.Value}", LogLevel.Warn);
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
            if (!_registeredActions.Contains(action))
                _registeredActions.Add(action);
        }

        internal static void UnRegisterAction(Action action)
        {
            if (_registeredActions.Contains(action))
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

        private static bool ProcessModal(AbstractedTypeExtensions.AttributeResult attribute, ref ModalAttribute modal,
            out string skipReason)
        {
            skipReason = "";
            if (attribute is AbstractedTypeExtensions.MethodAttributeResult method)
            {
                foreach (var parameter in method.MethodInfo.GetParameters())
                {
                    var modalItem = parameter.GetCustomAttribute<ModalItemAttribute>();
                    if (modalItem is null && !parameter.HasDefaultValue)
                    {
                        skipReason =
                            "Every parameter in a [Modal] method must have one of the following attributes: [ModalItem] [ModalBool] [ModalEnum] [ModalString] [ModalSlider]. Otherwise, we cannot call the method because the ActionAPI lacks some of the required parameters.";
                        return false;
                    }

                    if (modalItem is null)
                    {
                        return true;
                    }

                    if (parameter.HasDefaultValue &&
                        modalItem is ModalEnumAttribute &&
                        modalItem.Item is ModalEnum { PlaceholderValue: "" } modalEnum)
                    {
                        modalEnum.PlaceholderValue = ((Enum)parameter.DefaultValue)?.ToString();
                    }

                    if (modalItem.Item is null || modalItem.ItemType == ModalItemType.AutoAssign)
                    {
                        string displayName = modalItem.DisplayName;
                        string name = modalItem.Item?.Name ?? modalItem.DisplayName;
                        string description = modalItem.DisplayDescription;
                        // cant switch this because of constant values.
                        if (parameter.ParameterType.IsEnum)
                        {
                            modalItem.ItemType = ModalItemType.Enum;
                            modalItem.Item = new ModalEnum(name, displayName, parameter.ParameterType,
                                parameter.HasDefaultValue ? ((Enum)parameter.DefaultValue)?.ToString() : "",
                                description);
                        }
                        else if (parameter.ParameterType == typeof(string))
                        {
                            modalItem.ItemType = ModalItemType.String;
                            modalItem.Item = new ModalString(name, displayName, description,
                                parameter.HasDefaultValue ? ((string)parameter.DefaultValue) : "", "");
                        }
                        else if (parameter.ParameterType == typeof(bool))
                        {
                            modalItem.ItemType = ModalItemType.Bool;
                            modalItem.Item = new ModalBool(name, displayName, description,
                                parameter.HasDefaultValue && parameter.DefaultValue is not null &&
                                ((bool)parameter.DefaultValue));
                        }
                        else if (parameter.ParameterType == typeof(int) ||
                                 parameter.ParameterType == typeof(decimal) ||
                                 parameter.ParameterType == typeof(uint) ||
                                 parameter.ParameterType == typeof(short) ||
                                 parameter.ParameterType == typeof(ushort) ||
                                 parameter.ParameterType == typeof(byte) ||
                                 parameter.ParameterType == typeof(float))
                        {
                            modalItem.ItemType = ModalItemType.Slider;
                            float defaultValue = 0f;
                            if (parameter.HasDefaultValue && parameter.DefaultValue is not null)
                            {
                                float.TryParse(parameter.DefaultValue.ToString(), out defaultValue);
                            }

                            modalItem.Item = new ModalSlider(name, displayName, description,
                                defaultValue,
                                defaultValue < 0 ? defaultValue : 0,
                                defaultValue > 100 ? defaultValue : 100,
                                parameter.ParameterType == typeof(int));
                        }
                        else
                        {
                            skipReason = $"Modal cannot auto-detect the ModalType for parameter \"{parameter.Name}\" ({modalItem.DisplayName}). Try manually setting it.";
                            return false;
                        }
                    }

                    modalItem.Item.Parent = modal.Modal;
                    modal.Modal.AddModalField(modalItem.Item);
                }


            }
                return true;
        }

        private static bool ProcessSelection(AbstractedTypeExtensions.AttributeResult attribute,
            ref SelectionAttribute selection,
            out string skipReason)
        {
            skipReason = "";
            var methodAttribute = (AbstractedTypeExtensions.MethodAttributeResult)attribute;
            var param = methodAttribute.MethodInfo.GetParameters();
            if (param.Length < 1)
            {
                skipReason = $"There must be at least one parameter for a Selection Attribute ({selection.DisplayName}).";
                return false;
            }

            switch (selection.Selection.SelctionValue)
            {
                case SelectionValue.Enum:
                    if (!param[0].ParameterType.IsEnum)
                    {
                        skipReason = $"SelectionValues that are set to Enum must have an Enum as the first parameter of the argument. ({selection.DisplayName})";
                        return false;
                    }
                    break;
                case SelectionValue.Player:
                    if (param[0].ParameterType.Name.ToLower() != "player")
                    {
                        skipReason = $"SelectionValues that are set to Player must have a Player or a list of players as the first parameter of the argument. ({selection.DisplayName})";
                        return false;
                    }
                    break;
                case SelectionValue.Role:
                    if (param[0].ParameterType.Name.ToLower() != "roletypeid")
                    {
                        skipReason = $"SelectionValues that are set to Role must have RoleTypeId or a list of RoleTypeId's as the first parameter of the argument. ({selection.DisplayName})";
                        return false;
                    }
                    break;
                case SelectionValue.Team:
                    if (param[0].ParameterType.Name.ToLower() != "team" && !(
                            param[0].ParameterType.BaseType == typeof(List<>) &&
                            param[0].ParameterType.BaseType.GetGenericArguments().Length >= 1 && 
                            param[0].ParameterType.BaseType.GetGenericArguments()[0].Name.ToLower() == "team"))
                    {
                        skipReason = $"SelectionValues that are set to Team must have Team or a list of Teams as the first parameter of the argument. ({selection.DisplayName})";
                        return false;
                    }
                    break;
                case SelectionValue.Number:
                    var numType = param[0].ParameterType.BaseType;
                    if (IsNumber(numType?.Name.ToLower()))
                    {
                        skipReason = $"SelectionValues that are set to Number must have a Number or a list of numbers as the first parameter of the argument. ({selection.DisplayName})";
                        return false;
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            if (selection.Selection.SelctionValue == SelectionValue.AutoSelect)
            {
                
            }

            return true;
        }

        private static bool IsNumber(string typeName) => typeName switch
        {
            "byte" => true,
            "int" => true,
            "float" => true,
            "decimal" => true,
            "uint" => true,
            "ushort" => true,
            "short" => true,
            _ => false,
        };
    }
    /*Player,
    PlayerList,
    Role,
    RoleList,
    Team,
    TeamList,
    String,
    Int,
    Float,
    Bool,
    Enum,*/
}