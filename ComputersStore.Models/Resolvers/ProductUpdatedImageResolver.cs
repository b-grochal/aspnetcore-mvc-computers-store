using AutoMapper;
using ComputersStore.Core.Data;
using ComputersStore.Models.ViewModels.Basic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ComputersStore.Models.Resolvers
{
    public class ProductUpdatedImageResolver : IValueResolver<ProductEditFormViewModel, Product, byte[]>
    {
        public byte[] Resolve(ProductEditFormViewModel source, Product destination, byte[] destMember, ResolutionContext context)
        {
            if(source.IsImageUpdated && source.ImageFile != null)
            {
                MemoryStream ms = new MemoryStream();
                source.ImageFile.CopyTo(ms);
                return ms.ToArray();
            }
            else
            {
                return source.Image;
            }
        }
    }
}
