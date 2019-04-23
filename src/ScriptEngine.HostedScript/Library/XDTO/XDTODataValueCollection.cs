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
    [ContextClass("КоллекцияЗначенийXDTO", "XDTODataValueCollection")]
    public class XDTODataValueCollection : AutoContext<XDTODataValueCollection>, ICollectionContext, IEnumerable<XDTODataValue>
    {
        private readonly List<XDTODataValue> _items;

        internal XDTODataValueCollection()
        {
            _items = new List<XDTODataValue>();
        }

        #region OneScript

        #region Methods

        [ContextMethod("Количество", "Count")]
        public int Count() => _items.Count;

        [ContextMethod("Получить", "Get")]
        public XDTODataValue Get(int index) => _items[index];

        #endregion

        #endregion

        #region ICollectionContext

        public CollectionEnumerator GetManagedIterator() => new CollectionEnumerator(GetEnumerator());

        #endregion

        #region IEnumerator

        public IEnumerator<XDTODataValue> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
