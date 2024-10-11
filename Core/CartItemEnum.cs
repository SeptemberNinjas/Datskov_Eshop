using System.Collections;

namespace Eshop.Core
{
    public class CartItemEnum : IEnumerator
    {
        
        public CartItem[] _item;

        // Enumerators are positioned before the first element
        // until the first MoveNext() call.
        int position = -1;

        public CartItemEnum(Cart cart)
        {
            _item = [.. cart.Items];
        }

        public bool MoveNext()
        {
            position++;
            return (position < _item.Length);
        }

        public void Reset()
        {
            position = -1;
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public CartItem Current
        {
            get
            {
                try
                {
                    return _item[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }
    }
}
