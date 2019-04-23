/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using ScriptEngine.Machine.Contexts;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    [ContextClass("ОбъектXDTO", "XDTODataObject")]
    public class XDTODataObject : DynamicPropertiesAccessor
    {
        private readonly XDTOObjectType _type;
        private readonly XDTODataObject _owner;
        private readonly XDTOProperty _owningProperty;
        private readonly XDTOPropertyCollection _properties;

        internal XDTODataObject(XDTOObjectType type)
        {
            _type = type;
            _owner = null;
            _owningProperty = null;
            _properties = new XDTOPropertyCollection();
        }

        #region OneScript

        #region Methods

        [ContextMethod("Тип", "Type")]
        public XDTOObjectType Type() => _type;

        [ContextMethod("Владелец", "Owner")]
        public XDTODataObject Owner() => _owner;

        [ContextMethod("ВладеющееСвойство", "OwningProperty")]
        public XDTOProperty OwningProperty() => _owningProperty;

        [ContextMethod("Свойства", "Properties")]
        public XDTOPropertyCollection Properties() => _properties;

        //Добавить(Add)
        //Получить(Get)
        //ПолучитьXDTO(GetXDTO)
        //ПолучитьСписок(GetList)
        //Последовательность(Sequence)
        //Проверить(Validate)
        //Сбросить(Unset)
        //Установить(Set)
        //Установлено(IsSet)

        #endregion

        #endregion
    }
}
