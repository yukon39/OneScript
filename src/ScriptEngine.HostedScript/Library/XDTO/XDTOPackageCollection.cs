/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using ScriptEngine.HostedScript.Library.XMLSchema;
using ScriptEngine.Machine.Contexts;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    [ContextClass("КоллекцияПакетовXDTO", "XDTOPackageCollection")]
    public class XDTOPackageCollection : AutoContext<XDTOPackageCollection>, ICollectionContext, IEnumerable<XDTOPackage>
    {
        private readonly List<XDTOPackage> _items;
        private readonly XDTOFactory _factory;

        internal XDTOPackageCollection()
        {
            _items = new List<XDTOPackage>();
            _factory = null;
        }

        internal XDTOPackageCollection(XMLSchemaSet schemaSet, XDTOFactory factory)
            : this()
        {
            _factory = factory;

            foreach (XMLSchema.XMLSchema schema in schemaSet)
            {
                _items.Add(new XDTOPackage(schema, factory));
            }

            System.Xml.Schema.XmlSchemaSet native = schemaSet.NativeValue();
            SystemLogger.Write($"OScript {schemaSet.Count()}");
            SystemLogger.Write($"Native {schemaSet.NativeValue().Count}");

            ICollection ss = native.Schemas("http://www.w3.org/2001/XMLSchema");
            SystemLogger.Write($"XMLSchema {ss.Count}");
        }

        internal void Add(XDTOPackage package) => _items.Add(package);

        #region OneScript

        #region Methods

        [ContextMethod("Количество", "Count")]
        public int Count() => _items.Count;

        [ContextMethod("Получить", "Get")]
        public XDTOPackage Get(int index) => _items[index];

        #endregion

        #endregion

        #region ICollectionContext

        public CollectionEnumerator GetManagedIterator() => new CollectionEnumerator(GetEnumerator());

        #endregion

        #region IEnumerator

        public IEnumerator<XDTOPackage> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
