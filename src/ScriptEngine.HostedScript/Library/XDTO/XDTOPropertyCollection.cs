/*----------------------------------------------------------
This Source Code Form is subject to the terms of the 
Mozilla Public License, v.2.0. If a copy of the MPL 
was not distributed with this file, You can obtain one 
at http://mozilla.org/MPL/2.0/.
----------------------------------------------------------*/

using System.Collections;
using System.Collections.Generic;
using ScriptEngine.Machine.Contexts;

namespace ScriptEngine.HostedScript.Library.XDTO
{
    [ContextClass("КоллекцияСвойствXDTO", "XDTOPropertyCollection")]
    public class XDTOPropertyCollection : AutoContext<XDTOPropertyCollection>, ICollectionContext, IEnumerable<XDTOProperty>
    {
        private readonly List<XDTOProperty> _items;

        internal XDTOPropertyCollection()
        {
            _items = new List<XDTOProperty>();
        }

        #region OneScript

        #region Methods

        [ContextMethod("Количество", "Count")]
        public int Count() => _items.Count;

        [ContextMethod("Получить", "Get")]
        public XDTOProperty Get(int index) => _items[index];

        #endregion

        #endregion

        #region ICollectionContext

        public CollectionEnumerator GetManagedIterator() => new CollectionEnumerator(GetEnumerator());

        #endregion

        #region IEnumerator

        public IEnumerator<XDTOProperty> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
