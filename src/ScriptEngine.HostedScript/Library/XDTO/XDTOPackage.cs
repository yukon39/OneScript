/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScriptEngine.HostedScript.Library.XMLSchema;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    [ContextClass("ПакетXDTO", "XDTOPackage")]
    public class XDTOPackage : AutoContext<XDTOPackage>, ICollectionContext, IEnumerable<IXDTOType>
    {
        private readonly List<IXDTOType> _items;

        private XDTOPackage()
        {
            _items = new List<IXDTOType>();
            Dependencies = new XDTOPackageCollection();
            RootProperties = new XDTOPropertyCollection();
        }

        internal XDTOPackage(XMLSchema.XMLSchema schema, XDTOFactory factory) 
            : this()
        {
            AttributeFormQualified = schema.AttributeFormDefault == XSForm.Qualified;
            ElementFormQualified = schema.ElementFormDefault == XSForm.Qualified;
            NamespaceURI = schema.TargetNamespace;
            
            foreach (IXSType type in schema.TypeDefinitions)
            {
                if (type is XSSimpleTypeDefinition simpleType)
                    _items.Add(new XDTOValueType(simpleType, factory));
            }
        }

        #region OneScript

        #region Properties

        [ContextProperty("URIПространстваИмен", "NamespaceURI")]
        public string NamespaceURI { get; }

        [ContextProperty("Зависимости", "Dependencies")]
        public XDTOPackageCollection Dependencies { get; }

        [ContextProperty("КвалифицированнаяФормаАтрибута", "AttributeFormQualified")]
        public bool AttributeFormQualified { get; }

        [ContextProperty("КвалифицированнаяФормаЭлемента", "ElementFormQualified")]
        public bool ElementFormQualified { get; }

        [ContextProperty("КорневыеСвойства", "RootProperties")]
        public XDTOPropertyCollection RootProperties { get; }

        #endregion

        #region Methods

        [ContextMethod("Количество", "Count")]
        public int Count() => _items.Count;

        [ContextMethod("Получить", "Get")]
        public IXDTOType Get(IValue value)
        {
            DataType DataType = value.DataType;
            switch (DataType)
            {
                case DataType.String:
                    return _items.FirstOrDefault(x => x.Name.Equals(value.AsString()));

                case DataType.Number:
                    return _items[(int)value.AsNumber()];

                default:
                    throw RuntimeException.InvalidArgumentType();
            }
        }

        #endregion

        #endregion

        #region ICollectionContext

        public CollectionEnumerator GetManagedIterator() => new CollectionEnumerator(GetEnumerator());

        #endregion

        #region IEnumerator

        public IEnumerator<IXDTOType> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
