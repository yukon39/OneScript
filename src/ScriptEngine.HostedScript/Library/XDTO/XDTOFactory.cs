/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using System.Collections.Generic;
using System.Linq;
using ScriptEngine.HostedScript.Library.Xml;
using ScriptEngine.HostedScript.Library.XMLSchema;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    [ContextClass("ФабрикаXDTO", "XDTOFactory")]
    public class XDTOFactory : AutoContext<XDTOFactory>
    {
        private List<XDTOTypeRefence> _types;

        internal XDTOFactory()
        {
            _types = new List<XDTOTypeRefence>();
            Packages = new XDTOPackageCollection(XDTOGlobal.CoreSchemaSet(), this);
        }

        internal XDTOFactory(XMLSchemaSet schemaSet)
            : this()
        {
            foreach (XMLSchema.XMLSchema schema in schemaSet)
            {
                Packages.Add(new XDTOPackage(schema, this));
            }
        }

        public IXDTOType Type(string namespaceURI, string localName)
        {
            XDTOTypeRefence typeReference = _types.FirstOrDefault(x => (x.NamespaceURI == namespaceURI) && (x.Name == localName));

            return typeReference?.Type;




            //XDTOPackage package = Packages.FirstOrDefault(x => x.NamespaceURI == namespaceURI);
            //if (package is XDTOPackage)
            //    return package.FirstOrDefault(x => x.Name == localName);
            //else
            //    return null;
        }

        public IXDTOType Type(XMLExpandedName expandedName)
        {
            XDTOPackage package = Packages.FirstOrDefault(x => x.NamespaceURI == expandedName.NamespaceURI);
            if (package is XDTOPackage)
                return package.FirstOrDefault(x => x.Name == expandedName.LocalName);
            else
                return null;
        }

        internal XDTOTypeRefence RegisterType(IXDTOType type)
        {
            XDTOTypeRefence typeReference = _types.FirstOrDefault(x => (x.NamespaceURI == type.NamespaceURI) && (x.Name == type.Name));

            if (typeReference is XDTOTypeRefence)
                typeReference.SetType(type);
            else
            {
                typeReference = new XDTOTypeRefence(type);
                _types.Add(typeReference);
            }

            return null;
        }

        internal XDTOTypeRefence GetTypeRefence(XMLExpandedName expandedName)
        {
            XDTOTypeRefence typeReference = _types.FirstOrDefault(x => (x.NamespaceURI == expandedName.NamespaceURI) && (x.Name == expandedName.LocalName));

            if (typeReference is XDTOTypeRefence)
                return typeReference;

            typeReference = new XDTOTypeRefence(expandedName);
            _types.Add(typeReference);

            return typeReference;
        }

        #region OneScript

        #region Properties

        [ContextProperty("Пакеты", "Packages")]
        public XDTOPackageCollection Packages { get; }

        #endregion

        #region Methods

        //ЗаписатьJSON(WriteJSON)
        //ЗаписатьXML(WriteXML)
        //Привести(Cast)
        //ПрочитатьJSON(ReadJSON)
        //ПрочитатьXML(ReadXML)
        //Создать(Create)

        [ContextMethod("Тип", "Type")]
        public IXDTOType TypeImpl(string namespaceURI, string localName)
        {
            return Type(namespaceURI, localName);
        }

        //ЭкспортМоделиXDTO(ExportXDTOModel)
        //ЭкспортСхемыXML(ExportXMLSchema)

        #endregion

        #region Constructors

        [ScriptConstructor(Name = "По умолчанию")]
        public static XDTOFactory CreateInstance() => new XDTOFactory();

        [ScriptConstructor(Name = "На основе набора схем XML")]
        public static XDTOFactory CreateInstanceIValue(IValue param1, IValue param2 = null)
        {
            if (param1.DataType == DataType.Object)
            {
                if (param1.AsObject() is XMLSchemaSet schemaSet)
                {
                    return new XDTOFactory(schemaSet);
                }
            }

            throw RuntimeException.InvalidArgumentType();
        }

        #endregion

        #endregion
    }
}
