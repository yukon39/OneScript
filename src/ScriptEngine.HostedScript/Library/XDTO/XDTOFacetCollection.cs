/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    [ContextClass("КоллекцияФасетовXDTO", "XDTOFacetCollection")]
    public class XDTOFacetCollection : AutoContext<XDTOValueType>, ICollectionContext, IEnumerable<XDTOFacet>
    {
        private readonly List<XDTOFacet> _items;
        private readonly XDTOFacetCollection _patterns;
        private readonly XDTOFacetCollection _enumerations;

        internal XDTOFacetCollection()
        {
            _items = new List<XDTOFacet>();
            _patterns = new XDTOFacetCollection();
            _enumerations = new XDTOFacetCollection();
        }

        #region OneScript

        #region Properties

        [ContextProperty("Образцы", "Patterns")]
        public XDTOFacetCollection Patterns => _patterns;

        [ContextProperty("Перечисления", "Enumerations")]
        public XDTOFacetCollection Enumerations => _enumerations;

        #endregion

        #region Methods

        [ContextMethod("Количество", "Count")]
        public int Count() => _items.Count;

        [ContextMethod("Получить", "Get")]
        public XDTOFacet Get(IValue value)
        {
            DataType DataType = value.DataType;
            switch (DataType)
            {
                case DataType.Enumeration:
                    {
                        //if (value.GetRawValue() is XDTOFacetType facetType)
                        //    return _items.FirstOrDefault(x => x.Type.Equals(facetType));
                        //else
                            throw RuntimeException.InvalidArgumentType();
                    }

                case DataType.Number:
                    return _items[(int)value.AsNumber()];

                default:
                    throw RuntimeException.InvalidArgumentType();
            }
        }

        #endregion

        #endregion

        #region ICollectionContext

        public CollectionEnumerator GetManagedIterator() => new CollectionEnumerator(GetEnumerator());

        #endregion

        #region IEnumerator

        public IEnumerator<XDTOFacet> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
       
        #endregion
    }
}
