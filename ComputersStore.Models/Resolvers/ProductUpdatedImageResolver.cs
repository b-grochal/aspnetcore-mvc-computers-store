using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.IO;

namespace ComputersStore.Models.Resolvers
{
    public class ProductUpdatedImageResolver : IValueResolver<ProductEditFormViewModel, Product, byte[]>
    {
        public byte[] Resolve(ProductEditFormViewModel source, Product destination, byte[] destMember, ResolutionContext context)
        {
            if(source.IsImageUpdated && source.NewImageFile != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    source.NewImageFile.CopyTo(ms);
                    return ms.ToArray();
                };
            }
            else
            {
                return Convert.FromBase64String(source.OldImage);
            }
        }
    }
}
