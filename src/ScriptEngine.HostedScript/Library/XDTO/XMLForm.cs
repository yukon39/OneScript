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
    public class XMLForm : EnumerationValue
    {
        internal XMLForm(EnumerationXMLForm owner, string value) : base(owner) => ValuePresentation = value;

        private static XMLForm GetValue(string value)
        {
            EnumerationXMLForm xmlFormEnumeration = GlobalsManager.GetEnum<EnumerationXMLForm>();
            return xmlFormEnumeration.GetValue(value);
        }

        public static XMLForm Attribute => GetValue(EnumerationXMLForm.XMLForm_Attribute);

        public static XMLForm Element => GetValue(EnumerationXMLForm.XMLForm_Element);

        public static XMLForm Text => GetValue(EnumerationXMLForm.XMLForm_Text);
    }

    [SystemEnum("XMLForm", "ФормаXML")]
    public class EnumerationXMLForm : EnumerationContext
    {
        internal const string XMLForm_Attribute = "Attribute";
        internal const string XMLForm_Element = "Element";
        internal const string XMLForm_Text = "Text";

        private EnumerationXMLForm(TypeDescriptor typeRepresentation, TypeDescriptor valuesType)
           : base(typeRepresentation, valuesType)
        {
        }

        public static EnumerationXMLForm CreateInstance()
        {
            TypeDescriptor type = TypeManager.RegisterType("EnumerationXMLForm", typeof(EnumerationXMLForm));
            TypeDescriptor enumValueType = TypeManager.RegisterType("XMLForm", typeof(XMLForm));

            TypeManager.RegisterAliasFor(type, "ПеречислениеФормаXML");
            TypeManager.RegisterAliasFor(enumValueType, "ФормаXML");

            EnumerationXMLForm instance = new EnumerationXMLForm(type, enumValueType);

            instance.AddValue("Атрибут", "Attribute", new XMLForm(instance, XMLForm_Attribute));
            instance.AddValue("Элемент", "Element", new XMLForm(instance, XMLForm_Element));
            instance.AddValue("Текст", "Text", new XMLForm(instance, XMLForm_Text));

            return instance;
        }

        internal XMLForm GetValue(string name)
        {
            int id = FindProperty(name);
            return GetPropValue(id) as XMLForm;
        }
    }
}
