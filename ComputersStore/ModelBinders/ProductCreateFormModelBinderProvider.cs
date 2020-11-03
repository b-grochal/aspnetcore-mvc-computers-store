using ComputersStore.Models.ViewModels.Product;
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
using System.Linq;
using System.Threading.Tasks;

namespace ComputersStore.WebUI.ModelBinders
{
    public class ProductCreateFormModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context.Metadata.ModelType != typeof(ProductCreateFormViewModel))
            {
                return null;
            }

            var subclasses = new[] 
            { 
                typeof(CentralProcessingUnitCreateFormViewModel), 
                typeof(GraphicsProcessingUnitCreateFormViewModel),
                typeof(HardDiskDriveCreateFormViewModel),
                typeof(MotherboardCreateFormViewModel),
                typeof(PowerSupplyUnitCreateFormViewModel),
                typeof(RandomAccessMemoryCreateFormViewModel),
                typeof(SolidStateDriveCreateFormViewModel),
            };

            var binders = new Dictionary<Type, (ModelMetadata, IModelBinder)>();
            foreach (var type in subclasses)
            {
                var modelMetadata = context.MetadataProvider.GetMetadataForType(type);
                binders[type] = (modelMetadata, context.CreateBinder(modelMetadata));
            }

            return new ProductCreateFormModelBinder(binders);
        }
    }
}
