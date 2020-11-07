﻿using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.Product;
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
            if(source.IsImageUpdated && source.NewImageFile != null)
            {
                MemoryStream ms = new MemoryStream();
                source.NewImageFile.CopyTo(ms);
                return ms.ToArray();
            }
            else
            {
                return source.OldImage;
            }
        }
    }
}
