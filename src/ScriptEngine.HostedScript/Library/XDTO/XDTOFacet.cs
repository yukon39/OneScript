/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptEngine.Machine.Contexts;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    [ContextClass("ФасетXDTO", "XDTOFacet")]
    public class XDTOFacet : AutoContext<XDTOFacet>
    {
        internal XDTOFacet(XDTOFacetType type, string value)
        {
            Type = type;
            Value = value;
        }

        #region OneScript

        #region Properties

        [ContextProperty("Вид", "Type")]
        public XDTOFacetType Type { get; }

        [ContextProperty("Значение", "Value")]
        public string Value { get; }

        #endregion

        #endregion
    }
}
