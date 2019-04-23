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
    [ContextClass("ЗначениеXDTO", "XDTODataValue")]
    public class XDTODataValue : AutoContext<XDTODataValue>
    {
        private readonly XDTOValueType _type;

        internal XDTODataValue(XDTOValueType type)
        {
            _type = type;
        }

        #region OneScript

        #region Properties

        [ContextProperty("Значение", "Value")]
        public IValue Value { get; }

        [ContextProperty("ЛексическоеЗначение", "LexicalValue")]
        public string LexicalValue { get; }

        [ContextProperty("Список", "List")]
        public XDTODataValueCollection List { get; }

        #endregion

        #region Methods

        [ContextMethod("Тип", "Type")]
        public XDTOValueType Type() => _type;

        #endregion

        #endregion
    }
}
