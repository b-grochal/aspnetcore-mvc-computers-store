using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputersStore.Models.ViewModels.ShoppingCart
{
    public class ShoppingCart
    {
        private List<ShoppingCartItem> shoppingCartItemsCollection = new List<ShoppingCartItem>();

        public void AddItem(int productId)
        {
            var shoppingCartItem = shoppingCartItemsCollection
                .Where(x => x.ProductId == productId)
                .FirstOrDefault();

            if (shoppingCartItem == null)
            {
                shoppingCartItemsCollection.Add(new ShoppingCartItem
                {
                    ProductId = productId,
                    Quantity = 1
                });
            }
            else
            {
                shoppingCartItem.Quantity++;
            }
        }

        public void RemoweItem(int productId)
        {
            shoppingCartItemsCollection.RemoveAll(x => x.ProductId == productId);
        }

        public void Clear()
        {
            shoppingCartItemsCollection.Clear();
        }

        public IEnumerable<ShoppingCartItem> GetShoppingCartItems()
        {
            return shoppingCartItemsCollection;
        }
    }
}
