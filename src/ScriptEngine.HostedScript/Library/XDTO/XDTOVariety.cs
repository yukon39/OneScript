/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    public class XDTOVariety : EnumerationValue
    {
        public XDTOVariety(EnumerationXDTOVariety owner, string value) : base(owner) => ValuePresentation = value;

        private static XDTOVariety GetValue(string value)
        {
            EnumerationXDTOVariety enumeration = GlobalsManager.GetEnum<EnumerationXDTOVariety>();
            return enumeration.GetValue(value);
        }
        
        public static XDTOVariety Atomic => GetValue(EnumerationXDTOVariety.XDTOVariety_Atomic);

        public static XDTOVariety Union => GetValue(EnumerationXDTOVariety.XDTOVariety_Union);

        public static XDTOVariety List => GetValue(EnumerationXDTOVariety.XDTOVariety_List);
    }

    [SystemEnum("XDTOVariety", "ВариантXDTO")]
    public class EnumerationXDTOVariety : EnumerationContext
    {
        internal const string XDTOVariety_Atomic = "Atomic";
        internal const string XDTOVariety_Union = "Union";
        internal const string XDTOVariety_List = "List";

        private EnumerationXDTOVariety(TypeDescriptor typeRepresentation, TypeDescriptor valuesType)
           : base(typeRepresentation, valuesType)
        {
        }

        public static EnumerationXDTOVariety CreateInstance()
        {
            TypeDescriptor type = TypeManager.RegisterType("EnumerationXDTOVariety", typeof(EnumerationXDTOVariety));
            TypeDescriptor enumValueType = TypeManager.RegisterType("XDTOVariety", typeof(XDTOVariety));

            TypeManager.RegisterAliasFor(type, "ПеречислениеВариантXDTO");
            TypeManager.RegisterAliasFor(enumValueType, "ВариантXDTO");

            EnumerationXDTOVariety instance = new EnumerationXDTOVariety(type, enumValueType);

            instance.AddValue("Атомарный", "Atomic", new XDTOVariety(instance, XDTOVariety_Atomic));
            instance.AddValue("Объединение", "Union", new XDTOVariety(instance, XDTOVariety_Union));
            instance.AddValue("Список", "List", new XDTOVariety(instance, XDTOVariety_List));

            return instance;
        }

        internal XDTOVariety GetValue(string name)
        {
            int id = FindProperty(name);
            return GetPropValue(id) as XDTOVariety;
        }
    }
}
