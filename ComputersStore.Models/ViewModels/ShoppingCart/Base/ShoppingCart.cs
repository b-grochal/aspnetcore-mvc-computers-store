using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputersStore.Models.ViewModels.ShoppingCart.Base
{
    public class ShoppingCart
    {
        [JsonProperty]
        private List<ShoppingCartItem> shoppingCartItemsCollection = new List<ShoppingCartItem>();

        public void AddItem(int productId, int quantity)
        {
            var shoppingCartItem = shoppingCartItemsCollection
                .Where(x => x.ProductId == productId)
                .FirstOrDefault();

            if (shoppingCartItem == null)
            {
                shoppingCartItemsCollection.Add(new ShoppingCartItem
                {
                    ProductId = productId,
                    Quantity = quantity
                });
            }
            else
            {
                shoppingCartItem.Quantity += quantity;
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
