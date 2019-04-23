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
    [ContextClass("ФабрикаXDTO", "XDTOFactory")]
    public class XDTOFactory : AutoContext<XDTOFactory>
    {
        internal XDTOFactory()
        {

        }

        #region OneScript

        #region Properties

        [ContextProperty("Пакеты", "Packages")]
        public XDTOFactory Packages { get; } //TODO: XDTOPackageCollection

        #endregion

        #region Methods

        //ЗаписатьJSON(WriteJSON)
        //ЗаписатьXML(WriteXML)
        //Привести(Cast)
        //ПрочитатьJSON(ReadJSON)
        //ПрочитатьXML(ReadXML)
        //Создать(Create)
        
        [ContextMethod("Тип", "Type")]
        public IXDTOType Type(string namespaceURI, string localName)
        {
            return null;
        }

        //ЭкспортМоделиXDTO(ExportXDTOModel)
        //ЭкспортСхемыXML(ExportXMLSchema)

        #endregion

        #region Constructors

        [ScriptConstructor(Name = "По умолчанию")]
        public static XDTOFactory CreateInstance() => new XDTOFactory();

        #endregion

        #endregion
    }
}
