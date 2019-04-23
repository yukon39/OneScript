/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using System;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    [ContextClass("ТипОбъектаXDTO", "XDTOObjectType")]
    public class XDTOObjectType : AutoContext<XDTOObjectType>, IXDTOType
    {
        internal XDTOObjectType() { }

        #region OneScript

        #region Properties

        [ContextProperty("URIПространстваИмен", "NamespaceURI")]
        public string NamespaceURI { get; }

        [ContextProperty("Имя", "Name")]
        public string Name { get; }

        [ContextProperty("БазовыйТип", "BaseType")]
        public XDTOObjectType BaseType { get; }

        [ContextProperty("Абстрактный", "Abstract")]
        public bool Abstract { get; }

        [ContextProperty("Открытый", "Open")]
        public bool Open { get; }

        [ContextProperty("Последовательный", "Sequenced")]
        public bool Sequenced { get; }

        [ContextProperty("Смешанный", "Mixed")]
        public bool Mixed { get; }

        [ContextProperty("Упорядоченный", "Ordered")]
        public bool Ordered { get; }

        [ContextProperty("Свойства", "Properties")]
        public XDTOPropertyCollection Properties { get; }

        #endregion

        #region Methods

        [ContextMethod("Проверить", "Validate")]
        public void Validate(IValue value) => throw new NotImplementedException();

        [ContextMethod("ЭтоПотомок", "IsDescendant")]
        public bool IsDescendant(XDTOObjectType type)
        {
            XDTOObjectType valueType = type;

            while (valueType is XDTOObjectType)
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
