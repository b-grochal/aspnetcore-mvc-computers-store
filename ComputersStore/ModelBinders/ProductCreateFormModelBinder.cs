using ComputersStore.Data.Dictionaries;
using ComputersStore.Models.ViewModels.Product.Base;
using ComputersStore.Models.ViewModels.Product.Specific.CentralProcessingUnit;
using ComputersStore.Models.ViewModels.Product.Specific.GraphicsProcessingUnit;
using ComputersStore.Models.ViewModels.Product.Specific.HardDiskDrive;
using ComputersStore.Models.ViewModels.Product.Specific.Motherboard;
using ComputersStore.Models.ViewModels.Product.Specific.PowerSupplyUnit;
using ComputersStore.Models.ViewModels.Product.Specific.RandomAccessMemory;
using ComputersStore.Models.ViewModels.Product.Specific.SolidStateDrive;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ComputersStore.WebUI.ModelBinders
{
    public class ProductCreateFormModelBinder : IModelBinder
    {
        private readonly Dictionary<Type, (ModelMetadata, IModelBinder)> binders;

        public ProductCreateFormModelBinder(Dictionary<Type, (ModelMetadata, IModelBinder)> binders)
        {
            this.binders = binders;
        }

        public async Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var modelKindName = ModelNames.CreatePropertyModelName(bindingContext.ModelName, nameof(ProductCreateFormViewModel.ProductCategoryId));
            var modelTypeValue = bindingContext.ValueProvider.GetValue(modelKindName).FirstValue;

            IModelBinder modelBinder;
            ModelMetadata modelMetadata;
            if (modelTypeValue == ProductCategoryDictionary.CPU.ToString())
            {
                (modelMetadata, modelBinder) = binders[typeof(CentralProcessingUnitCreateFormViewModel)];
            }
            else if (modelTypeValue == ProductCategoryDictionary.GPU.ToString())
            {
                (modelMetadata, modelBinder) = binders[typeof(GraphicsProcessingUnitCreateFormViewModel)];
            }
            else if (modelTypeValue == ProductCategoryDictionary.HDD.ToString())
            {
                (modelMetadata, modelBinder) = binders[typeof(HardDiskDriveCreateFormViewModel)];
            }
            else if (modelTypeValue == ProductCategoryDictionary.Motherboard.ToString())
            {
                (modelMetadata, modelBinder) = binders[typeof(MotherboardCreateFormViewModel)];
            }
            else if (modelTypeValue == ProductCategoryDictionary.PSU.ToString())
            {
                (modelMetadata, modelBinder) = binders[typeof(PowerSupplyUnitCreateFormViewModel)];
            }
            else if (modelTypeValue == ProductCategoryDictionary.RAM.ToString())
            {
                (modelMetadata, modelBinder) = binders[typeof(RandomAccessMemoryCreateFormViewModel)];
            }
            else if (modelTypeValue == ProductCategoryDictionary.SSD.ToString())
            {
                (modelMetadata, modelBinder) = binders[typeof(SolidStateDriveCreateFormViewModel)];
            }
            else
            {
                bindingContext.Result = ModelBindingResult.Failed();
                return;
            }

            var newBindingContext = DefaultModelBindingContext.CreateBindingContext(
                bindingContext.ActionContext,
                bindingContext.ValueProvider,
                modelMetadata,
                bindingInfo: null,
                bindingContext.ModelName);

            await modelBinder.BindModelAsync(newBindingContext);
            bindingContext.Result = newBindingContext.Result;

            if (newBindingContext.Result.IsModelSet)
            {
                // Setting the ValidationState ensures properties on derived types are correctly 
                bindingContext.ValidationState[newBindingContext.Result] = new ValidationStateEntry
                {
                    Metadata = modelMetadata,
                };
            }
        }
    }
}
