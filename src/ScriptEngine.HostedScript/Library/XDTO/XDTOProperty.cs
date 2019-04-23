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
    [ContextClass("СвойствоXDTO", "XDTOProperty")]
    public class XDTOProperty : AutoContext<XDTOProperty>
    {
        internal XDTOProperty() { }

        #region OneScript

        #region Properties

        [ContextProperty("URIПространстваИмен", "NamespaceURI")]
        public string NamespaceURI { get; }

        [ContextProperty("Имя", "Name")]
        public string Name { get; }

        [ContextProperty("ЛокальноеИмя", "LocalName")]
        public string LocalName { get; }

        [ContextProperty("ВерхняяГраница", "UpperBound")]
        public decimal UpperBound { get; }

        [ContextProperty("НижняяГраница", "LowerBound")]
        public decimal LowerBound { get; }

        [ContextProperty("ВозможноПустое", "Nillable")]
        public bool Nillable { get; }

        [ContextProperty("ЗначениеПоУмолчанию", "DefaultValue")]
        public IValue DefaultValue { get; } //TODO: XDTODataValue

        [ContextProperty("Квалифицированное", "Qualified")]
        public bool Qualified { get; }

        [ContextProperty("ОбъектВладелец", "OwnerObject")]
        public IValue OwnerObject { get; } //TODO: XDTODataObject

        [ContextProperty("Тип", "Type")]
        public IXDTOType Type { get; }

        [ContextProperty("ТипВладелец", "OwnerType")]
        public IValue OwnerType { get; } //TODO: XDTOObjectType, XDTODataObject

        [ContextProperty("Фиксированное", "Fixed")]
        public bool Fixed { get; }

        [ContextProperty("Форма", "Form")]
        public XMLForm Form { get; }

        #endregion

        #endregion
    }
}
