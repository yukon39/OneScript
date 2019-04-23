﻿/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using System;
using ScriptEngine.HostedScript.Library.XMLSchema;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    [ContextClass("ТипЗначенияXDTO", "XDTOValueType")]
    public class XDTOValueType : AutoContext<XDTOValueType>, IXDTOType
    {
        internal XDTOValueType(XSSimpleTypeDefinition typeDefinition)
        {
            NamespaceURI = typeDefinition.NamespaceURI;
            Name = typeDefinition.Name;
            if (typeDefinition.Variety == XSSimpleTypeVariety.Atomic)
            {
                Variety = XDTOVariety.Atomic;
            }
            else if (typeDefinition.Variety == XSSimpleTypeVariety.List)
            {
                Variety = XDTOVariety.List;
            }
            else if (typeDefinition.Variety == XSSimpleTypeVariety.Union)
            {
                Variety = XDTOVariety.Union;
            }
        }

        public override bool Equals(IValue other)
        {
            if (other.AsObject() is XDTOValueType valueType)
                return (NamespaceURI == valueType.NamespaceURI) && (Name == valueType.Name);
            else
                return false;
        }

        #region OneScript

        #region Properties

        [ContextProperty("URIПространстваИмен", "NamespaceURI")]
        public string NamespaceURI { get; }

        [ContextProperty("Имя", "Name")]
        public string Name { get; }

        [ContextProperty("Вариант", "Variety")]
        public XDTOVariety Variety { get; }

        [ContextProperty("БазовыйТип", "BaseType")]
        public XDTOValueType BaseType { get; }

        [ContextProperty("ТипыЧленовОбъединения", "MemberTypes")]
        public XDTOValueTypeCollection MemberTypes { get; }

        [ContextProperty("ТипЭлементаСписка", "ListItemType")]
        public XDTOValueType ListItemType { get; }

        [ContextProperty("Фасеты", "Facets")]
        public XDTOFacetCollection Facets { get; }

        #endregion

        #region Methods

        [ContextMethod("Проверить", "Validate")]
        public void Validate(IValue value) => throw new NotImplementedException();

        [ContextMethod("ЭтоПотомок", "IsDescendant")]
        public bool IsDescendant(XDTOValueType type)
        {
            XDTOValueType valueType = type;

            while (valueType is XDTOValueType)
            {
                if (valueType.Equals(this))
                    return true;
                else
                    valueType = valueType.BaseType;
            };

            return false;
        }

        #endregion

        #endregion
    }
}