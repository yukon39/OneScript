/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using ScriptEngine.HostedScript.Library.Xml;
using ScriptEngine.Machine;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    internal class XDTOTypeRefence
    {
        private XDTOTypeRefence() => Type = null;

        internal XDTOTypeRefence(IXDTOType type)
            : this()
        {
            NamespaceURI = type.NamespaceURI;
            Name = type.Name;
            Type = type;
        }

        internal XDTOTypeRefence(XMLExpandedName expandedName)
            : this()
        {
            NamespaceURI = expandedName.NamespaceURI;
            Name = expandedName.LocalName;
        }

        internal void SetType(IXDTOType type)
        {
            if (Type is IXDTOType)
                throw RuntimeException.InvalidArgumentValue();
            else
                Type = type;
        }

        internal string Name { get; }

        internal string NamespaceURI { get; }

        internal IXDTOType Type { get; private set; }
    }
}
