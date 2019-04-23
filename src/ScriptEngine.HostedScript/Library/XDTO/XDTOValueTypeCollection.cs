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
    [ContextClass("КоллекцияТиповЗначенийXDTO", "XDTOValueTypeCollection")]
    public class XDTOValueTypeCollection : AutoContext<XDTOValueTypeCollection>, ICollectionContext, IEnumerable<XDTOValueType>
    {
        private readonly List<XDTOValueType> _items;

        internal XDTOValueTypeCollection()
        {
            _items = new List<XDTOValueType>();
        }

        #region OneScript

        #region Methods

        [ContextMethod("Количество", "Count")]
        public int Count() => _items.Count;

        [ContextMethod("Получить", "Get")]
        public XDTOValueType Get(int index) => _items[index];

        #endregion

        #endregion

        #region ICollectionContext

        public CollectionEnumerator GetManagedIterator() => new CollectionEnumerator(GetEnumerator());

        #endregion

        #region IEnumerator

        public IEnumerator<XDTOValueType> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion
    }
}
