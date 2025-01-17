﻿using ComputersStore.Models.ViewModels.Product.Base;
using ComputersStore.Models.ViewModels.Product.Specific.CentralProcessingUnit;
using ComputersStore.Models.ViewModels.Product.Specific.GraphicsProcessingUnit;
using ComputersStore.Models.ViewModels.Product.Specific.HardDiskDrive;
using ComputersStore.Models.ViewModels.Product.Specific.Motherboard;
using ComputersStore.Models.ViewModels.Product.Specific.PowerSupplyUnit;
using ComputersStore.Models.ViewModels.Product.Specific.RandomAccessMemory;
using ComputersStore.Models.ViewModels.Product.Specific.SolidStateDrive;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace ComputersStore.WebUI.ModelBinders
{
    public class ProductEditFormModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType != typeof(ProductEditFormViewModel))
            {
                return null;
            }

            var subclasses = new[]
            {
                typeof(CentralProcessingUnitEditFormViewModel),
                typeof(GraphicsProcessingUnitEditFormViewModel),
                typeof(HardDiskDriveEditFormViewModel),
                typeof(MotherboardEditFormViewModel),
                typeof(PowerSupplyUnitEditFormViewModel),
                typeof(RandomAccessMemoryEditFormViewModel),
                typeof(SolidStateDriveEditFormViewModel),
            };

            var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
            foreach (var type in subclasses)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new ProductEditFormModelBinder(binders);
        }
    }
}
