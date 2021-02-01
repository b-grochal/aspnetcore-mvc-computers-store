using AutoMapper;
using ComputersStore.Data.Entities;
using ComputersStore.Models.ViewModels.Product.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ComputersStore.Models.Resolvers
{
    public class OldProductImageResolver : IValueResolver<Product, ProductEditFormViewModel, string>
    {
        public string Resolve(Product source, ProductEditFormViewModel destination, string destMember, ResolutionContext context)
        {
            return Convert.ToBase64String(source.Image);
        }
    }
}
